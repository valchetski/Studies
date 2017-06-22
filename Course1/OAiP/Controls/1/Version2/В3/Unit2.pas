unit Unit2;

interface
uses StdCtrls, SysUtils;
type fun=function(x:extended):extended;

function sap(a,b,n:integer; f:fun; var fl:textfile):extended;
implementation
function sap(a,b,n:integer; f:fun; var fl:textfile):extended;
var x:extended;
    i : integer;
begin
x:=a;
for i:=1 to n+1 do begin
                  writeln(fl,FloatToStrF(x,fffixed,4,3)+'    '+FloatToStrF(f(x),fffixed,4,3));
                  x:=x+(b-a)/n;
                 end;
end;
end.
