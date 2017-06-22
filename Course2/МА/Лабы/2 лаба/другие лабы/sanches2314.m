


clf;
 syms x y Ur Title % инициализация символьных переменных
 syms x_new y_new Expr Message
 Ur = 'y*cos(x)/sin(x)'; 
 Expr = ['Dy = ', char(Ur)]; 
 y = dsolve(Expr, 'x'); % решение дифференциального уравнения
 y = y(1);
 fprintf('y = ');
 Message = ['y=', char(y)];
 pretty(simplify(y)); % печать решения уравнения
 grid on; hold on; % включаем координатную сетку
 xlabel('X axis'); % подписываем ось OX
 ylabel('Y axis'); % подписываем ось OY
 x_new = -10:0.1:10; % формируем сетку значений аргументов
 y = subs(y, 'x', x_new); % подставляем аргументы

 for cycle = 0 : 1 : 5 % варьируем значения произв. константы
 val = cycle;
 y_new = subs(y, 'C91', val); % подставляем константу
 plot(x_new, y_new); % прорисовка интегральной кривой
 end;
 Title = ['Integral Curves of Equation: ', char(Expr)];
 title(char(Title)); % титульная надпись графика
 legend(char(Message)); % легенда графика