unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Function Resh(a,e,x0,x1:extended):extended;
implementation
Function Resh;
var
a0,a1,a2:extended;
begin
a0:=x0; a1:=x1;
a2:=0.5*(a1+a/a0);
While abs(a2-a1)>e do
  begin
    a0:=a1;
    a1:=a2;
    a2:=0.5*(a1+a/a0);
  end;
Result:=a2;
end;
end.
