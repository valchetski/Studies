%Область сходимости по мажорирующему ряду
hold on;
syms x eps N
eps = 0.1;
N = 4; 
assume(x,'rational');
x = -1:1/10:3;
an = ((x - 1).^(2*n))/(n*9^n);
plot(x,symsum(an, n, 1, inf)+eps,'-.r');
plot(x,symsum(an, n, 1, inf)-eps,'-.r');
plot(x,symsum(an, n, 1, inf),'-*k');
for i = 1 : 5
    plot(x,symsum(an, n, 1, N),'-.b');
    N = N + 1;
end;