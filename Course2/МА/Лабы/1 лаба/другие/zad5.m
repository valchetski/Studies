%Область сходимости функционального ряда
%Ряд: ((n+1)/3^n)*(x^2-4*x+6)^n n=1,2...
syms s n x f str res
str = '';
assume(n>0);
assume(x,'rational');
f = (1 / (n + 3)) * ((1 + x) / (1 - x)) ^ n;
%f = simplify(f);
sa = solve(x + 1 == 1);
s = symsum(f,n,1,inf);
s = simplify(s);
if(s ~= inf && s ~=-inf)
    %Извлекаем решение из символьной формы 
    str = char(s);
    disp(s);
    strstart = strfind(str, '[');
    strend = strfind(str,']');
    res = str(strstart + 1: strend - 1);
    disp(strcat('Условие сходимости: ',res));
else
    disp('Расходится при любом x');
end;
%Результат: Условие сходимости:x in {1, 3}

