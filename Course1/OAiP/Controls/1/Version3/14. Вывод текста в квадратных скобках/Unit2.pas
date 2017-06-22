unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Procedure Resh(st:string;memo1:tmemo);
implementation
procedure resh;
var n,i1,i:integer; tmp:string;
begin
  n:=0; tmp:=''; i1:=0;
  while i1<>length(st) do
  begin
  repeat
  i1:=i1+1;
  until (st[i1]='[') or (i1=length(st));
  If i1=Length(st) then exit;
  n:=n+1; i1:=i1+1;
  repeat
  tmp:=tmp+st[i1];
  if st[i1]=']' then n:=n-1
                else if st[i1]='[' then n:=n+1;
  i1:=i1+1;
  until n=0;
  Delete(tmp,length(tmp),1);
  memo1.Lines.Add(tmp);
  tmp:='';
  end;
end;
end.
 