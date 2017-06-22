unit Unit2;

interface

uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Buttons;
type
tmas = array[1..1] of integer;
pmas = ^tmas;
procedure func1(var a:pmas; var n:integer);
implementation

 procedure func1(var a:pmas; var n:integer);
 var i,j:integer;
 begin
 i:=1;
  while i<=n do
  begin
  if (a[i] mod 2)=0 then
  begin
   if i<>n then
    for j:=i to n do a[j]:=a[j+1]
   else i:=i+1;
   n:=n-1;
  end
  else i:=i+1;
  end;
 end;
end.
