unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

var
ColorBack: TColor;

type

TABS = class(TObject)
   ColorLn: TColor;
   Canvas: TCanvas;
   x,y,r:word;
   procedure Draw(b:boolean);
   procedure Ris();virtual;abstract;
   procedure Show();
   procedure Hide();
   procedure MoveTo(dx,dy:integer);
end;

TClass = class(TABS)
   constructor create(x0,y0,r0:word;ColorLn0:TColor;Canvas0:TCanvas);
   procedure ris();override;
end;


implementation

constructor TClass.create(x0,y0,r0:word;ColorLn0:TColor;Canvas0:TCanvas);
begin
x:=x0;
y:=y0;
r:=r0;
ColorLn:=ColorLn0;
Canvas:=Canvas0;
end;

procedure TABS.Draw(b:boolean);
begin
with Canvas do
        if b then
         begin
          pen.Color:=ColorLn;
          brush.Color:=ColorLn;
         end
          else
           begin
            pen.Color:=ColorBack;
            brush.Color:=ColorBack;
           end;
Ris();
end;

procedure TClass.ris();
begin
Canvas.Ellipse(x-r,y-r,x+r,y+r);
end;

procedure TABS.Show();
begin
Draw(True);
end;

procedure TABS.Hide();
begin
Draw(false);
end;

procedure TABS.MoveTo(dx,dy:integer);
begin
Hide();
x:=x+dx;
y:=y+dy;
Show();
end;



end.
 