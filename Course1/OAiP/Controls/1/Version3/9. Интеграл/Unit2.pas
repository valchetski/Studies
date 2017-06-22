unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Type Fun=Function(x:extended):extended;
Function Resh(a,b:extended;n:integer;f:fun):extended;
Function f(x:extended):extended;
implementation

Function f;
begin
  F:=Sin(x)*Sin(x);
end;

Function Resh;
var x,y,h:extended; i:integer;
begin
  h:=(b-a)/n; y:=0;
  For i:=1 to n do
   begin
     x:=a+h*(i-0.5);
     y:=y+F(x);
   end;
  Result:=h*y;
end;
end.
