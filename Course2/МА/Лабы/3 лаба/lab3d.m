syms n x ao an bn f1 f2 cn
f = x^2+x;
a0 = (1/(2*pi))*(int(f,x,-pi,pi));
an = (1/pi)*(int(f*cos(n*x),x,-pi,pi));
bn = (1/pi)*(int(f*sin(n*x),x,-pi,pi));
fprintf('a0 = %s\n', char(a0));
fprintf('an = %s\n', char(an));
fprintf('bn = %s\n', char(bn));
x = -pi : pi/32 : pi;

title('y=exp(2x + 1)');
cn=(bn^2+an^2)^(1/2);
w=0:1:15;
subplot(2,1,1);
hold on; grid on;
stem(w,subs(abs(cn),'n',w),'.');
plot(w,subs(abs(cn),'n',w));
title('Spectrum of amplitudes')

xlabel('k');
ylabel('|Ck|');
phi=atan(subs(bn/an,w));
subplot(2,1,2);
hold on; grid on;
stem(w,phi,'.');
plot(w,phi);
title('Frequency-phase spectrum');
xlabel('k');
ylabel('arg(Ck)');