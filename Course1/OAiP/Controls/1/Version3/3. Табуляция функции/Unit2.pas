unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
var m:integer;
Type Fun=Function(x:extended):extended;
Procedure Resh(a,b:extended; n:Integer; Sx:Fun; Var Fl:TextFile);
implementation
Procedure Resh;
var x:extended; i:integer;
begin
  x:=a;
  for i:=1 to n+1 do
    begin
      writeln(fl,'x= '+FloatToStr(x)+'  '+'S(x)= '+ FloatToStrF(Sx(x),fffixed,4,3));
      x:=x+(b-a)/n;
    end;
end;
end.
