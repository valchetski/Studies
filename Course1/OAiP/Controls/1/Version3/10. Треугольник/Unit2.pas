unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;
Procedure Resh(x1,y1,x2,y2,x3,y3,h:extended; Image1:TImage);
implementation
Procedure Resh;
var Xmax,ymax:integer;
    a,b,c,s,p:extended;
begin
  With Image1.Canvas do
  begin
    xmax:=Image1.Width; ymax:=Image1.Height;
    Pen.Color:=ClYellow; Brush.Color:=ClYellow;
    Rectangle(0,0,xmax,ymax);
    Pen.Color:=ClNavy; Brush.Color:=ClNavy;
    Polygon([Point(Round(x1/h),round(ymax-y1/h)),Point(Round(x2/h),round(ymax-y2/h)),Point(Round(x3/h),round(ymax-y3/h))]);
    a:=Sqrt(sqr(y2-y1)+sqr(x2-x1));
    b:=Sqrt(sqr(y3-y1)+sqr(x3-x1));
    c:=Sqrt(sqr(y3-y2)+sqr(x3-x2));
    p:=(a+b+c)/2;
    S:=Sqrt(p*(p-a)*(p-b)*(p-c));
    Pen.Color:=ClBlack; Brush.Color:=ClWhite;
    TextOut(xmax-200,ymax-20,'Площадь равна '+FloatToStrF(s,Fffixed,4,3));
  end;
end;
end.
 