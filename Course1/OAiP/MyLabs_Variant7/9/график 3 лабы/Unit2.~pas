unit Unit2;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, TeEngine, Series, ExtCtrls, TeeProcs, Chart, ComCtrls,
  Math;
Type fun=function (x:extended):extended;
Procedure Image(xn,xk:extended;n,xomin,xomax,yomin,yomax:integer; sx:fun;Image1:TImage);
Procedure Char(xn,xk:extended;n,xomin,xomax,yomin,yomax:integer; sx:fun;Chart1:TChart);
implementation

Procedure Image;
var xmax,ymax,x1,y1,i:integer; h,y,x,hx,hy:extended;
begin
With Image1.Canvas do begin
    Brush.Color:=ClWhite;
    xmax:=Image1.Width; ymax:=Image1.Height;
    Rectangle(0,0,xmax,ymax);
    Pen.Color:=ClBlack; Pen.Width:=2;
    hx:=(xomax-xomin)/xmax;
    hy:=(yomax-yomin)/ymax;
    x1:=20; y1:=20;
    MoveTo(x1,0); LineTo(x1,ymax);
    MoveTo(0,ymax-y1); LineTo(xmax,ymax-y1);
    x:=xn; y:=sx(x);
    MoveTo(Round(x1+x/hx),Round(ymax-(y1+y/hy)));
    h:=(xk-xn)/n;
    for i:=1 to n do begin
      x:=x+h; y:=sx(x);
      LineTo(Round(x1+x/hx),Round(ymax-(y1+y/hy)));
    end;
  end;
  end;
Procedure Char;
var h,x,y:extended; i:integer;
begin
With Chart1 do begin
    LeftAxis.Automatic:=False;
    LeftAxis.Minimum:=yomin;
    LeftAxis.Maximum:=yomax;
    BottomAxis.Automatic:=False;
    BottomAxis.Minimum:=xomin;
    BottomAxis.Maximum:=xomax;
    SeriesList[0].Clear;
    h:=(xk-xn)/(n-1); x:=xn;
    for i:=1 to n do begin
      y:=sx(x);
      SeriesList[0].AddXY(x,y);
      x:=x+h;
    end;
    end;
  end;
end.
