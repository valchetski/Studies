unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;
procedure Circle(var r,x,y,h:extended; m:timage);
implementation
procedure Circle;
var x1,y1,r2:integer;
begin
 x1:=round(x/h);
 y1:=round(y/h);
 r2:=round(r/h);
 m.Canvas.Brush.Color:=clgreen;
 m.Canvas.Rectangle(0,0,m.Width,m.Height);
 m.Canvas.Brush.Color:=clred;
 m.Canvas.ellipse((m.Width div 2)-r2,(m.Height div 2)-r2,
 (m.Width div 2)+r2,(m.Height div 2)+r2);
 m.Canvas.brush.Color:=clblue;
 m.Canvas.Ellipse((m.Width div 2)+x1-4,(m.Height div 2)-y1-4,(m.Width div 2)+x1+4,(m.Height div 2)-y1+4);
end;
end.
