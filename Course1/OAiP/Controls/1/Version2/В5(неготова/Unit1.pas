unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Edit3: TEdit;
    Image1: TImage;
    Button1: TButton;
    Edit4: TEdit;
    Label4: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  n : integer;
implementation

{$R *.dfm}

function fx(x : extended) : extended;
var a,w:extended;
    k: integer;
begin
a:=0; w:=1; k:=1;
while k<n do begin
w:=w*x/k;
a:=a+w;
inc(k);
end;
Result:=a;
end;

procedure TForm1.Button1Click(Sender: TObject);
var a,b : extended;
    p : integer;
begin
a:=StrToFloat(Edit1.Text);
b:=StrToFloat(Edit2.Text);
n:=StrToInt(Edit3.Text);
p:=StrToInt(edit4.Text);
graf(a,b,n,p,fx,Image1);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Edit2.Clear;
Edit3.Clear;
edit4.Clear;
end;

end.
