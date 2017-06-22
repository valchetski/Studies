% Задание 2. Уравнение Бернулли.
% y' + y = 3 * exp(-2 * x) * y ^ 2

syms x y Ur Title % инициализация символьных переменных
syms x_new y_new Expr Message

assume(x, 'real'); % полагаем x и y действительными числами
assume(y, 'real');

Ur = '3 * exp(-2 * x) * y^2 - y'; % задан. прав. части уравнен.
Expr = ['Dy = ', char(Ur)]; % формирование дифффер. уравнения

y = dsolve(Expr, 'x'); % решение дифференциального уравнения

y2=y(2);
fprintf('y = ');
Message1 = ['y=', char(y(1))];
Message2 = ['y=', char(y(2))];

pretty(simplify(y)); % печать решения уравнения

grid on; hold on; % включаем координатную сетку

xlabel('X axis'); % подписываем ось OX
ylabel('Y axis'); % подписываем ось OY

x_new = 2:0.1:10; % формируем сетку значений аргументов
y2 = subs(y2, 'x', x_new); % подставляем аргументы

ylim([-0.5 0.5]);
y1=y(1);
for cycle = -2:0.1:2 % варьируем значения произв. константы
    val = cycle;
    y_new = subs(y2, val); % подставляем константу
    plot(x_new, y_new); % прорисовка интегральной кривой 
    plot(x_new, y1);
end;

Title = ['Integral Curves of Equation: ', char(Expr)];
title(char(Title)); % титульная надпись графика
legend(char(Message1), char(Message2)); % легенда графика