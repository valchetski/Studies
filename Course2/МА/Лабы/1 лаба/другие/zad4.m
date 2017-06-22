syms n l f
f = (cos(n)) / n*n;
l = limit(f, n, inf);
disp('Предел числовой последовательности (признак Лейбница):');
disp(l)
if (l == 0)
disp('Ряд сходится!');
syms f_lim
f_lim = limit(f / (1 / n*n), n, inf);
disp('Предел сравнения с гармоническим рядом:');
disp(f_lim);
f_lim = double(f_lim);
if (f_lim == 0)||(f_lim == +inf)|| (f_lim == -inf)
disp('Исходный ряд сходится абсолютно!');
else
disp('Исходный ряд сходится условно!');
end;
else
disp('Ряд сходится!');
end;