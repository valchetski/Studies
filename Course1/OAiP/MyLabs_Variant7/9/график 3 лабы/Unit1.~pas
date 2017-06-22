unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, TeEngine, Series, ExtCtrls, TeeProcs, Chart, ComCtrls,Clipbrd, Unit2;

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    Image1: TImage;
    Chart1: TChart;
    Series1: TLineSeries;
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Edit2: TEdit;
    Edit3: TEdit;
    Label3: TLabel;
    Button2: TButton;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Edit4: TEdit;
    Edit5: TEdit;
    Edit6: TEdit;
    Edit7: TEdit;
    Button1: TButton;
    Button3: TButton;
    Button4: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
      private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  xn,xk,x:extended;
  n,xomin,yomin,xomax,yomax:integer;
  function sx(x:extended):extended;
implementation

{$R *.dfm}
function sx;
  var k,i:word; sum,b,a,h:extended;
begin
  k:=1; a:=1; sum:=0; b:=ln(9);
  while k<n do begin
    a:=a*b*x/k;
    sum:=sum+a;
    inc(k);
  end;
  Result:=sum;
end;


procedure TForm1.FormCreate(Sender: TObject);
begin
  Edit1.Text:='0,1'; Edit2.Text:='3'; Edit3.Text:='10';
  Edit4.Text:='0'; Edit5.Text:='6'; Edit6.Text:='0'; Edit7.Text:='6';
end;

procedure TForm1.Button2Click(Sender: TObject); //рисует график в Image
var xmax,ymax,i,x1,y1:integer; y,h,hx,hy:extended;
begin
  xn:=StrToFloat(Edit1.Text);
  xk:=StrToFloat(Edit2.Text);
  n:=StrToInt(Edit3.Text);
  xomin:=StrToInt(Edit4.Text);
  xomax:=StrToInt(Edit5.Text);
  yomin:=StrToInt(Edit6.Text);
  yomax:=StrToInt(Edit7.Text);
  Image(xn,xk,n,xomin,xomax,yomin,yomax,sx,Image1);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
ClipBoard.Assign(Image1.Picture);
end;

procedure TForm1.Button3Click(Sender: TObject); //Рисует график в Char
var h,y:extended; i:word;
begin
  xn:=StrToFloat(Edit1.Text);
  xk:=StrToFloat(Edit2.Text);
  n:=StrToInt(Edit3.Text);
  xomin:=StrToInt(Edit4.Text);
  xomax:=StrToInt(Edit5.Text);
  yomin:=StrToInt(Edit6.Text);
  yomax:=StrToInt(Edit7.Text);
  Char(xn,xk,n,xomin,xomax,yomin,yomax,sx,Chart1);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  Chart1.CopyToClipBoardMetaFile(True);
end;

end.
