unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,Unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
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
 image1.Canvas.Brush.Color:=clwhite;
 image1.Canvas.Rectangle(0,0,image1.Width,image1.Height);
end;

procedure TForm1.Button1Click(Sender: TObject);
var x,y,r,h:extended;
begin
x:=strtofloat(edit1.Text);
y:=strtofloat(edit2.text);
r:=strtofloat(edit3.Text);
h:=(3*r)/(image1.Height);
Circle(r,x,y,h,image1);
end;

end.
