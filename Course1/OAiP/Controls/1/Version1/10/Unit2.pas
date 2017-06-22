unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, ExtCtrls;

function treangle(var x1,y1,x2,y2,x3,y3,h:extended; var img:timage):extended;
implementation
function treangle;
var s,a,b,c,p:extended;
begin
 a:=sqrt(sqr(abs(x2-x1))+sqr(abs(y2-y1)));
 b:=sqrt(sqr(abs(x3-x1))+sqr(abs(y3-y1)));
 c:=sqrt(sqr(abs(x3-x2))+sqr(abs(y3-y2)));
 p:=(a+b+c)/2;
 s:=sqrt(p*(p-a)*(p-b)*(p-c));
 y1:=img.Height-round(y1*h);
 y2:=img.Height-round(y2*h);
 y3:=img.Height-round(y3*h);
 img.Canvas.Brush.Color:=clyellow;
 img.Canvas.Rectangle(0,0,img.Width,img.Height);
 img.Canvas.Brush.Color:=clblue;
 img.canvas.polygon([point(round(x1*h),round(y1)),point(round(x2*h),round(y2)),point(round(x3*h),round(y3))]);
 result:=s;
end;
end.
