syms x y Ur Title z
syms x_new y_new Expr Message
Ur = '(1/y*exp(x)+y)/2';
Expr= ['Dy = ', char (Ur)];
y=dsolve(Expr, 'x')
fprintf('y= ');
Message = ['y=',char(y(1,1)),];
pretty(simplify(y(1,1)));
xlabel ('X axis');
ylabel ('Y axis');
x_new = -5:0.1:5;
y=subs(y(1,1), 'x', x_new);
for cycle = 0:1:5
    val=cycle;
    y_new= subs(y, 'C5', val);
    hold on; grid on;
    subplot(2,1,1);plot(x_new, y_new);
    subplot (2,1,1);plot(x_new,0)
end;
 
Title = ['Integral Curves of Equation: ',char(Expr)];
title(char(Title));
legend(char(Message));
 

