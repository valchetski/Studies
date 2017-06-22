%Область сходимости степенного ряда
% ряд (2n+3)/(x^(2*n)*(n+1)^5)
syms An R n sk1 sk2 Xn x str x1 x2
An = 1 / ((4 ^ (n)) *(2 * n - 1));
R=limit(abs((1/An)^(1/n)),n,inf);
disp(R);
x1=-R;
Xn=limit(An * (x + 5)^(2*n - 1),n,inf);
if Xn ~= inf && Xn~= -inf
end;
x2=R;
Xn=limit(An/(x)^(2*n),n,inf);
if Xn ~= inf && Xn~= -inf
end;
str=sprintf('(-inf;%d)U(%d;inf)',double(x1),double(x2));
disp(str);
%Результат:Условие сходимости:x in  
%(-inf;-1)U(1;inf)