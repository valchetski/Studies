unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Function Resh(st:string):integer;
implementation
Function Resh;
var i,k:integer; s:Set of char;
begin
  S:=[]; k:=0;
  for i:=1 to Length(st) do
    if not(st[i] in s) then
       begin
       include(s,st[i]);
       k:=k+1;
       end;
  Result:=k;
end;
end.
 