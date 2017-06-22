unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, TeEngine, Series, ExtCtrls, TeeProcs, Chart, Unit2;

type
  TForm1 = class(TForm)
    Chart1: TChart;
    Series1: TLineSeries;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
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
  a,b,e:extended; n:integer;
implementation

{$R *.dfm}

Function Sx(x:extended):extended;
var k:integer; b,s:Extended;
begin
k:=1; s:=0; b:=1;
while Abs(b)>e do
  begin
    b:=b*x/k;
    S:=S+b;
    k:=k+1;
  end;
Result:=s;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Text:='1'; Edit2.Text:='5';
Edit3.Text:='1e-3'; Edit4.Text:='40';
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
 a:=StrToFloat(Edit1.Text);
 b:=StrToFloat(Edit2.Text);
 e:=StrToFloat(Edit3.Text);
 n:=StrToInt(Edit4.text);
 resh(a,b,n,sx,chart1);
end;

end.
