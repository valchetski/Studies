syms x y Ur Title z
syms x_new y_new Expr Message
Ur = '(x^2*y^(1/2)+4*y)/x';
Expr= ['Dy = ', char (Ur)];
y=dsolve(Expr, 'x');
fprintf('y= ');
y = y(2);
Message = ['y=',char(y),'; y=0'];
pretty(simplify(y));
xlabel ('X axis');
ylabel ('Y axis');
x_new = -1:0.1:5;
dy=char(y);
disp(dy);
y=subs(y, 'x', x_new);
for cycle = 0:1:5
val=cycle;
y_new= subs(y, 'C5', val);
hold on; grid on;
subplot(2,1,1);plot(x_new, y_new);
subplot (2,1,1);plot(x_new,0);
end;

Title = ['Integral Curves of Equation: ',char(Expr)];
title(char(Title));
legend(char(Message));