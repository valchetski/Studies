%Область сходимости по мажорирующему ряду
%Ряд: (x+5)^n/(n^2) n=1,2...
hold on;
syms x eps N
eps = 0.1;
N = 4; %на 9 уже выходит из области
assume(x,'rational');
x = -1:1/10:3;
an = ((x - 1).^(2*n))/(n*9^n);
symsum(an, n, 1, inf)
plot(x,symsum(an, n, 1, inf)+eps,'-r');
plot(x,symsum(an, n, 1, inf)-eps,'-.r');
plot(x,symsum(an, n, 1, inf),'-*k');
for i = 1 : 5
    plot(x,symsum(an, n, 1, N),'-.b');
    N = N + 1;
end;