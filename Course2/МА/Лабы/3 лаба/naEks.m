syms x n
f = exp(-x);
L = pi;
a0 = (1/(2*L))*int(f, x, -L, L);
an = (1/L)*int(f*cos((n*x*pi)/L), x , -L, L);
bn = (1/L)*int(f*sin((n*x*pi)/L), x, -L, L);
x = -L : 1/32 : L;
fourierr = an*cos((n*x*pi))/L + bn*sin((n*x*pi))/L;
sum5 = double(subs(a0+symsum(an*cos(n*x)+bn*sin(n*x),n,1,5),x));
plot(x, sum5);