unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons;
Type
  Tzad1=class(Tobject)
  a,e:extended;
  function srec(x0:extended):extended;
  function bezrec(x0:extended):extended;
  end;

implementation

function Tzad1.srec;
{var a,e:extended;}
begin
  if abs((x0+a/x0)/2-x0)<e then srec:=(x0+a/x0)/2
  else srec:=srec((x0+a/x0)/2);
end;

function tzad1.bezrec;
{var a,e:extended;}
begin
  while abs((x0+a/x0)/2-x0)>e do begin
    x0:=(x0+a/x0)/2;
  end;
  Result:=(x0+a/x0)/2;
end;  
end.
 