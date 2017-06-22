unit Unit2;

interface
uses StdCtrls, SysUtils;
procedure search(st : string; Memo : Tmemo);
implementation
procedure search(st : string; Memo : Tmemo);
var a, b : integer;
    st1 : string;
begin
a:=pos(' ',st);
while a<>0 do begin
st1:=copy(st,1,a-1);
delete(st,1,a);
b:=strtoint(st1);
if b mod 2=0 then
Memo.Lines.Add(st1);
a:=pos(' ',st);
end;
end;
end.
 