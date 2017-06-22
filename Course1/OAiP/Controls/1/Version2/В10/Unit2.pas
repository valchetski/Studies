unit Unit2;

interface
uses   Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;
procedure treu(x1,y1,x2,y2,x3,y3,h : real; m : Timage);
implementation
procedure treu(x1,y1,x2,y2,x3,y3,h : real; m : Timage);
var a,b : integer;
c,d,e,p,s:extended;
begin
c:=sqrt(sqr(x2-x1)+sqr(y2-y1));
d:=sqrt(sqr(x3-x1)+sqr(y3-y1));
e:=sqrt(sqr(x3-x2)+sqr(y3-y2));
p:=(c+d+e)/2;
s:=sqrt(p*(p-d)*(p-e)*(p-c));
a:=m.Width;
b:=m.Height;
with m.canvas do begin
               pen.color:=clBlack;
               brush.color:=clgreen;
               rectangle(0,0,a,b);
               brush.Color:=clYellow;
               Polygon([Point(Round(x1/h),round(b-y1/h)),Point(Round(x2/h),round(b-y2/h)),Point(Round(x3/h),round(b-y3/h))]);
               textout(5,5,'S='+FloatToStrF(s,fffixed,6,4));
               end;

end;
end.
