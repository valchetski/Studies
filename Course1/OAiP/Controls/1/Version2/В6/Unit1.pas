unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, TeEngine, Series, ExtCtrls, TeeProcs, Chart, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Chart1: TChart;
    Series1: TLineSeries;
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
  e : extended;
implementation

{$R *.dfm}
function fx(x:extended):extended;
var w, a : extended;
    n : integer;
begin
w:=0; a:=1; n:=0;
repeat
inc(n);
a:=a*x/n;
w:=w+a;
until abs(a)<e;
Result:=w;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Edit2.Clear;
Edit3.Clear;
Edit4.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
var a, b : extended;
    n : integer;
begin
a:=StrToFloat(Edit1.Text);
b:=StrToFloat(Edit2.Text);
e:=StrToFloat(Edit3.Text);
n:=StrToInt(Edit4.Text);
graph(a,b,e,n,fx,Chart1);
end;

end.
