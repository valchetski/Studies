% Задача 8. Сходимость функционального ряда через мажорирующий ряд
syms f x n eps N;
hold on;
eps = 0.05;
N = 1;
x = -6 : 1/10 : -4;
f = (x + 5) .^ (n .^ 2) / (n .^ n);
plot(x, symsum(f, n , 1, inf) + eps, '-.r');
plot(x, symsum(f, n , 1, inf) - eps, '-.r');
plot(x, symsum(f, n , 1, inf), '-*k');
for i = 1 : 5
    plot(x, symsum(f, n , 1, N), '-b');
    N = N + 1;
end