%Область сходимости по мажорирующему ряду
%Ряд: (x+5)^n/(n^2) n=1,2...
hold on;
syms x s eps N an n
eps = 0.1;
N = 3; %на 9 уже выходит из области
s = 0;
assume(x,'rational');
x = 0:1/10:2;
an = (((x+1).^(1/2))*cos(x*n))/((n^5+1)^(1/3));
plot(x, symsum(an,n,1,inf)+eps,'-.r');
plot(x,symsum(an,n,1,inf)-eps,'-.r');
plot(x,symsum(an,n,1,inf),'-*k');
for i = 1 : 5
    plot(x,symsum(an,n,1,N),'-.b');
    N = N + 1;
end;