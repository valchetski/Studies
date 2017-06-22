unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Buttons, Unit2, Math;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Memo1: TMemo;
    RadioGroup1: TRadioGroup;
    BitBtn1: TBitBtn;
    BitBtn2: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  implementation
{$R *.dfm}
function sx(x:extended):extended;
var b,s,a,e:real; n:integer; k:integer;
begin
n:=0; b:=ln(9); s:=1; a:=1; k:=-1;
try
while (abs(a)>e) do begin
n:=n+1;
a:=(a*b*x)/n;
s:=s+a;
end;
Result:=s;
except
on EInvalidOp do
k:=MessageDlg('������������ �������� � ��������� ������. �+� ���������� ����������?',mtError,[mbYes,mbNo],0);
on EOverFlow do
k:=MessageDlg('������������ ��� ���������� �������� �+� ��������� ������! ���������� ����������?',mtError,[mbYes,mbNo],0);
else
k:=MessageDlg('�������� ����������� �������������� ��������!�+� ���������� ����������?',mtError,[mbYes,mbNo],0);
end;
case k of
mrYes : Result:=0;
mrNo : Halt(1);
end;
end;

function yx(x:extended):extended;
begin
Result:=power(9,x);
end;

procedure TForm1.FormCreate(Sender: TObject);
var e:extended;
begin
Memo1.Clear;
Edit1.Text:='1';
Edit2.Text:='3';
Edit3.Text:='0,001';
Edit4.Text:='5';
RadioGroup1.ItemIndex:=0;
e:=StrToFloat(Edit3.Text);
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var xn,xk,e:extended; m:word;
begin
Memo1.Clear;
Memo1.Lines.Add('�.�. �6 ��.��.252005 ���������� �.�.');
xn:=StrToFloat(Edit1.Text);
Memo1.Lines.Add('xn='+FloatToStrf(xn,ffFixed,8,4));
xk:=StrToFloat(Edit2.Text);
Memo1.Lines.Add('xk='+FloatToStrf(xk,ffFixed,8,4));
e:=StrToFloat(Edit3.Text);
Memo1.Lines.Add('e='+FloatToStrf(e,ffFixed,8,4));
m:=StrToInt(Edit4.Text);
Memo1.Lines.Add('m='+IntToStr(m));
case RadioGroup1.ItemIndex of
0:begin
Memo1.Lines.Add('������ S');
Tabl(sx,xn,xk,m,Memo1);
end;
1:begin
Memo1.Lines.Add('������ Y');
Tabl(yx,xn,xk,m,Memo1);
end;
end;
end;
end.
