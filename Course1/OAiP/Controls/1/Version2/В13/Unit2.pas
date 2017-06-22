unit Unit2;

interface
type
tfl = file of char;
procedure samena(var fl : tfl; x,y : char);
implementation
procedure samena(var fl : tfl; x,y : char);
var a : char;
begin
while not eof(fl) do begin
read(fl,a);
if a=x then begin seek(fl,filepos(fl)-1);
                  write(fl,y);
            end; end;
end;

end.
 