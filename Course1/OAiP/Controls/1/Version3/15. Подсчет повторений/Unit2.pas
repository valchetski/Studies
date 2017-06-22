unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Type TFl=File of char;
Function Resh(Var Fl:Tfl; x:char):integer;
implementation
Function Resh;
var n:integer; ch:char;
begin
  n:=0;
  While not(Eof(fl)) do
  begin
  read(fl,ch);
  if Ch=x then n:=n+1;
  end;
  result:=n;
end;
end.
