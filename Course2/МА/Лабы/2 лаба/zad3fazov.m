%Задание 3. Фазовый портрет
%y'' + 9y = cos(2x)
syms x y Ur Title x_new y_new DU Message;
Ur = 'cos(2*x) - 9*y';
DU = ['D2y = ', char(Ur)]; 
y = dsolve(DU, 'x'); 
y = simplify(y);
y_derivative = diff(y);
grid on; hold on; 
xlabel('ось Y');
ylabel('ось Y'''); 
Message = ['y=', char(y)]; 
x_new = -15:0.1:15; 

y = subs(y, x, x_new);
y_derivative = subs(y_derivative, x, x_new);
y_new = subs(y, 1);  
y_new_derivative = subs(y_derivative, 1);    
y_new = subs(y_new, 0);
y_new_derivative = subs(y_new_derivative, 0);
plot(y_new, y_new_derivative);  
legend(char(Message)); 