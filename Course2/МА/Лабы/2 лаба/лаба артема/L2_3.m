syms x y Ex1 Ex2
Ex1='D2y+y=1/cos(x)';
y=dsolve(Ex1,'x');
dy=char(y);
Message = ['y=',char(y)];
pretty(simplify(y));
xlabel ('X axis');
ylabel ('Y axis');
x_new = -8:0.1:8;
y=subs(char(y), 'x', x_new);
for cycle = 0:1:5
    val=cycle;
    y_new= subs(y, val);
    hold on; grid on;
    subplot(2,1,1);plot(x_new, subs(y_new,val+1));
end;

Title = ['Integral Curves of Equation: ',char(Ex1)];
title(char(Title));
xlabel ('X axis');
ylabel ('Y axis');
legend(Message);
dy=diff(sym(dy));
disp(dy);
dy=subs(dy,'x',x_new);
for cycle = 0:1:0
    val=cycle;
    y_new= subs(y, val);
    dz=subs(dy,val);
    hold on; grid on;
   subplot(2,1,2);plot3(subs(y_new,val),subs(dz,val),x_new);
   hold on; grid on;
   %surfc(subs(y_new,val),subs(dz,val),x_new)
  
end;
title('Portret of Fases');
xlabel ('Y axis');
ylabel ('DY axis');