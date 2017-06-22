unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, StdCtrls, Buttons, Grids;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
    BitBtn1: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ob: TClass;
  n: word;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
 i:word;
begin
n:= StringGrid1.RowCount;
randomize;
for i:=0 to n-1 do StringGrid1.Cells[0,i]:=IntToStr(Random(50));
StringGrid1.Cells[1,0]:='Werty';
StringGrid1.Cells[1,1]:='Terfj';
StringGrid1.Cells[1,2]:='Jnfhgr';
StringGrid1.Cells[1,3]:='Nhfgt';
StringGrid1.Cells[1,4]:='Nhgfged';
StringGrid1.Cells[1,5]:='Jhfh';
StringGrid1.Cells[1,6]:='Jjnff';
StringGrid1.Cells[1,7]:='Hhfhd';
StringGrid1.Cells[1,8]:='BFdhd';
StringGrid1.Cells[1,9]:='Jjfbjf';
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var
inf:Tinf;
i:word;
begin
ob:=TClass.Create;
for i:=0 to n-1 do
   begin
    inf.k:=StrToInt(StringGrid1.Cells[0,i]);
    inf.f:=StringGrid1.Cells[1,i];
    ob.Add(inf);
   end;
ob.Add(inf);
ob.Sort();
ob.Read(inf);
for i:=0 to n-1 do
   begin
    ob.Read(inf);
    StringGrid2.Cells[0,i]:=IntToStr(inf.k);
    StringGrid2.Cells[1,i]:=inf.f;
   end;

end;

end.
