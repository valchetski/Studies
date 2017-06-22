%Область сходимости по мажорирующему ряду
%Ряд: (x+5)^n/(n^2) n=1,2...
hold on;
syms x s eps N
eps = 0.1;
N = 5; %на 9 уже выходит из области
s = 0;
assume(x,'rational');
x = -1/2:1/10:1/2;

plot(x,Sum1(x,1,inf)+eps,'-.r');
plot(x,Sum1(x,1,inf)-eps,'-.r');
plot(x,Sum1(x,1,inf),'-*k');
for i = 1 : 5
    plot(x,Sum1(x,1,N),'-.b');
    N = N + 1;
end;