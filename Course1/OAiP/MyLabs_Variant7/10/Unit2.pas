unit Unit2;
interface
uses   Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
Dialogs, clipbrd;
var
colorb:tcolor;
type
tkorp=class(tobject)
x,y,r,x1,y1,x2,y2:integer;
color:tcolor;
canvas:tcanvas;
constructor create(x0,y0:word;color0:tcolor;canvas0:tcanvas);
procedure ris;virtual;abstrakt;
procedure draw(bl:boolean);
procedure show;
procedure hide;
procedure move(mx,my:integer);
end;
tfar=class(tkorp)
constructor create(x0,y0:word;color0:tcolor;canvas0:tcanvas);
procedure ris;override;
end;
tsht=class(tfar)
procedure ris;override;
end;
tdver=class(tkorp)
procedure ris;override;
end;
implementation
constructor tkorp.create;
begin
x:=x0;y:=y0;canvas:=canvas0;color:=color0;
end;

procedure tkorp.ris;
begin
x1:=x-50;y1:=y-30;x2:=x+40;y2:=y+30;
canvas.rectangle(x2-10,y2-90,x2+30,y2-30);
canvas.rectangle(x1,y1,x2+50,y2-30);
canvas.Ellipse(x1,y1-30,x2,y2-30);       //tend
canvas.Ellipse(x2+10,y2-30,x2+30+10,y2);          //pravoe
canvas.Ellipse(x1+10,y2-30,x1+30+10,y2);    //levoe koleso
end;

procedure tkorp.draw;
begin
with canvas do begin
if bl then begin pen.color:=color; brush.color:=color;
end
else begin pen.color:=colorb; brush.color:=colorb; end;
ris;
end;

end;
procedure tkorp.show;
begin
draw(true);
end;

procedure tkorp.hide;
begin
draw(false);
end;

procedure tkorp.move;
begin
hide;
x:=x+mx;y:=y+my;
show;
end;

constructor tfar.create;
begin
x:=x0;y:=y0;
canvas:=canvas0;
color:=clyellow;
end;

procedure tfar.ris;
begin
x1:=x-20;y1:=y-70;x2:=x+20;y2:=y-30;
canvas.Ellipse(x1+105,y2,x1+120,y2+20);

//x1:=x-50;y1:=y-30;x2:=x+40;y2:=y+30;   color:=clblue;
//canvas.rectangle(x1+125,y1,x2+50,y2-30);
end;

procedure tdver.ris;
begin    color:=clblue;
x1:=x-50;y1:=y-30;x2:=x+40;y2:=y+30;
canvas.rectangle(x2,y2-70,x2+20,y2-40);
end;

procedure tsht.ris;
begin color:=clwhite;
x1:=x-50;y1:=y-30;x2:=x+40;y2:=y+30;
canvas.rectangle(x2,y2-70,x2+20,y2-40);
end;
end.
