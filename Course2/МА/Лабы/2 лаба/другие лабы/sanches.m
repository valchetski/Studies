syms x y Ur Title z
syms x_new y_new Expr Message
Ur = '(y^2)*cos(x)+y*cos(x)';
Expr= ['Dy = ', char (Ur)];
y=dsolve(Expr, 'x');
fprintf('y= ');
Message = ['y=',char(y(3,1)),'; y=0'];
pretty(simplify(y));
xlabel ('X axis');
ylabel ('Y axis');
x_new = 0:0.1:2;
dy=char(y(3,1));
disp(dy);
y=subs(y(3,1), 'x', x_new);
%axis ([0 12 0 500 ])
for cycle = 0:0.01:0.1
val=cycle;
y_new= subs(y, 'C88', val);
hold on; grid on;
subplot(2,1,1);plot(x_new, y_new);
subplot (2,1,1);plot(x_new,0);
end;

Title = ['Integral Curves of Equation: ',char(Expr)];
title(char(Title));
legend(char(Message));