unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Math;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Memo1: TMemo;
    CheckBox1: TCheckBox;
    RadioGroup1: TRadioGroup;
    procedure FormCreate(Sender: TObject);
    procedure FormKeyPress(Sender: TObject; var Key: Char);
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
Edit1.Text:='1';
Edit2.Text:='1';
Memo1.Clear;
RadioGroup1.ItemIndex:=0;
end;

procedure TForm1.FormKeyPress(Sender: TObject; var Key: Char);
var x,b,r,f:extended;
begin
if key=#13 then
begin
Memo1.Clear;
Memo1.Lines.Add('Ë.ğ ¹2 ñò. ãğ. 252505 Âîë÷åöêîãî À.Ì.');
Memo1.Lines.Add('Èñõîäíûå äàííûå:');
x:=StrToFloat(Edit1.Text);
Memo1.Lines.Add('X='+FloatToStrF(x,ffFixed,8,4));
b:=StrToFloat(Edit2.Text);
Memo1.Lines.Add('B='+FloatToStrF(b,ffFixed,8,4));
case RadioGroup1.ItemIndex of
0:f:=sinh(x);
1:f:=sqr(x);
2:f:=exp(x);
end;
if ((x*b)>1) and ((x*b)<10) then r:=exp(f)+sin(b) else
if ((x*b)>12) and ((x*b)<40) then r:=sqrt(abs(f+4*b)) else
 r:=b*power(f,2);
if CheckBox1.Checked then
Memo1.Lines.Add('Ğåçóëüòàò='+FloatToStr(Round(r)))
else
Memo1.Lines.Add('Ğåçóëüòàò='+FloatToStrF(r,ffFixed,8,4));
end;
end;

end.
