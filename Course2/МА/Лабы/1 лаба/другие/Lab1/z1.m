% Задание 1. Найти сумму ряда
syms n f s l;
f = 9 / (9*n*n + 3*n - 20);
s = symsum(f, 1, inf);
disp(s);
l = limit(s, n, inf);
disp(l);
% Результат: -3/10