%Задание 3. Найти решение ДУ 2-го порядка.
%Построить график интегральных кривых
%y'' + 9y = cos(2x)
syms x y Ur Title x_new y_new DU Message;
Ur = 'cos(2*x) - 9*y';
DU = ['D2y = ', char(Ur)]; 
y = dsolve(DU, 'x');
y = simplify(y);
fprintf('y = ');
pretty(y); 
grid on; hold on; 
xlabel('ось X'); 
ylabel('ось Y'); 
Title = ['Интегральные кривые уравнения: ', char(DU)];
title(char(Title)); 
Message = ['y=', char(y)]; 
x_new = -10:0.1:10; 
y = subs(y, x, x_new); 
for cycle1 = 1 : 1 : 5 
    y_new = subs(y, cycle1); 
    for cycle2 =  1 : 1 : 5
        y_new = subs(y_new, cycle2);
        plot(x_new, y_new);
    end;
end;
legend(char(Message)); % легенда графика
%Ответ: y = C1*cos(3*x) + C2*sin(3x) + (1/5)*cos(2x)