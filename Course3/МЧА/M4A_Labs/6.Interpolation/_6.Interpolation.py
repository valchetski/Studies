from interpolation import *
from interpolation.helper import poly as polyhl



import numpy as np
import sympy as sp
import matplotlib.pyplot as plot
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg, NavigationToolbar2TkAgg
import Tkinter as tk


class Interval(object):

    def __init__(self):
        self.start = tk.DoubleVar()
        self.end = tk.DoubleVar()


class Application(tk.Frame):

    def __load_test_value(self):
        self.interval.start.set(0.1)
        self.interval.end.set(1.5)
        self.n.set(6)
        self.f = lambda x: np.tan(x)#1/x

        self.x_values = np.linspace(self.interval.start.get(), self.interval.end.get(), num=self.n.get()+1)
        self.y_values = [self.f(x) for x in self.x_values]

    def __init__(self, master=None):
        tk.Frame.__init__(self, master)
        self.master.wm_protocol("WM_DELETE_WINDOW", lambda: quit())
        master.title("6. Interpolation")
        master.minsize(650, 700)

        self.n = tk.IntVar()
        self.interval = Interval()
        self.warning = tk.StringVar()
        self.solution = tk.StringVar()
        self.info = tk.StringVar()

        self.__load_test_value()

        tk.Label(self.master, text="f(x) = tg(x)").place(x=50, y=10)
        tk.Label(self.master, text="Interval = ").place(x=30, y=30)
        tk.Label(self.master, text="N = ").place(x=60, y=52)
        tk.Entry(self.master, width=4, textvariable=self.interval.start).place(x=90, y=30)
        tk.Entry(self.master, width=4, textvariable=self.interval.end).place(x=125, y=30)
        tk.Entry(self.master, width=10, textvariable=self.n).place(x=90, y=52)

        tk.Button(self.master, text="Lagrange polynomial", width=20, command=self.lagrange_interpolation).place(x=10, y=100)
        tk.Button(self.master, text="Newton polynomial", width=20, command=self.newton_interpolation).place(x=10, y=130)
        tk.Button(self.master, text="Cubic splines", width=20, command=self.spline_interpolation).place(x=10, y=160)

        tk.Label(self.master, fg='red', textvariable=self.warning, anchor=tk.W, justify=tk.LEFT).place(x=200, y=300)
        tk.Label(self.master, textvariable=self.solution, anchor=tk.W, justify=tk.LEFT, wraplength=450).place(x=200, y=330)
        tk.Label(self.master, textvariable=self.info, anchor=tk.W, justify=tk.LEFT, wraplength=450).place(x=650, y=10)

        self.figure = plot.figure()
        self.canvas = FigureCanvasTkAgg(self.figure, master=self.master)
        self.canvas.show()
        self.toolbar = NavigationToolbar2TkAgg(self.canvas, self.master)
        self.toolbar.update()
        self.toolbar.place(x=200, y=260)
        self.canvas._tkcanvas.place(x=200, y=10, height=250, width=400)
        self.canvas._tkcanvas.config(background='white', borderwidth=0, highlightthickness=0)
        self.canvas.draw()

    def lagrange_interpolation(self):
        self._hide_solution()
        self._hide_warning()
        self.info.set('')

        l = Lagrange().interpolate(self.x_values, self.y_values)
        l_stand = polyhl.poly_to_string(l)
        l_norm = Lagrange.last_poly_to_string

        result = 'Lagrange interpolation polynomial\n\nL(x) = ' + l_norm + '\n= ' + l_stand

        x0 = (self.interval.end.get() + self.interval.start.get())*0.5
        l_x0 = np.polyval(l, x0)
        f_x0 = self.f(x0)
        result += '\n\nx0 = 0.5*(b-a) = {}\nf(x0) = {}\nL(x0) = {}'.format(x0, f_x0, l_x0)

        err = self.discretely_practical_error(l)
        result += '\n\nDiscretely practical error = {}'.format(err)

        err = self.discretely_theoretical_error()
        #result += '\nDiscretely theoretical error = {}'.format(err)

        self._draw_plots(l, 'L(x)')
        self._show_solution(result)

    def newton_interpolation(self):
        self._hide_solution()
        self._hide_warning()

        l = Newton.interpolate(self.x_values, self.y_values)
        l_stand = polyhl.poly_to_string(l)
        l_norm = Newton.to_string(l, self.y_values[0], self.x_values)

        result = 'Newton interpolation polynomial\n\nN(x) = ' + l_norm + '\n= ' + l_stand

        table = 'Table of divided differences:\n'
        for key in sorted(Newton.cache.keys()):
            table += '{}, f(...) = {}\n'.format(key, Newton.cache.get(key))
        self.info.set(table)

        x0 = (self.interval.end.get() + self.interval.start.get())*0.5
        l_x0 = np.polyval(l, x0)
        f_x0 = self.f(x0)
        result += '\n\nx0 = {}\nf(x0) = {}\nN(x0) = {}'.format(x0, f_x0, l_x0)

        err = self.discretely_practical_error(l)
        result += '\n\nDiscretely practical error = {}'.format(err)

        err = self.discretely_theoretical_error_newton()
        result += '\nDiscretely theoretical error = {}'.format(err)

        self._draw_plots(l, 'N(x)')
        self._show_solution(result)

    def spline_interpolation(self):
        self._hide_solution()
        self._hide_warning()
        self.info.set('')

        cs = CubicSpline(self.x_values, self.y_values)
        l_norm = CubicSpline.to_string()

        result = 'Cubic spline interpolation polynomial\n\n' + l_norm

        x0 = (self.interval.end.get() + self.interval.start.get())*0.5
        l_x0 = CubicSpline.interpolate(x0)
        f_x0 = self.f(x0)
        result += '\n\nx0 = 0.5*(b-a) = {}\nf(x0) = {}\nS(x0) = {}'.format(x0, f_x0, l_x0)

        err = self.discretely_practical_error_cubic_spline()
        result += '\n\nDiscretely practical error = {}'.format(err)

        self._draw_plots_cs('S(x)')
        self._show_solution(result)

    def _draw_plots(self, poly, title='interpolation'):
        self.figure.clear()
        art = self.figure.add_subplot(111)
        x = np.linspace(self.interval.start.get(), self.interval.end.get(), num=self.n.get()+1)
        y = [self.f(xi) for xi in x]
        art.plot(x, y, '--o--', color='blue', linewidth=2, label='f(x)')
        y = [np.polyval(poly, xi) for xi in x]
        art.plot(x, y, color='red', label=title)

        art.legend(loc=1, borderaxespad=0.)
        self.canvas.show()

    def _draw_plots_cs(self, title='interpolation'):
        self.figure.clear()
        art = self.figure.add_subplot(111)
        x = np.linspace(self.interval.start.get(), self.interval.end.get(), num=self.n.get()+1)
        y = [self.f(xi) for xi in x]
        art.plot(x, y, '--o--', color='blue', linewidth=2, label='f(x)')
        y = [CubicSpline.interpolate(xi) for xi in x]
        art.plot(x, y, color='red', label=title)

        art.legend(loc=1, borderaxespad=0.)
        self.canvas.show()

    def _show_warning(self, message):
        self.warning.set(message)

    def _hide_warning(self):
        self.warning.set("")

    def _show_solution(self, message):
        self.solution.set(message)

    def _hide_solution(self):
        self.solution.set("")

    def discretely_practical_error(self, poly):
        m = 0
        for x in np.linspace(self.interval.start.get(), self.interval.end.get()):
            i = abs(self.f(x) - np.polyval(poly, x))
            if i > m:
                m = i
        return m

    def discretely_practical_error_cubic_spline(self):
        m = 0
        for x in np.linspace(self.interval.start.get(), self.interval.end.get()):
            i = abs(self.f(x) - CubicSpline.interpolate(x))
            if i > m:
                m = i
        return m

    def discretely_theoretical_error(self):
        w = np.poly1d(1)
        for x in self.x_values:
            w = np.polymul(w, np.poly1d([1, -x]))

        x = sp.Symbol('x')
        f_der = sp.diff(1/x, x, 7)
        

        f_der_m = 0
        w_m = 0
        for xi in np.linspace(self.interval.start.get(), self.interval.end.get()):
            w_i = abs(np.polyval(w, xi))
            if w_i > w_m:
                w_m = w_i
            f_der_i = abs(f_der.evalf(subs={x: xi}))
            if f_der_i > f_der_m:
                f_der_m = f_der_i

        return float(f_der_m*w_m/5040)

    def discretely_theoretical_error_newton(self):
        w = np.poly1d(1)
        for x in self.x_values:
            w = np.polymul(w, np.poly1d([1, -x]))

        r_m = 0
        for i, xi in enumerate(np.linspace(self.interval.start.get(), self.interval.end.get())):
            w_i = np.polyval(w, xi)
            f_i = Newton._Newton__f_sub([i, 0, 1, 2, 3, 4, 5, 6], self.x_values)
            r_i = abs(w_i*f_i)
            if r_i > r_m:
                r_m = r_i
        return r_m


def quit():
    root.quit()
    root.destroy()

root = tk.Tk()
app = Application(root)
app.mainloop()