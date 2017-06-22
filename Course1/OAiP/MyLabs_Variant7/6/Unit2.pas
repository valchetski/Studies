unit Unit2;
interface
uses StdCtrls, SysUtils;
Type
fun=function(x:extended):extended;
procedure Tabl(f:fun; xn,xk:extended; m:word; Memo1:TMemo);
implementation
procedure Tabl;
var x,h,y:extended; i:word;
begin
x:=xn; h:=(xk-xn)/m;
for i:=1 to m+1 do begin
y:=f(x);
Memo1.Lines.Add('x='+FloatToStrF(x,ffFixed,8,4)+'   y='+FloatToStrF(y,ffFixed,8,4));
x:=x+h;
end;
end;
end.
 