unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Button1: TButton;
    Edit4: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
function f1(x:extended):extended;
implementation

{$R *.dfm}

function f1;
begin
 result:=sqr(sin(x));
end;

procedure TForm1.Button1Click(Sender: TObject);
var a,b,s:extended;
n:integer;
begin
 a:=strtofloat(edit1.Text);
 b:=strtofloat(edit2.Text);
 n:=strtoint(edit3.Text);
 s:=int(a,b,n,f1);
 edit4.Text:=floattostr(s);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
edit4.Clear;
end;

end.
