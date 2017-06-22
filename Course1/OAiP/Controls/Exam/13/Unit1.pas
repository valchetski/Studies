unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
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
  n:word;
  tr: TTree;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
 i:word;
begin
n:=10;
randomize;
for i:=1 to n do
  StringGrid1.Cells[0,i-1]:=IntToStr(random(30));
StringGrid1.Cells[1,0]:='yyuit';
StringGrid1.Cells[1,1]:='uytuyt';
StringGrid1.Cells[1,2]:='yutyut';
StringGrid1.Cells[1,3]:='yutyu';
StringGrid1.Cells[1,4]:='tut';
StringGrid1.Cells[1,5]:='jhgjh';
StringGrid1.Cells[1,6]:='gjhg';
StringGrid1.Cells[1,7]:='jhgjh';
StringGrid1.Cells[1,8]:='hhhg';
StringGrid1.Cells[1,9]:='jgjg';
end;

procedure TForm1.Button1Click(Sender: TObject);
var
inf: Tinf;
i:word;
begin
tr:=TTree.Create();
for i:=1 to n do
 begin
  inf.k:=StrToInt(StringGrid1.Cells[0,i-1]);
  inf.f:=StringGrid1.Cells[1,i-1];
  tr.AddB(inf);
 end;

tr.Wrt1B(StringGrid2);
end;

end.
