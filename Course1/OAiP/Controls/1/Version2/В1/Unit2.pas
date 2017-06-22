unit Unit2;

interface
function pred(a,e,x0,x1 : extended):extended;
implementation
function pred(a,e,x0,x1 : extended):extended;
var x :extended;
begin
x:=0.5*(x1+a/x0);
while abs(x1-x)>e do begin
x0:=x1;
x1:=x;
x:=0.5*(x1+a/x0);

end;
Result:=x;
end;
end.
 