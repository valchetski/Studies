import math
import matplotlib.pyplot as plot
from components import Phase, Storage, Channel, System, Task
from distribution import UniformDistribution, SimpsonDistribution, GausseDistribution, TriangularDistribution
from common.plots import draw_probability_density, draw_hist


system = System(delta_time=0.01,
                tasks_count=10000,
                phases=[
                    Phase(storage=Storage(size=3),
                          channels=[
                              Channel(UniformDistribution(a=3, b=9)),
                              Channel(UniformDistribution(a=3, b=9)),
                              Channel(UniformDistribution(a=3, b=9)),
                          ]),
                    Phase(storage=Storage(size=2),
                          channels=[
                              Channel(SimpsonDistribution(a=2, b=5)),
                              Channel(SimpsonDistribution(a=2, b=5)),
                              Channel(SimpsonDistribution(a=2, b=5)),
                              Channel(SimpsonDistribution(a=2, b=5)),
                              Channel(SimpsonDistribution(a=2, b=5)),
                          ]),
                    Phase(storage=Storage(size=1),
                          channels=[
                              Channel(TriangularDistribution(a=2, b=5)),
                              Channel(TriangularDistribution(a=2, b=5)),
                              Channel(TriangularDistribution(a=2, b=5)),
                              Channel(TriangularDistribution(a=2, b=5)),
                              Channel(TriangularDistribution(a=2, b=5)),
                          ]),
                    Phase(storage=Storage(size=3),
                          channels=[
                              Channel(GausseDistribution(m=5, sigma=1)),
                              Channel(GausseDistribution(m=5, sigma=1)),
                              Channel(GausseDistribution(m=5, sigma=1)),
                              Channel(GausseDistribution(m=5, sigma=1)),
                          ]),
                    Phase(storage=Storage(size=3),
                          channels=[
                              Channel(GausseDistribution(m=5, sigma=1)),
                              Channel(GausseDistribution(m=5, sigma=1)),
                              Channel(GausseDistribution(m=5, sigma=1)),
                              Channel(GausseDistribution(m=5, sigma=1)),
                          ]),
                ])

system_optimized = System(delta_time=0.01,
                          tasks_count=10000,
                          phases=[
                              Phase(storage=Storage(size=5),
                                    channels=[
                                        Channel(UniformDistribution(a=3, b=9)),
                                        Channel(UniformDistribution(a=3, b=9)),
                                        Channel(UniformDistribution(a=3, b=9)),
                                        Channel(UniformDistribution(a=3, b=9)),
                                        Channel(UniformDistribution(a=3, b=9)),
                                    ]),
                              Phase(storage=Storage(size=5),
                                    channels=[
                                        Channel(SimpsonDistribution(a=2, b=5)),
                                        Channel(SimpsonDistribution(a=2, b=5)),
                                        Channel(SimpsonDistribution(a=2, b=5)),
                                        Channel(SimpsonDistribution(a=2, b=5)),
                                        Channel(SimpsonDistribution(a=2, b=5)),
                                    ]),
                              Phase(storage=Storage(size=5),
                                    channels=[
                                        Channel(TriangularDistribution(a=2, b=5)),
                                        Channel(TriangularDistribution(a=2, b=5)),
                                        Channel(TriangularDistribution(a=2, b=5)),
                                        Channel(TriangularDistribution(a=2, b=5)),
                                        Channel(TriangularDistribution(a=2, b=5)),
                                    ]),
                              Phase(storage=Storage(size=5),
                                    channels=[
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                    ]),
                              Phase(storage=Storage(size=1),
                                    channels=[
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                        Channel(GausseDistribution(m=5, sigma=1)),
                                    ]),
                          ])


def main(system):
    system.start()

    # Report

    figure = plot.figure()

    executed_tasks = filter(lambda t: t.status == Task.Status.COMPLETED, system.all_tasks)

    tasks_count = len(system.all_tasks)
    refused_tasks_count = len(system.refused_tasks)
    executed_tasks_count = len(executed_tasks)

    intensity = 1.0 * executed_tasks_count / system.total_time

    print('All tasks = {}'.format(tasks_count))
    print('Refused tasks = {}'.format(refused_tasks_count))
    print('Executed tasks = {}'.format(executed_tasks_count))
    print('\nProbability of refuse = {}%'.format(100.0 * refused_tasks_count / tasks_count))
    print('Intensity = {}'.format(intensity))

    ###############
    ## Intensity
    ##
    completed_tasks_times = sorted(task.start_time + task.handling_time for task in executed_tasks)

    completed_interval = []
    for i in xrange(0, len(completed_tasks_times)-1):
        completed_interval.append(completed_tasks_times[i+1] - completed_tasks_times[i])

    inten_mo = sum(completed_interval) / len(completed_interval)
    inten_d = sum(math.pow(t - inten_mo, 2) for t in completed_interval) / (len(completed_interval) - 1)
    print('\nIntensity:')
    print('M = {}'.format(inten_mo))
    print('D = {}'.format(inten_d))

    artist = figure.add_subplot(121)
    artist.set_title('Tasks output intensity')
    artist.hist(completed_interval, normed=True)  # Probability density
    # draw_probability_density(completed_interval, artist)

    ###############
    ## Time
    ##
    execution_time = [t.handling_time for t in executed_tasks]
    avg_time_mo = sum(execution_time) / len(executed_tasks)
    avg_time_d = sum(math.pow(t - avg_time_mo, 2) for t in execution_time) / (executed_tasks_count - 1)
    print('\nAverage time of execution task:'.format())
    print('M = {}'.format(avg_time_mo))
    print('D = {}'.format(avg_time_d))

    artist = figure.add_subplot(122)
    artist.set_title('Average time of execution task')
    artist.hist(execution_time, normed=True)  # Probability density
    # draw_probability_density(execution_time, artist)  # Probability of executing task

    for i, phase in enumerate(system._phases):
        print('======== {} phase ========'.format(i + 1))

        avg_tasks_in_storage = 1.0 * sum(phase._storage.statistic_task_count) / len(phase._storage.statistic_task_count)
        print('Average tasks in the storage: {}'.format(avg_tasks_in_storage))

        for i, channel in enumerate(phase._channels):
            free_stats = round(1.0 * channel.statistic_free / system.loops, 3)
            block_stats = round(1.0 * channel.statistic_block / system.loops, 3)
            handling_stats = round(1.0 * channel.statistic_handling / system.loops, 3)
            print('Channel {}: free - {}; handling - {}; block - {}'.format(i + 1, free_stats, handling_stats, block_stats))

    plot.show()


if __name__ == '__main__':
    main(system)
    # main(system_optimized)
