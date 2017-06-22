unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs;
type tfl=file of char;
function src(var fl:tfl; const x:char):string;
implementation
 function src;
 var n:integer; ch:char;
 begin
  Reset(fl);
  n:=0;
  while not eof(fl) do
  begin
   read(fl,ch);
   if ch=x then Inc(n);
  end;
  result:=IntToStr(n);
 end;
end.
