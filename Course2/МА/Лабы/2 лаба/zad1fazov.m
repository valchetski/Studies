%Задание 1. Фазовый портрет
%y' + sin(x-y) = sin(x+y)
syms x y Ur Title x_new y_new DU Message;
Ur = 'sin(x+y) - sin(x-y)';
DU = ['Dy = ', char(Ur)]; % формирование дифффер. уравнения
y = dsolve(DU, 'x'); % решение дифференциального уравнения
y = y(2);
fprintf('y = ');
pretty(simplify(y)); % печать решения уравнения
y_derivative = diff(y);
pretty(simplify(y_derivative));
grid on; hold on; % включаем координатную сетку
xlabel('ось Y'); % подписываем ось OX
ylabel('ось Y'''); % подписываем ось OY
Message = ['y=', char(y)]; % надпись для легенды графика
x_new = -10:0.1:10; % формируем сетку значений аргументов
y = subs(y, x, x_new); % подставляем аргументы 
y_derivative = subs(y_derivative, x, x_new); % подставляем аргументы
for cycle = -4 : 1: 4
    y_new = subs(y, cycle); % подставляем константу  
    y_new_derivative = subs(y_derivative, cycle);
    plot(y_new, y_new_derivative);
end;

legend(char(Message)); % легенда графика
%Ответ: y = 2*atan(exp(C5 + 2*sin(x)))