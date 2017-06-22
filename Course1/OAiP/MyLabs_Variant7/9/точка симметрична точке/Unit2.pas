unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls;
  Procedure Tochka(a,b,c,h:extended; x1,y1:integer; Image1:TImage);
implementation
  Procedure Tochka;
  var xmax,ymax,x0,y0,x:integer; y:extended; x2,y2:extended;
  begin
  with Image1.Canvas do begin
    Pen.Color:=ClBlack; Pen.Width:=2; Brush.Color:=ClBlue;
    xmax:=Image1.Width; ymax:=Image1.Height;
    Rectangle(0,0,xmax,ymax);
    x0:=20; y0:=20;
    MoveTo(0,ymax-y0); LineTo(xmax,ymax-y0);
    MoveTo(x0,0); LineTo(x0,ymax);
    x:=0; y:=-1*a*x/b-c/b; MoveTo(Round(x),Round(ymax-y));
    while x<xmax do begin
      x:=x+10;
      y:=-1*a*x/h/b-c/b;
      LineTo(Round(x/h),Round(ymax-y));
    end;
    Brush.Color:=ClBlack; Pen.Width:=6;
    Moveto(Round(x1/h+x0),Round(ymax-(y1/h+y0)));
    Lineto(Round(x1/h+x0),Round(ymax-(y1/h+y0)));
    Pen.Color:=ClYellow; Brush.Color:=ClBlue;
    TextOut(Round(x1/h+x0),Round(ymax-(y1/h+y0)),'M('+FloatToStr(x1)+','+FloatToStr(y1)+')');
    x2:=(sqr(b)*x1-2*b*a*y1-2*c*a-sqr(a)*x1)/((sqr(a)+sqr(b)));
    y2:=(y1*sqr(a)-y1*sqr(b)-2*c*b-2*a*b*x1)/(sqr(a)+sqr(b));
    Pen.Color:=ClBlack; Brush.Color:=ClBlack;
    moveto(Round(x2/h+x0),Round(ymax-(y2/h+y0)));
    lineto(Round(x2/h+x0),Round(ymax-(y2/h+y0)));
    Brush.Color:=ClBlue;
    TextOut(Round(x2/h+x0),Round(ymax-(y2/h+y0)),'N('+IntToStr(Round(x2))+','+IntToStr(Round(y2))+')');
  end;
  end;
end.
 