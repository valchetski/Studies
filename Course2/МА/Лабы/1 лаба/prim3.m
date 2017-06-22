% Задание 3. Исследование ряда на сходимость. Признак Д`Аламбера
syms n an dalamber_limit 
an = (n / gamma(2 * n + 1)) * tan(1/(5 ^ n));
dalamber_limit = limit(abs(subs(an, n, n + 1) / an), n, inf);
disp('Предел по Д''аламберу:');
disp(dalamber_limit);
dalamber_limit = double(dalamber_limit);
if (dalamber_limit < 1)
    disp('Ряд сходится!');
elseif (dalamber_limit > 1)
    disp('Ряд расходится!');
else
    disp('Нужны дополнительные исследования');
end;
%Предел по Д''аламберу:
%0
%Ряд сходится!