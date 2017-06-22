unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type fun = function(x:extended):extended;
function int(const a,b:extended; const n:integer; f:fun):extended;

implementation

function int;
var h,x,s:extended;
i:integer;
begin
 h:=(b-a)/n;
 x:=a+0/5*h;
 s:=0;
 for i:=1 to n do
 begin
  s:=s+f(x);
  x:=x+h;
 end;
 result:=s*h;
end;
end.
 