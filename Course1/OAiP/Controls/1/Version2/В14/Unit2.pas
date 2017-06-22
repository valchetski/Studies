unit Unit2;

interface
  uses StdCtrls, SysUtils;
function search(st : string; Mem1 : Tmemo) : string;
implementation
function search(st : string; Mem1 : Tmemo) : string;
var i,n : integer;
    st1 : string;
begin
i:=0;
n:=0;  st1:='';
while i<>length(st) do  begin
repeat
inc(i);
until (st[i]='[') or (i=length(st));
if i=length(st) then exit;
inc(i);
inc(n);
repeat
st1:=st1+st[i];
if st[i]=']' then dec(n) else
 if st[i]='[' then inc(n);
 inc(i);
until n=0;   dec(i);
delete(st1,length(st1),1);
Mem1.Lines.Add(st1);
st1:='';
end;  end;




end.
