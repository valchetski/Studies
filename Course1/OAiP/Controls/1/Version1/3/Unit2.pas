unit Unit2;

interface
uses
  Math, SysUtils, StdCtrls;
  type
  fun = function (x:extended):extended;
  procedure Tabl(a,b,n:integer; f:fun; var Fl:textfile);
implementation
 procedure Tabl;
 var x,h,y:extended; i: integer;
 begin
 x:=a; h:=(b-a)/n;
 for i:=1 to n+1 do begin
  y:=f(x);
  WriteLn(Fl,'x='+FloatToStrf(x,fffixed,8,2)+' y='+FloatToStrf(y,fffixed,8,5));
  Flush(Fl);
  x:=x+h;
 end;
 end;
end.
