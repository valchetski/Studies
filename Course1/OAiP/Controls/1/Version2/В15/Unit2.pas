unit Unit2;

interface
uses SysUtils, Stdctrls;
type
tfl = file of char;

function shet(var ft : tfl; x : char) : integer;
implementation

function shet(var ft : tfl; x : char) : integer;
var a : integer;
s : char;
begin
a:=0;
while not eof(ft) do begin
read(ft,s);
if s=x then inc(a);
end;
Result:=a;
end;
end.
 