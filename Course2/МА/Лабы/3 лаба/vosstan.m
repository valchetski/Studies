syms n x k Ck vossf 
f = exp(2*x+1);
L = pi;
Pi = pi;
integr = f*exp((-1)*(k*pi*x*i)/L);
Ck = 1/(2*pi)* int(integr, x,-L,L);
ak = real(Ck);
bk = imag(Ck);
phi = atan(bk/ak);
absCk = abs(Ck);
vossCk = absCk*exp(i*phi);
vossf = vossCk*exp((i*k*pi*x)/L);
hold on; grid on;
x = -pi : pi/32 : pi;
summa = symsum(vossf,k,1,5);
summa = simplify(summa);
newVossf = subs(summa,x);
pretty(newVossf);
plot(x, newVossf);