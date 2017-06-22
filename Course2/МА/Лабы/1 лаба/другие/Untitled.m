%Область сходимости функционального ряда
%Ряд: n^(1/2)/n^(x^2-1) n=1,2...
syms s n x f str res
str = '';
assume(n>0);
assume(x,'rational');
f = ((x^2-5*x+11)^n / (5^n*(n^2+5)));
f = simplify(f);
s = symsum(f,n,1,inf);
if(s ~= inf)
%Извлекаем решение из символьной формы 
str = char(s);
disp(s);
strstart = strfind(str, '[');
strend = strfind(str,',');
res = str(strstart + 1: strend - 1);
disp(strcat('Условие сходимости: ',res));
else
disp('Расходится при любом x');
end;