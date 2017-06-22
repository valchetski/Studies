clf;
syms x y Ur Title; % инициализация символьных переменных
syms x_new y_new Expr Message;
%Ur = '-(x * y) / sqrt(1 + x^2)'; % задан. прав. части уравнен.
%Ur = '-(1+y^2)/(1+x^2)'; % задан. прав. части уравнен.
%Ur = '1+x';
%Ur = '(3*x*(2+y^2))/((x^2 + 3)*2*y)';
%Ur = 'sin(x+y) - sin(x-y)';
Ur = 'sin(x-y)';
Expr = ['Dy = ', char(Ur)]; % формирование дифффер. уравнения
y = dsolve(Expr, 'x'); % решение дифференциального уравнения
%y = y(2);
fprintf('y = ');
Message = ['y=', char(y)];
pretty(simplify(y)); % печать решения уравнения
grid on; hold on; % включаем координатную сетку
xlabel('X axis'); % подписываем ось OX
ylabel('Y axis'); % подписываем ось OY
x_new = -10:0.1:10; % формируем сетку значений аргументов
y = subs(y, x, x_new); % подставляем аргументы
axis([0 3 0 4]);
for cycle = -5 : 1 : 5 % варьируем значения произв. константы
    val = cycle;    
    y_new = subs(y, 'C22', val); % подставляем константу
    %plot(x_new, y_new); % прорисовка интегральной кривой
    plot(x_new, y_new);
end;
Title = ['Integral Curves of Equation: ', char(Expr)];
title(char(Title)); % титульная надпись графика
legend(char(Message)); % легенда графика