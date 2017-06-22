unit Unit2;

interface
uses   Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
procedure viv(var st:string; mem1:tmemo);
implementation
procedure viv;
var a,b,i,j:integer;
begin
i:=0;
while i<=length(st) do
begin
 Inc(i);
 if st[i]='[' then
 begin
  a:=i+1;
  b:=a;
  for j:=i to length(st) do if st[j]=']' then begin
  b:=j;
  mem1.lines.add(copy(st,a,b-a));
  i:=j;
  break;
  end;
 end;
end;
end;
end.
