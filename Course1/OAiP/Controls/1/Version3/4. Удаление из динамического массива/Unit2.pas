unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids;
Type Mas=array [0..0] of integer;
     Pmas=^Mas;
Procedure Resh(n:integer; var a:Pmas; Var n1:integer);
implementation
procedure resh;
var i:integer;
begin
 n1:=-1;
 for i:=0 to n-1 do
  if a[i] mod 2=1 then
    begin
      n1:=n1+1;
      a[n1]:=a[i];
    end;
end;
end.
