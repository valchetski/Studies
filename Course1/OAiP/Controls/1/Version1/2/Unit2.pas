unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

function f(n: integer):integer;
implementation

function f;
var m: integer;
begin
 m:=0;
  while n <> 0 do
  begin
   m:=m*10+(n mod 10);
   n:=n div 10;
  end;
 Result:=m;
end;
end.

