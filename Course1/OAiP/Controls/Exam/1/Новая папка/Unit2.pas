unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

Type

TClass = class(Tobject)
   Color: TColor;
   Canvas: TCanvas;
   x,y,r: integer;
   procedure Draw(bl: boolean);
   procedure Ris();virtual;abstract;
   procedure Show();
   procedure Hide();
   procedure MoveTo(dx,dy:integer);
end;

TKrug = class(TClass)
   constructor Create(x1,y1,r1: integer; Color1: TColor; Canvas1: TCanvas);
   procedure Ris();override;
end;

var
ColorBack: TColor;

implementation

constructor TKrug.Create(x1,y1,r1: integer; Color1: TColor; Canvas1: TCanvas);
begin
x:=x1;
y:=y1;
r:=r1;
Color:=Color1;
Canvas:=Canvas1;
end;

procedure TClass.Draw(bl: boolean);
begin
with Canvas do
 if bl then
  begin
   pen.Color:=Color;
   brush.Color:=Color;
  end
 else
  begin
   pen.Color:=ColorBack;
   brush.Color:=ColorBack;
  end;
Ris();
end;

procedure TClass.Show();
begin
Draw(true);
end;

procedure TClass.Hide();
begin
Draw(false);
end;

procedure TClass.MoveTo(dx,dy: integer);
begin
Hide();
x:=x+dx;
y:=y+dy;
Show();
end;

procedure TKrug.Ris();
begin
Canvas.Ellipse(x-r,y-r,x+r,y+r);
end;

end.
 