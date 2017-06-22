unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
Dialogs, StdCtrls;
type tfl=file of char;
procedure sr(var fl:tfl; x,y:char );
implementation
procedure sr;
var ch:char;
begin
 Reset(fl);
 while not eof(fl) do
 begin
  read(fl,ch);
  if ch=x then
  begin
  seek(fl,filepos(fl)-1);
  write(fl,y);
  end;
 end;
end;
end.
