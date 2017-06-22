function y = Sum1(x,a,b)
syms n
%y = symsum((n+1)^4/(2*n+1).*x.^(2*n),n,a,b);
%an = ((x - 1).^(2*n))/(n*9^n);
%y = symsum(an, n, a, b);
y = symsum((x+1).^(1/2)*cos(x*n)/(n^5+1)^(1/3),n,a,b);
end