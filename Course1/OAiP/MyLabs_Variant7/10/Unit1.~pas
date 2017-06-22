unit Unit1;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, clipbrd, unit2, StdCtrls, ExtCtrls, xpman;
type
  TForm1 = class(TForm)
    Image1: TImage;
    Button1: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Button2: TButton;
    Button9: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
var
  Form1: TForm1;
  korp:tkorp;
  far:tfar;
  sht:tsht;
  dver:tdver;
  rx,ry,x0,y0,r0,i,q,z,d:integer;
implementation
{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
button1.hide;
button2.Show;
colorb:=clwhite;
rx:=image1.width;
ry:=image1.height;
with image1.canvas do
begin
pen.color:=colorb;
pen.width:=1;
brush.color:=colorb;
rectangle(0,0,rx,ry);
end;
x0:=round(rx/2);y0:=round(ry/2);r0:=20;
korp:=tkorp.create(x0,y0,clblue,image1.canvas);
far:=tfar.create(x0,y0,clblue,image1.canvas);
sht:=tsht.create(x0,y0,clwhite,image1.canvas);
dver:=tdver.create(x0,y0,clblue,image1.canvas);
korp.show;
//far.show;
//sht.show;
//dver.show;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin

if i=1 then begin

far.move(0,-4);
dver.move(0,-4);
sht.move(0,-4);
korp.move(0,-4);


if i=1 then
far.show else
far.hide;
//korp.show;

if z=1 then
sht.hide;
end;

if i=0 then begin
far.move(0,-4);
dver.move(0,-4);
sht.move(0,-4);
korp.move(0,-4);


if i=1 then
far.show else
far.hide;
korp.show;

if z=1 then
sht.hide;
end;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin     if i=1 then begin
far.move(0,4);
dver.move(0,4);
sht.move(0,4);
korp.move(0,4);


if i=1 then
far.show else
far.hide;
//korp.show;

if z=1 then
sht.hide;
end;
if i=0 then begin
far.move(0,4);
dver.move(0,4);
sht.move(0,4);
korp.move(0,4);


if i=1 then
far.show else
far.hide;
korp.show;

if z=1 then
sht.hide;
end;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin  if i=1 then begin
far.move(-4,0);

dver.move(-4,0);
sht.move(-4,0);
korp.move(-4,0);

if i=1 then
far.show else
far.hide;
//korp.show;

if z=1 then
sht.hide;
end;

if i=0 then begin
far.move(-4,0);

dver.move(-4,0);
sht.move(-4,0);
korp.move(-4,0);

if i=1 then
far.show else
far.hide;
korp.show;

if z=1 then
sht.hide;
end;
end;

procedure TForm1.Button7Click(Sender: TObject);
begin         if i=1 then begin
far.move(4,0);

dver.move(4,0);
sht.move(4,0);
korp.move(4,0);

if i=1 then
far.show else
far.hide;
//korp.show;

if z=1 then
sht.hide;
end;
if i=0 then begin
far.move(4,0);

dver.move(4,0);
sht.move(4,0);
korp.move(4,0);

if i=1 then
far.show else
far.hide;
korp.show;

if z=1 then
sht.hide;
end;
end;

procedure TForm1.Button8Click(Sender: TObject);
begin
if i=0 then
begin
far.show;
i:=1;
end
else begin
i:=0;
far.hide;
korp.show;
sht.show;
dver.show;
form1.refresh;
end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
i:=0;
q:=0;
button2.hide;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin i:=0; z:=0;
korp.hide; korp.free;
far.hide; far.free;
//sht.hide; sht.free;
//dver.hide; dver.free;
button1.Show;
button2.Hide;
i:=0;
end;
procedure TForm1.Button9Click(Sender: TObject);
begin

if z=0 then
begin

for q:=1 to 25 do begin
dver.move(-1,0);
korp.show;
sht.show;
dver.show;
sleep(1);
if i=1 then
far.show;
form1.refresh
end;

if i=1 then
begin
korp.show;
sht.show;
dver.show;
far.show;
end;

z:=1;
end
else begin
z:=0;
for q:=1 to 25 do begin
dver.move(1,0);
korp.show;
sht.show;
dver.show;
sleep (1);
if i=1 then
far.show;
form1.refresh;
end;
end;

if i=1 then
begin
korp.show;
sht.show;
dver.show;
far.show;
end;

end;

end.

