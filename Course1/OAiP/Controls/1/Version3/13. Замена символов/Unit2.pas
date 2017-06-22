unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
type Tfl=File of char;
Procedure Resh(Var fl:Tfl; x,y:Char);
implementation

Procedure Resh;
var ch:char;
begin
while not eof(fl) do
  begin
  read(fl,ch);
  if ch=x then begin seek(fl,filepos(fl)-1);
                     write(fl,y);
               end;
  end;
end;

end.
 