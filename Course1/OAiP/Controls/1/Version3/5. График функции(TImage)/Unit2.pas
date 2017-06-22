unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;
Var M:integer;
Type Fun=Function(x:extended):extended;
Procedure Resh(a,b:extended;n:integer;Sx:fun;image1:TImage);
implementation
Procedure Resh;
var x,y:Extended; i,x1,y1,xmax,ymax:Integer;
begin
With Image1.Canvas do
begin
  Pen.Color:=ClBlack;
  Brush.Color:=ClWhite;
  xmax:=image1.Width; ymax:=image1.Height;
  Rectangle(0,0,xmax,ymax);
  x1:=30; y1:=30;
  MoveTo(x1,ymax); LineTo(x1,0);
  MoveTo(0,ymax-y1); LineTo(xmax,ymax-y1);
  x:=a; y:=sx(x);
  MoveTo(round(x1+x*10),round(ymax-(y1+y*10)));
  for i:=1 to n do
  begin
  x:=x+(b-a)/n;
  y:=Sx(X);
  LineTo(round(x1+x*10),round(ymax-(y1+y*10)));
  end;
end;
end;
end.
