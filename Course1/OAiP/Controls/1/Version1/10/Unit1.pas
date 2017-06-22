unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    StringGrid1: TStringGrid;
    Label1: TLabel;
    Label2: TLabel;
    Button1: TButton;
    Button2: TButton;
    Label3: TLabel;
    Edit1: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edit1.Clear;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
form1.close;
end;

procedure TForm1.Button1Click(Sender: TObject);
var x1,y1,x2,y2,x3,y3,h,m:extended;
begin
x1:=strtofloat(stringgrid1.Cells[0,0]);
m:=x1;
y1:=strtofloat(stringgrid1.Cells[0,1]);
if y1>m then m:=y1;
x2:=strtofloat(stringgrid1.Cells[1,0]);
if x2>m then m:=x2;
y2:=strtofloat(stringgrid1.Cells[1,1]);
if y2>m then m:=y2;
x3:=strtofloat(stringgrid1.Cells[2,0]);
if x3>m then m:=x3;
y3:=strtofloat(stringgrid1.Cells[2,1]);
if y3>m then m:=y3;
h:=(image1.Width*2)/(3*m);
edit1.Text:=FloatToStr(treangle(x1,y1,x2,y2,x3,y3,h,image1));
end;

end.
