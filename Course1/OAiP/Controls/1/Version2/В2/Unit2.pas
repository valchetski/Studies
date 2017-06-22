unit Unit2;
interface
uses SysUtils;
function perka(n : integer):integer;
implementation
function perka(n : integer):integer;
var m: integer;
begin
m:=0;
while n<>0 do begin
m:=m*10+(n mod 10);
n:=n div 10;
end;
Result:=m;
end;
end.
