syms f1  n
f1=limit((n*2+cos(pi*n))/(2*n^2-1),n,inf);

if (f1~=0)
    disp('Необходимый признак выполняется')
else
    disp('Ряд расходится')
end