unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs;
function pod(const st:string):integer;
implementation
function pod;
var ch:set of char;
n,i:integer;
begin
 n:=0; ch:=[];
 for i:=1 to length(st) do
 begin
  if not (st[i] in ch) then
  begin
   include(ch,st[i]);
   n:=n+1;
  end;
 end;
 result:=n;
end;

end.
