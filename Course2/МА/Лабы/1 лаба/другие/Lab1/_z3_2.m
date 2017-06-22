% 3.2 Исследование ряда на сходимость при помощи признака Коши
syms n a f
f = (n/(3*n+1))^(2*n+1);
a = limit(f, n, inf);
disp('Предел числовой последовательности:');
disp(a)
if (a == 0)
    syms f_lim
    f_lim = limit(f^(1./n), n, inf);
    disp('Предел по Коши:');
disp(f_lim);
    f_lim = double(f_lim);
    if (f_lim < 1)
        disp('Ряд сходится!');
    else
        if (f_lim> 1)
disp('Ряд расходится!');
else
disp('Нужны дополнительные исследования');
end;
    end;
else
     disp('Ряд расходится!');
end;