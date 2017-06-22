syms x y Ur Title z
syms x_new y_new Expr Message
Ur = '-y^2-y/(x+1)';
Expr= ['Dy = ', char (Ur)];
y=dsolve(Expr, 'x');
fprintf('y= ');
Message = ['y=',char(y(2,1)),'; y=0'];
pretty(simplify(y));
xlabel ('X axis');
ylabel ('Y axis');
x_new = 0:0.1:10;
dy=char(y(2,1));
y=subs(y(2,1), 'x', x_new);
for cycle = 1:1:5
    val=cycle;
    y_new= subs(y, val);
    hold on; grid on;
    plot(x_new, y_new);
    plot(x_new,0)
end;

Title = ['Integral Curves of Equation: ',char(Expr)];
title(char(Title));
legend(char(Message));
