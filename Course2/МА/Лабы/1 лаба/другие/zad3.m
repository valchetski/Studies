% Задание 3. Исследование ряда на сходимость при помощи признака Д`Аламбера
syms n l f
f = ((2*n + 3) / (n + 1))^n*n; 
l = limit(f, n, inf);
disp('Предел числовой последовательности:');
disp(l)
if (l == 0)
    syms f_lim
    f_lim = limit(subs(f, n, n+1) / f, n, inf);
    disp('Предел по Д''аламберу:');
    disp(f_lim);
    f_lim = double(f_lim);
    if (f_lim < 1)
        disp('Ряд сходится!');
    elseif (f_lim > 1)
        disp('Ряд расходится!');
    else
        disp('Нужны дополнительные исследования');
    end;
else
     disp('Ряд расходится!');
end;
