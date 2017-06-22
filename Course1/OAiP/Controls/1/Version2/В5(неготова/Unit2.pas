unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;
type fun=function(x:extended):extended;
Procedure Graf(a,b:extended;n,p:integer;f:fun;m:TImage);
implementation
Procedure Graf(a,b:extended;n,p:integer;f:fun;m:TImage);
var x,y,hx,hy:Extended; i,x1,y1,xmax,ymax:Integer;
Begin
With m.Canvas do
begin
  Pen.Color:=ClBlack;
  Brush.Color:=ClWhite;
  xmax:=m.Width; ymax:=m.Height;
  Rectangle(0,0,xmax,ymax);
  x1:=p; y1:=p;
  x:=a; y:=f(x);
  MoveTo(round(x1+x*10),round(ymax-(y1+y*10)));
  for i:=1 to n do
  begin
  x:=x+(b-a)/n;
  y:=f(X);
  LineTo(round(x1+x*10),round(ymax-(y1+y*10)));
  end;
end;
  end;
end.
