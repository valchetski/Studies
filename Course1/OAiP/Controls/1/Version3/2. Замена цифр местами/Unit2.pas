unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Function Resh(N:Integer):Integer;
implementation
Function Resh;
Var
 M,N1,ostatok:integer;
begin
 M:=0; N1:=N;
 While N1>0 do
 begin
  ostatok:=N1 mod 10;
  M:=M*10+ostatok;
  N1:=N1 div 10;
 end;
Result:=M;
end;
end.
 