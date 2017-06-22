clf;
syms x y Ur Title
syms x_new y_new Expr Message
Ur = '-x*y';
Expr= ['Dy = ', char (Ur)];
y=dsolve(Expr,'x');
fprintf('y= ');
Message = ['y=',char(y)];
pretty(simplify(y));
xlabel ('X axis');
ylabel ('Y axis');
x_new = -10:0.1:10;
dy=char(y);
disp (dy);
y=subs(y, 'x', x_new);

for cycle = -5:1:5
    val=cycle;
    y_new= subs(y, val);
    grid on;hold on;
    plot(x_new, y_new);
end;
Title = ['Integral Curves of Equation: ',char(Expr)];
title(char(Title));
legend(char(Message));