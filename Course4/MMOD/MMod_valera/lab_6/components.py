import collections
from lab_6.exceptions import StorageError, ChannelError
from lab_6.distribution import ExponentialDistribution


class Storage(object):

    def __init__(self, size):
        self._size = size
        self._storage = collections.deque()

        self.statistic_task_count = []

    @property
    def is_empty(self):
        return len(self._storage) == 0

    @property
    def is_full(self):
        return len(self._storage) == self._size

    def push(self, item):
        if self.is_full:
            raise StorageError()
        self._storage.append(item)

    def pop(self):
        if self.is_empty:
            return None
        return self._storage.popleft()

    def loop(self, t=1):
        self.statistic_task_count.append(len(self._storage))


class Task(object):

    class Status:
        HANDLING = 1
        COMPLETED = 2
        REFUSED = 3

    def __init__(self, start_time):
        self.handling_time = 0.0
        self.start_time = start_time
        self._status = self.Status.HANDLING

    @property
    def status(self):
        return self._status

    def complete(self):
        self._status = self.Status.COMPLETED

    def refuse(self):
        self._status = self.Status.REFUSED

    def loop(self, t=1):
        if self.status == self.Status.HANDLING:
            self.handling_time += t


class Channel(object):

    def __init__(self, distribution_func):
        self._distribution_func = distribution_func
        self._task = None
        self._execution_time = None

        self.statistic_free = 0
        self.statistic_block = 0
        self.statistic_handling = 0

    @property
    def is_free(self):
        return not self._task

    @property
    def completed_handling(self):
        if self.is_free:
            raise ChannelError()

        return self._execution_time <= 0.0

    def add_task(self, task):
        self._task = task
        self._execution_time = self._distribution_func.generate()

    def pop_task(self):
        if self.is_free or not self.completed_handling:
            raise ChannelError()

        task = self._task

        self._task = None
        self._execution_time = None

        return task

    def loop(self, t=1):
        if self.is_free:
            self.statistic_free += 1
            return True

        if self._execution_time <= 0.0:
            self.statistic_block += 1
        else:
            self.statistic_handling += 1

        self._task.loop(t)

        self._execution_time -= t

        return self.completed_handling


class Phase(object):

    def __init__(self, storage, channels, next_phase=None):
        self._storage = storage
        self._channels = channels or []
        self._next_phase = next_phase

    @property
    def can_add_task(self):
        return not self._storage.is_full

    @property
    def completed_all_tasks(self):
        return self._storage.is_empty and not filter(lambda ch: not ch.is_free, self._channels)

    def add_task(self, task):
        if not self.can_add_task:
            return False

        if self._storage.is_empty:
            free_channel = self.get_free_channel()
            if free_channel:
                free_channel.add_task(task)
            else:
                self._storage.push(task)
        else:
            self._storage.push(task)

        return True

    def get_free_channel(self):
        for channel in self._channels:
            if channel.is_free:
                return channel
        return None

    def loop(self, t=1):
        self._storage.loop(t)

        for channel in self._channels:
            channel.loop(t)

            if channel.is_free and not self._storage.is_empty:
                task = self._storage.pop()
                channel.add_task(task)
                continue

            elif not channel.is_free and channel.completed_handling and \
                    (not self._next_phase or self._next_phase.can_add_task):
                task = channel.pop_task()

                if self._next_phase:
                    self._next_phase.add_task(task)
                else:
                    task.complete()


class TaskGenerator(object):

    def __init__(self, limit=10000):
        self._tm = None  # TODO
        self._next_task = 1
        self._limit = limit
        self._task_generated = 0

        self._random = ExponentialDistribution(l=1)

    def get_task(self, start_time):
        if self._next_task <= 0.0 and self._task_generated < self._limit:
            self._task_generated += 1
            return Task(start_time)
        else:
            return None

    def get_next_time(self):
        return self._random.generate()

    def loop(self, t=1):
        self._next_task -= t

        if self._next_task <= -1:
            self._next_task = self.get_next_time()


class System(object):

    def __init__(self, phases, tasks_count=1000, delta_time=1):
        self._phases = phases
        for i in xrange(0, len(self._phases)-1):
            self._phases[i]._next_phase = self._phases[i+1]

        self._task_generator = TaskGenerator(tasks_count)
        self._tasks_count = tasks_count
        self._delta_time = delta_time

        self.total_time = 0
        self.loops = 0

        self.all_tasks = []
        self.refused_tasks = []

    @property
    def finish_modeling(self):
        return len(self.all_tasks) == self._tasks_count and \
               not filter(lambda p: not p.completed_all_tasks, self._phases)

    def loop(self, t=1):
        for phase in self._phases:
            phase.loop(t)

        self._task_generator.loop(t)

        task = self._task_generator.get_task(self.total_time)
        if not task:
            return

        self.all_tasks.append(task)

        added = self._phases[0].add_task(task)
        if not added:
            task.refuse()
            self.refused_tasks.append(task)

    def start(self):
        while not self.finish_modeling:
            self.loops += 1
            self.total_time += self._delta_time
            self.loop(self._delta_time)
