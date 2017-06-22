function y = Sum(x,a,b)
syms n;
y = symsum(((-1)^n).*((x.^n)/(5*n-7)),n,a,b);
end

