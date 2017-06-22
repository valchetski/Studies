syms n x ao an bn f1 f2 cn
f=exp(2*x+1);
an=(1/pi)*(int(f*cos(n*x),x,-pi,pi));
bn=(1/pi)*(int(f*sin(n*x),x,-pi,pi));

cnTemp=(bn^2+an^2)^(1/2);
cn = abs(cnTemp) * exp(asin(bn/sqrt(an^2 + bn^2)));

f = cn*sin(n*x);

for i = -pi:pi/32:pi
    sum = 0;
    for j = 1:1:20
        sum = sum + subs(f,[x n],[i j]);
    end;
    plot(i, sum);
end;