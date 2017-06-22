 syms n x ao an bn f1 f2 cn
l=pi;
f2=exp(2*x+1);
fd = (2*l);
a0=(int(f2,x,-pi,pi))/(2*l);
an=(1/l)*(int(f2*cos(n*x),x,-pi,pi));
bn=(1/l)*(int(f2*sin(n*x),x,-pi,pi));
disp(an);
disp(bn);
disp(a0);
x=-pi:pi/32:pi;
sum5=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,5),x));
sum20=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,20),x));
sum50=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,50),x));
hold on; grid on;
plot(x,sum50,'b');