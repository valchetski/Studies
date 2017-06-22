unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
procedure view(var st:string; mem1:tmemo);

implementation
procedure view;
var st1:string;
i,k,x:integer;
begin
 st1:='';
 st:=st+' ';
 for i:=1 to length(st) do
 begin
  if st[i]<>' ' then
  begin
   st1:=st1+st[i];
  end
  else
  begin
   if st1<>'' then
   begin
    val(st1,x,k);
    if (x mod 2)=0 then mem1.Lines.add(inttostr(x));
    st1:='';
   end;
  end;
 end;
end;

end.
