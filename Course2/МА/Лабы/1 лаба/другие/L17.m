 syms sk k s n
%sk=symsum(3/(9*n^2+3*n-2),n,1,k);
sk= symsum(1/n,n,1,k);
disp(sk);
s=limit(sk,inf);
disp(s);