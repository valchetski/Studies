syms an n x
assume(n>0);
assume(x,'rational');
fn = (1 / (n+3)) * ((1 +x)/(1 - x))^n;
fn = expand(fn);
%L = limit (abs(fn),n,inf);
limit(fn,x,a,sd,sd);