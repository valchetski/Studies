unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;
Procedure Resh(r,x,y,h:Extended; Image1:TImage);
implementation
Procedure Resh;
Var x1,y1,ymax:integer;
begin
With Image1.Canvas do
begin
  Pen.Color:=ClGreen; Brush.Color:=ClGreen;
  x1:=Image1.Width div 2; Y1:=Image1.Height div 2; Ymax:=Image1.Height;
  Rectangle(0,0,image1.Width,image1.Height);
  Pen.Color:=ClRed; Brush.Color:=ClRed;
  Ellipse(round(x1-r/h),round(y1+r/h),round(x1+r/h),round(y1-r/h));
  Pen.Color:=ClNavy; Brush.Color:=ClNavy;
  Ellipse(round(x/h-5),round(ymax-y/h+5),round(x/h+5),round(ymax-y/h-5));
end;
end;
end.
