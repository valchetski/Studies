 syms n x ao an bn f1 f2 cn
l=pi;
f2=exp(2*x+1);
a0=(int(f2,x,-pi,pi))/(2*l);
an=(1/l)*(int(f2*cos(n*x),x,-pi,pi));
bn=(1/l)*(int(f2*sin(n*x),x,-pi,pi));
disp(an);
disp(bn);
disp(a0);
x=-pi:pi/32:pi;
sum5=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,5),x));
sum50=double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,50),x));
disp(sum5);
hold on;
grid on;
plot(x,sum5,'g');
plot(x,sum50,'b');
title('y=exp(-x)');
legend('sum5','sum50');
cn=(bn^2+an^2)^(1/2);
w=0:1:15;
subplot(2,1,1);
hold on;
grid on;
stem(w,subs(abs(cn),'n',w),'.');
plot(w,subs(abs(cn),'n',w));
title('Spectrum of amplitudes')
xlabel('k');
ylabel('|Ck|');
phi=atan(subs(bn/an,w));
subplot(2,1,2);
hold on;
grid on;
stem(w,phi,'.');
plot(w,phi);
title('Frequency-phase spectrum');
xlabel('k');
ylabel('arg(Ck)');
