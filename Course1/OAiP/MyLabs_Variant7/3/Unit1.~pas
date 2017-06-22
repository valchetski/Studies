unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math;

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
    Label5: TLabel;
    Memo1: TMemo;
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
Edit1.Text:='0,2';
Edit2.Text:='1';
Edit3.Text:='0,2';
Edit4.Text:='0,001';
end;

procedure TForm1.Button1Click(Sender: TObject);
var xn,xk,x,h,e,a,s,y:extended;
n:integer;
begin
Memo1.Clear;
Memo1.Lines.Add('Л.р. №3 ст. гр. 252005 Волчецкого А.М.');
xn:=StrToFloat(Edit1.Text); 
Memo1.Lines.Add(' xn='+FloatToStrF(xn,ffFixed,8,2));
xk:=StrToFloat(Edit2.Text);
Memo1.Lines.Add(' xk='+FloatToStrF(xk,ffFixed,8,2));
h:=StrToFloat(Edit3.Text);
Memo1.Lines.Add(' h='+FloatToStrF(h,ffFixed,8,3));
e:=StrToFloat(Edit4.Text);
Memo1.Lines.Add(' e='+FloatToStrF(e,ffFixed,8,5));
x:=xn;
repeat
a:=1;  S:=1;  n:=0;
while (abs(a)>e) do begin
n:=n+1;
a:=a*ln(9)*x/n ;
s:=s+a;
end;
y:=power(9,x);
Memo1.Lines.Add('при x='+FloatToStrF(x,ffFixed,6,2)+'   сумма ='
+ FloatToStrF(s,ffFixed,8,4)+' y ='+ FloatToStrF(y,ffFixed,8,4)
+'   N ='+IntToStr(n));
x:=x+h;
until x>(xk+h/2)
end;
end.
