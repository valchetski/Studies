unit Unit2;

interface
uses ExtCtrls, Graphics,StdCtrls, SysUtils;
procedure krug(r,x,y,h:real; m:timage);
implementation
procedure krug(r,x,y,h:real; m:timage);
var a,b,p,g : integer;
begin
p:=m.Width;
g:=m.Height;
a:=p div 2;
b:=g div 2;
with m do
with canvas do  begin
Brush.Color:=clRed;
Rectangle(0,0,p,g);
Brush.Color:=clGreen;
Ellipse(round(a-r/h),round(b-r/h),round(a+r/h),round(b+r/h));
Brush.Color:=clBlack;
  Ellipse(round(x/h-5),round(p-y/h+5),round(x/h+5),round(p-y/h-5));
 end;
end;



end.
