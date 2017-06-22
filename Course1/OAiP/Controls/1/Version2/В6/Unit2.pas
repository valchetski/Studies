unit Unit2;

interface
uses StdCtrls, SysUtils, CHart;
type
fun=function(x:extended):extended;
procedure graph(a,b,e : extended; n : integer; f:fun; c: TChart);
implementation
procedure graph(a,b,e : extended; n : integer; f:fun; c: TChart);
var h, x, y : extended;
    i : integer;
begin
h:=(b-a)/n;
x:=a;
c.SeriesList[0].Clear;
for i:=1 to n do begin
                   y:=f(x);
                   c.SeriesList[0].AddXY(x,y);
                   x:=x+h;
                  end;
end;
end.
