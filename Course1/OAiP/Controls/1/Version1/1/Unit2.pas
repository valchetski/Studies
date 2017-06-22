unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs;
  function lim(x0,x1,a,e:extended):extended;
implementation
function lim;
var x,dx:extended;
begin
repeat
   x:=0.5*(x1+a/x0);
   dx:=abs(x0-x1);
   x0:=x1;
   x1:=x;
until dx<e;
Result:=x;
end;

end.
