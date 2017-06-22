import numpy as np
import matplotlib.pyplot as plot
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg, NavigationToolbar2TkAgg
import Tkinter as tk


class Interval(object):

    def __init__(self):
        self.start = tk.DoubleVar()
        self.end = tk.DoubleVar()


class ChordMethodSolver(object):
    MAX_ITERATION = 3000

    def solve(self, interval, a, b, c, accuracy):
        f = np.poly1d([1, a, b, c])
        f_deriv = f.deriv()
        f_deriv_deriv = f_deriv.deriv()

        xn, x = self._get_xn(f, f_deriv_deriv, interval)
        iteration = 1

        x_prev = x
        x = xn(x_prev)

        while 1:
            iteration += 1
            x_prev_prev = x_prev
            x_prev = x
            x = xn(x_prev)

            if not self._need_do_next_iteration(x, x_prev, x_prev_prev, accuracy) or iteration >= ChordMethodSolver.MAX_ITERATION:
                break

        return {'x': x, 'iteration': iteration}

    def _get_xn(self, f, f_deriv_deriv, interval):
        if np.polyval(f, interval.start.get()) * np.polyval(f_deriv_deriv, interval.start.get()) > 0:
            xn = lambda x_prev: x_prev - np.polyval(f, x_prev)/(np.polyval(f, interval.start.get()) - np.polyval(f, x_prev))*(interval.start.get() - x_prev)
            x = interval.end.get()
        elif np.polyval(f, interval.end.get()) * np.polyval(f_deriv_deriv, interval.end.get()) > 0:
            xn = lambda x_prev: x_prev - np.polyval(f, x_prev)/(np.polyval(f, interval.end.get()) - np.polyval(f, x_prev))*(interval.end.get() - x_prev)
            x = interval.start.get()
        return (xn, x)

    def _need_do_next_iteration(self, x, x_prev, x_prev_prev, accuracy):
        return (x - x_prev)**2/abs(2*x_prev - x - x_prev_prev) > accuracy


class SimpleIterationSolver(object):
    MAX_ITERATION = 3000

    def solve(self, interval, a, b, c, accuracy):
        #??????????????? f(x)=0 ? ???? x=fi(x). ?.?. ?????? ???????? x ?? f(x)=0
        fi = self._create_fi(a, b, c)

        #????????? ??????? ??????????
        #??????? ???????????
        #???????, ??????????? ?? ??????? |d(fi(x))/dx| <= q, 0<=q<1
        fi_deriv = fi.deriv()
        conditions, q = self._sufficient_conditions(fi_deriv, interval)

        if conditions == False:
            return {'x': np.nan, 'iteration': 0, 'conditions': conditions}

        x = interval.start.get()
        iteration = 0

        while 1:
            iteration += 1
            x_prev = x

            x = np.polyval(fi, x_prev)
            #????????? ???????? ?? ??? ???, ???? ?? ?????????? ???????
            if (not self._need_do_next_iteration(x, x_prev, q, accuracy, fi_deriv)) or iteration >= SimpleIterationSolver.MAX_ITERATION:
                break

        return {'x': x, 'iteration': iteration, 'conditions': conditions}

    def _create_fi(self, a, b, c):        
        if b != 0:
            w = np.poly1d([-1.0/b, -1.0*a/b, 0, -1.0*c/b])
        else:
            w = np.poly1d([1.0, a, b + 1, c])        
        return w

    def _sufficient_conditions(self, fi_deriv, interval):
        q_max = 0
        result = True
        for elem in np.linspace(interval.start.get(), interval.end.get()):
            q = abs(np.polyval(fi_deriv, elem))
            if q > q_max and q < 1:
                q_max = q
            if q >= 1:
                result = False
                break
        return (result, q_max)

    def _need_do_next_iteration(self, x, x_prev, q, accuracy, w):
        return q/(1-q) * abs(x - x_prev) > accuracy


class NewtonsMethodSolver(object):

    def solve(self, interval, a, b, c, accuracy):
        f = np.poly1d([1, a, b, c])
        f_deriv = f.deriv()
        f_deriv_deriv = f_deriv.deriv()
        suf_cond = self._sufficient_conditions(f, f_deriv, f_deriv_deriv, interval)
        conser_sign = self._conservation_sign(f_deriv, f_deriv_deriv, interval)

        x = self._initialize_x0(conser_sign, interval, f, f_deriv_deriv)
        iteration = 0

        while 1:
            iteration += 1
            x_prev = x
            x = x_prev - np.polyval(f, x_prev)/np.polyval(f_deriv, x_prev)

            if not self._need_do_next_iteration(x, x_prev, accuracy):
                break

        return {'x': x, 'iteration': iteration, 'conditions': suf_cond, 'conservation_sign': conser_sign}

    def _sufficient_conditions(self, f, f_deriv, f_deriv_deriv, interval):
        result = True
        for x in np.linspace(interval.start.get(), interval.end.get()):
            if abs(np.polyval(f, x) * np.polyval(f_deriv_deriv, x)) >= (np.polyval(f_deriv, x)) ** 2:
                result = False
                break
        return result

    def _conservation_sign(self, f_deriv, f_deriv_deriv, interval):
        result = True
        f_deriv_sign = np.sign(np.polyval(f_deriv, interval.start.get()))
        f_deriv_deriv_sign = np.sign(np.polyval(f_deriv_deriv, interval.start.get()))
        for x in np.linspace(interval.start.get(), interval.end.get()):
            if f_deriv_sign != np.sign(np.polyval(f_deriv, x)):
                result = False
                break
            if f_deriv_deriv_sign != np.sign(np.polyval(f_deriv_deriv, x)):
                result = False
                break
        return result

    def _initialize_x0(self, conser_sign, interval, f, f_deriv_deriv):
        x0 = 0
        if conser_sign:
            for x in np.linspace(interval.start.get(), interval.end.get()):
                if np.polyval(f, x) * np.polyval(f_deriv_deriv, x) > 0:
                    x0 = x
                    break
        else:
            x0 = (interval.end.get()-interval.start.get())/2.0

        return x0

    def _need_do_next_iteration(self, x, x_prev, accuracy):
        return abs(x - x_prev) > accuracy


class Application(tk.Frame):
    simple_iteration_solver = SimpleIterationSolver()
    newtons_method_solver = NewtonsMethodSolver()
    chord_method_solver = ChordMethodSolver()

    def _load_test_value(self):
        """self.a.set(-10.2374)
        self.b.set(-91.2105)
        self.c.set(492.560)"""
        """self.a.set(1)
        self.b.set(1)
        self.c.set(1)"""
        self.a.set(-13.3667)
        self.b.set(39.8645)
        self.c.set(-20.6282)
        self.interval.start.set(-10)        
        self.interval.end.set(10)
        self.accuracy.set(0.0001)       

    def __init__(self, master=None):
        tk.Frame.__init__(self, master)
        self.master.wm_protocol("WM_DELETE_WINDOW", lambda: quit())
        master.title("Lab #4")
        master.minsize(650, 550)

        self.a = tk.DoubleVar()
        self.b = tk.DoubleVar()
        self.c = tk.DoubleVar()
        self.interval = Interval()
        self.accuracy = tk.DoubleVar()
        self.roots_count = tk.IntVar()
        self.roots = [Interval(), Interval(), Interval()]
        self.solution = tk.StringVar()
        self.warning = tk.StringVar()

        self._load_test_value()

        self.f = lambda x: x*x*x + x**2 * self.a.get() + x*self.b.get() + self.c.get()

        tk.Label(self.master, text="a = ").place(x=60, y=10)
        tk.Label(self.master, text="b = ").place(x=60, y=32)
        tk.Label(self.master, text="c = ").place(x=60, y=54)
        tk.Label(self.master, text="Interval = ").place(x=20, y=76)
        tk.Label(self.master, text="Accuracy = ").place(x=12, y=98)
        tk.Label(self.master, text="Root count = ").place(x=2, y=170)
        tk.Label(self.master, text="Interval 1 = ").place(x=10, y=192)
        tk.Label(self.master, text="Interval 2 = ").place(x=10, y=216)
        tk.Label(self.master, text="Interval 3 = ").place(x=10, y=238)
        tk.Entry(self.master, width=9, textvariable=self.a).place(x=90, y=10)
        tk.Entry(self.master, width=9, textvariable=self.b).place(x=90, y=32)
        tk.Entry(self.master, width=9, textvariable=self.c).place(x=90, y=54)
        tk.Entry(self.master, width=4, textvariable=self.interval.start).place(x=90, y=76)
        tk.Entry(self.master, width=4, textvariable=self.interval.end).place(x=130, y=76)
        tk.Entry(self.master, width=9, textvariable=self.accuracy).place(x=90, y=98)
        tk.Entry(self.master, width=9, textvariable=self.roots_count, state=tk.DISABLED).place(x=90, y=170)
        tk.Entry(self.master, width=4, textvariable=self.roots[0].start).place(x=90, y=192)
        tk.Entry(self.master, width=4, textvariable=self.roots[0].end).place(x=130, y=192)
        tk.Entry(self.master, width=4, textvariable=self.roots[1].start).place(x=90, y=216)
        tk.Entry(self.master, width=4, textvariable=self.roots[1].end).place(x=130, y=216)
        tk.Entry(self.master, width=4, textvariable=self.roots[2].start).place(x=90, y=238)
        tk.Entry(self.master, width=4, textvariable=self.roots[2].end).place(x=130, y=238)

        tk.Button(self.master, text="Draw f(x)", width=20, command=self.draw).place(x=10, y=125)
        tk.Button(self.master, text="Method simple iteration", width=20, command=self.solve_simple_iteration).place(x=10, y=265)
        tk.Button(self.master, text="Newton's method", width=20, command=self.solve_newtons_method).place(x=10, y=300)
        tk.Button(self.master, text="Chord method", width=20, command=self.chord_method).place(x=10, y=335)

        tk.Label(self.master, fg='red', textvariable=self.warning).place(x=200, y=300)
        tk.Label(self.master, textvariable=self.solution, anchor=tk.W, justify=tk.LEFT).place(x=200, y=330)

        self.figure = plot.figure()
        self.canvas = FigureCanvasTkAgg(self.figure, master=self.master)
        self.canvas.show()
        self.toolbar = NavigationToolbar2TkAgg(self.canvas, self.master)
        self.toolbar.update()
        self.toolbar.place(x=200, y=260)
        self.canvas._tkcanvas.place(x=200, y=10, height=250, width=400)
        self.canvas._tkcanvas.config(background='white', borderwidth=0, highlightthickness=0)
        self.canvas.draw()

    #????????? ??????? ???????
    def draw(self):
        self.figure.clear()
        art = self.figure.add_subplot(111)
        x = np.linspace(self.interval.start.get(), self.interval.end.get())
        y = [self.f(xi) for xi in x]
        art.plot(x, y)
        art.axhline(0, color='black')
        art.axvline(0, color='black')
        self.canvas.show()

        roots = self.compute_number_of_roots()
        self.roots_count.set(roots)

        #???????? ?????????, ??? ????????? ????? ?????????
        #????? ??????? ???????? ?? ??????
        self.roots[0].start.set(0)
        self.roots[0].end.set(1)
        self.roots[1].start.set(3.38)
        self.roots[1].end.set(4.1)
        self.roots[2].start.set(8)
        self.roots[2].end.set(10)

    #?????????? ??????? ??????
    def compute_number_of_roots(self):
        pol1 = np.poly1d([1, self.a.get(), self.b.get(), self.c.get()])

        #deriv ??????? ???????????
        sturm_series = [pol1, pol1.deriv()]
        i = 1
        while 1:
            #??????? ??????? ? ??????? ?? ??????? ???????? ?? ???????
            q, r = np.polydiv(sturm_series[i-1], sturm_series[i])
            #???? ? ??????? ????????? ???? ????? ??? ??????? ???, ?? ??????
            #? ?????? ?????????? ???. ??? ? ??? ?????? ?? ?????????
            if r.order == 0 and r.coeffs[0] == 0:
                break
            sturm_series.append(np.polymul(r, -1))
            i += 1

        n_a = []
        n_b = []
        #??????????? ? ?????? ??????? ???? ?????? ???????? ?????? ? ????? ?????????
        for elem in sturm_series:
            n_a.append(np.polyval(elem, self.interval.start.get()))
            n_b.append(np.polyval(elem, self.interval.end.get()))

        #??????? ???????? ???? ?????? ? ?????
        #??? ????? ????? ?????????? ????????? ????? ? ???????
        n_a_signs = self._number_of_signs(n_a)
        n_b_signs = self._number_of_signs(n_b)

        return n_a_signs - n_b_signs

    def _number_of_signs(self, poly):
        signs = 0
        prev_sign = np.sign(poly[0])
        for elem in poly:
            cur_sign = np.sign(elem)
            if cur_sign != prev_sign:
                signs += 1
                prev_sign = cur_sign
        return signs


    def solve_simple_iteration(self):
        self._hide_solution()
        self._hide_warning()

        if self.roots_count.get() <= 0:
            self._show_warning('Number of roots is 0')
            return

        result = 'Simple iteration method\n\n'

        solution = Application.simple_iteration_solver.solve(self.roots[0], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 1')

        if self.roots_count.get() == 1:
            self._show_solution(result)
            return

        solution = Application.simple_iteration_solver.solve(self.roots[1], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 2')

        if self.roots_count.get() == 2:
            self._show_solution(result)
            return

        solution = Application.simple_iteration_solver.solve(self.roots[2], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 3')

        self._show_solution(result)

    def solve_newtons_method(self):
        self._hide_solution()
        self._hide_warning()

        if self.roots_count.get() <= 0:
            self._show_warning('Number of roots is 0')
            return

        result = "Newton's method\n\n"

        solution = Application.newtons_method_solver.solve(self.roots[0], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 1')

        if self.roots_count.get() == 1:
            self._show_solution(result)
            return

        solution = Application.newtons_method_solver.solve(self.roots[1], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 2')

        if self.roots_count.get() == 2:
            self._show_solution(result)
            return

        solution = Application.newtons_method_solver.solve(self.roots[2], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 3')

        self._show_solution(result)

    def chord_method(self):
        self._hide_solution()
        self._hide_warning()

        if self.roots_count.get() <= 0:
            self._show_warning('Number of roots is 0')
            return

        result = "Chord method\n\n"

        solution = Application.chord_method_solver.solve(self.roots[0], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 1')

        if self.roots_count.get() == 1:
            self._show_solution(result)
            return

        solution = Application.chord_method_solver.solve(self.roots[1], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 2')

        if self.roots_count.get() == 2:
            self._show_solution(result)
            return

        solution = Application.chord_method_solver.solve(self.roots[2], self.a.get(), self.b.get(), self.c.get(), self.accuracy.get())
        result += self._solution_to_string(solution, 'INTERVAL 3')

        self._show_solution(result)

    def print_f(self):
        return 'x*x*x + x**2 * ' + str(self.a.get()) + ' + x * ' + str(self.b.get()) + ' + ' + str(self.c.get())

    
    def _show_warning(self, message):
        self.warning.set(message)

    def _hide_warning(self):
        self.warning.set("")

    def _show_solution(self, message):
        self.solution.set(message)

    def _hide_solution(self):
        self.solution.set("")

    def _solution_to_string(self, solution, message=''):
        result = message + '\n'
        result += "Sufficient conditions are not met\n" if not solution.get('conditions', True) else ''
        result += "Sign is not preserved\n" if not solution.get('conservation_sign', True) else ''
        result += "Iteration = {}\n".format(solution.get('iteration')) if 'iteration' in solution else ''
        result += "X = {}\n\n".format(solution.get('x')) if 'x' in solution else ''

        return result


def quit():
    root.quit()
    root.destroy()

root = tk.Tk()
app = Application(root)
app.mainloop()
