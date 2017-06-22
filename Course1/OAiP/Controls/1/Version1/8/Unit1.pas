unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Buttons, TeEngine, Series, TeeProcs, Chart,Unit2;

type
  TForm1 = class(TForm)
    Chart1: TChart;
    Series1: TLineSeries;
    Series2: TLineSeries;
    BitBtn1: TBitBtn;
    LabeledEdit1: TLabeledEdit;
    LabeledEdit2: TLabeledEdit;
    LabeledEdit3: TLabeledEdit;
    BitBtn2: TBitBtn;
    procedure BitBtn2Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
function myfc(x:extended):Complex;
implementation

{$R *.dfm}
function myfc;
var a,b:complex;
begin
a.re:=2; a.im:=sqr(x);
b.re:=x; b.im:=-2;
result:=mulc(a,b);
end;

procedure TForm1.BitBtn2Click(Sender: TObject);
begin
form1.close;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var a,b:extended;
n:integer;
begin
a:=strtofloat(labelededit1.Text);
b:=strtofloat(labelededit2.Text);
n:=strtoint(labelededit3.Text);
 tabf(chart1,a,b,n,myfc);
end;

end.
