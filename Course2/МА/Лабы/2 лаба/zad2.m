%Задание 2. Найти решение ДУ Бернулли.
%Построить график интегральных кривых
%2xyy' - y^2 + x = 0
syms x y Ur Title x_new y_new Expr Message1
Ur = '(y^2 - x)/(2*x*y)';
Expr= ['Dy = ', char (Ur)];
y=dsolve(Expr, 'x');
y1 = y(1);
y2 = y(2);
fprintf('y1 = ');
pretty(simplify(y1));
fprintf('y2 = ');
pretty(simplify(y2));
Message1 = ['y=',char(y1)];
Message2 = ['y=',char(y2)];
hold on; grid on;
xlabel ('ось X');
ylabel ('ось Y');
x_new = -10:0.1:10;
y1=subs(y1, 'x', x_new);
y2=subs(y2, 'x', x_new);
for val = -6:1:6 
    y1_new= subs(y1,val); 
    plot(x_new, y1_new, '-black');
    y2_new = subs(y2, val);
    plot(x_new, y2_new, '-red');    
end;
Title = ['Интегральные кривые уравнения: ',char(Expr)];
title(char(Title));
legend(char(Message1), char(Message2));
%Ответ: y1 = (x*(C - ln(x)))^1/2
%       y2 = -(x*(C - ln(x)))^1/2