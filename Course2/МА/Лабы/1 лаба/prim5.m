%Задача 5. Найти область сходимости функционального ряда
syms n x
assume(n>0);
assume(x,'rational');
an = (1 / (n+3)) * ((1 +x)/(1 - x))^n;
fn = subs(an, n, n + 1) / an;
fn = simplify(fn);
lim = limit(fn, n, inf);%Признак Д'Аламбера
lim = simplify(lim);
x1 = solve(lim == -1); % левый конец области сходимости
x2 = solve(lim == 1); % правый конец области сходимости
if isempty(x1)
    x1 = -inf;
end;
if isempty(x2)
    x2 = inf;
end;
temp = symsum(subs(an, x, x1), n, 1, inf);
if (temp == inf) || (isnan(temp)) % проверяем сходимость ряда в точке x1
    open_bracket = '(';
else
    open_bracket = '[';
end;
temp = symsum(subs(an, x, x1), n, 1, inf);
if (temp == inf) || (isnan(temp)) % проверяем сходимость ряда в точке x2
    close_bracket = ')';
else
    close_bracket = ']';
end;
fprintf('Область сходимости :  %c%d; %d%c\n', open_bracket, double(x1), double(x2), close_bracket);
%Область сходимости : (-inf; 0)