unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Label1: TLabel;
    Edit1: TEdit;
    Label2: TLabel;
    Edit2: TEdit;
    Label3: TLabel;
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
  a,b:extended;
  N:integer;

implementation

{$R *.dfm}

Function Sx(x:extended):extended;
var k:integer; b,s:Extended;
begin
k:=1; s:=0; b:=1;
while k<m do
  begin
    b:=b*x/k;
    S:=S+b;
    k:=k+1;
  end;
Result:=s;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Text:='1'; Edit2.Text:='5'; Edit3.Text:='10';
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
M:=5;
a:=StrToFloat(Edit1.text);
b:=StrToFloat(Edit2.text);
n:=StrToInt(Edit3.text);
Resh(a,b,n,sx,Image1);
end;

end.
