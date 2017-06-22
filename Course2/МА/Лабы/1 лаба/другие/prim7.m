% Задача 7. Равномерная сходимость функционального ряда по определению
syms f x n eps N;
hold on;
eps = 0.1;
%N = (1 + 5*eps) / (6*eps);
N = (1 + 4*eps) / (8*eps);
x = 0 : 1/10 : 1;
f = (-1)^n * x.^n / (6*n - 11);
plot(x, symsum(f, n , 1, inf) + eps, '-.r');
plot(x, symsum(f, n , 1, inf) - eps, '-.r');
plot(x, symsum(f, n , 1, inf), '-*k');
for i = 1 : 5
    plot(x, symsum(f, n , 1, N), '-b');
    N = N + 1;
end