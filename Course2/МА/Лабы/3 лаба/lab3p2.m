syms n x ao an bn cn
f = exp(2*x+1);
a0 = (int(f,x,-pi,pi))/(2*pi);
an = (1/pi)*(int(f*cos(n*x),x,-pi,pi));
bn = (1/pi)*(int(f*sin(n*x),x,-pi,pi));
x = -pi : pi/32 : pi;
sum5=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,5),x));
%sum20=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,20),x));
%sum50=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,50),x));
%disp(sum5);
subplot(3,1,1);
hold on; grid on;
title('sum5');
plot(x, sum5);

subplot(3,1,2);
hold on; grid on;
title('sum20');
plot(x, sum20);

subplot(3,1,3);
hold on; grid on;
title('sum50');
plot(x, sum50);