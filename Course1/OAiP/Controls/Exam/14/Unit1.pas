unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    Button2: TButton;
    Memo1: TMemo;
    Edit1: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
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
 StringGrid1.Cells[1,0]:='jhjh';
 StringGrid1.Cells[1,1]:='jhjh';
 StringGrid1.Cells[1,2]:='bnbn';
 StringGrid1.Cells[1,3]:='nbn';
 StringGrid1.Cells[1,4]:='uitg';
 StringGrid1.Cells[1,5]:='jgh';
 StringGrid1.Cells[1,6]:='utg';
 StringGrid1.Cells[1,7]:='mnbnmg';
 StringGrid1.Cells[1,8]:='uyfju';
 StringGrid1.Cells[1,9]:='ugju';
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 i:word;
 inf:TInf;
begin
 tr:=TTree.Create();
 for i:=1 to n do
  begin
   inf.k:=StrToInt(StringGrid1.Cells[0,i-1]);
   inf.f:=StringGrid1.Cells[1,i-1];
   tr.AddB(inf);
  end;
end;

procedure TForm1.Button2Click(Sender: TObject);
var
 s:TInf;
begin
s:=tr.PoiskB(StrToInt(Edit1.Text));
if s.f = 'Not Found!' then Memo1.Lines.Add(s.f)
else Memo1.Lines.Add(IntToStr(s.k)+'  '+s.f);
end;

end.
