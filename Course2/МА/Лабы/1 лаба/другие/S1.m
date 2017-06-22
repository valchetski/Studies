%Подсчет суммы по определению
%Ряд: 6/(4*n^2-9) n=1,2,3...
syms n sn s k
sn = symsum(6/(4*n*n-9),n,1,k);
s = limit(sn,k,inf);
disp(s);
%Результат: 1/3