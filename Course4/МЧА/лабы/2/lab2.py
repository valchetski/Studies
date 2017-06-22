import numpy as np
import matplotlib.pyplot as plt
from matplotlib import animation

class Program:
    def __init__(self, a, b, k, T, fi, g1, g2, f):
        self.fi = fi
        self.g1 = g1
        self.g2 = g2
        self.f = f
        self.x, self.h = self.__get_x_h(a, b)
        self.t, self.taw = self.__get_t_raw(a, b, k, T)
        self.__init_table_pattern()

    def solve(self):
        for index_t in range(1, len(self.t)):
            row = []
            for index_x in range(len(self.x)):
                if (index_x == 0):
                    row.append(self.__get_g1(self.t[index_t]))
                    continue
                if (index_x == len(self.x)-1):
                    row.append(self.__get_g1(self.t[index_t]))
                    continue
                y = 0
                y += self.taw/(self.h**2)*self.table_pattern[index_t-1][index_x-1]
                y += (1-2*self.taw/(self.h**2))*self.table_pattern[index_t-1][index_x]
                y += self.taw/(self.h**2)*self.table_pattern[index_t-1][index_x+1]
                y += self.taw*self.__get_f(self.x[index_x], self.t[index_t])
                row.append(round(y, 5))
            self.table_pattern.append(row)


    def __init_table_pattern(self):
        self.table_pattern = [[0]*len(self.x)]
        self.table_pattern[0][0] = self.__get_g1(self.t[0])
        self.table_pattern[0][-1] = self.__get_g2(self.t[-1])
        for index in range(1, len(self.x)-1):
            self.table_pattern[0][index] = self.__get_fi(self.x[index])

    def __get_f(self, x, t):
        return eval(self.f)

    def __get_fi(self, x):
        return eval(self.fi)

    def __get_g1(self, t):
        return eval(self.g1)

    def __get_g2(self, t):
        return eval(self.g2)

    def __get_x_h(self, a, b):
        h = (b-a)/10.0
        value = a
        x = []
        while value<=b:
            x.append(round(value, 5))
            value += h
        return x, h

    def __get_t_raw(self, a, b, k, T):
        taw = ((b-a)/10.0)**2/k/128
        t = []
        value = 0
        while value <= T+2*taw:
            t.append(round(value, 5))
            value += 2*taw
        return t, taw


class PlotHandler:
    def __init__(self, x, rows):
        self.x = x
        self.rows = rows

    def draw(self):
        fig = plt.figure()
        ax = plt.axes(xlim=(0, 2), ylim=(0, .2))
        line, = ax.plot([], [], lw=5)
        time_text = ax.text(0.05, 0.9, '', transform=ax.transAxes)

        def init():
            line.set_data([], [])
            time_text.set_text('')
            return line, time_text

        def animate(i):
            i = i%len(self.rows)
            x = self.x
            y = self.rows[i]
            line.set_data(x, y)
            time_text.set_text("Frame %d"%i)
            return line, time_text

        anim = animation.FuncAnimation(fig, animate, init_func=init, frames=len(self.rows), interval=1000, blit=True)
        plt.show()


#program = Program(-1, 1, 0.5, 0.9, "1+x**2", "0", "t", "x**2")
program = Program(0, 2, 4, 0.9, "0", "0", "10*t**2", "1")
program.solve()
plotHandler = PlotHandler(program.x, program.table_pattern)
plotHandler.draw()


