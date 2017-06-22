syms f f1 n 
f=((4*n-3)/(5*n+1))^(n^3);
f1=limit(f^(1/n),n,inf);
if (double(f1)<double(1))
    disp('Ряд сходится')
 %   s=symsum(f,1,inf);
 %  disp(s);
elseif   (double(f1)>double(1))
    disp('Ряд расходится')
else
    disp('Признак не даёт ответа')
end