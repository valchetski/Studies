unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    StringGrid2: TStringGrid;
    Button2: TButton;
    StringGrid1: TStringGrid;
    StringGrid3: TStringGrid;
    Button1: TButton;
    Button3: TButton;
    Button4: TButton;
    Edit1: TEdit;
    Edit2: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  k: word;
  List: TList;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
 i:word;
begin
k:=10;
randomize;
for i:=1 to k do
  StringGrid1.Cells[0,i-1]:=IntToStr(random(30));
StringGrid2.Cells[0,0]:='qqqq';
StringGrid2.Cells[0,1]:='wwww';
StringGrid2.Cells[0,2]:='eeee';
StringGrid2.Cells[0,3]:='rrrr';
StringGrid2.Cells[0,4]:='tttt';
StringGrid2.Cells[0,5]:='yyyy';
StringGrid2.Cells[0,6]:='uuuu';
StringGrid2.Cells[0,7]:='iiii';
StringGrid2.Cells[0,8]:='oooo';
StringGrid2.Cells[0,9]:='pppp';
end;

procedure TForm1.Button2Click(Sender: TObject);
var
i:word;
inf: TInf;

begin
List := TList.create();
for i:=1 to k do
 begin
  inf.f:=StringGrid2.Cells[0,i-1];
  inf.k:=StrToInt(StringGrid1.Cells[0,i-1]);
  List.add(inf);
 end;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
 inf:Tinf;
begin
List.read(inf);
Edit1.text:=IntToStr(inf.k);
Edit2.Text:=inf.f;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
List.Print(stringgrid3);
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 inf: TInf;
begin
inf.k:=StrToInt(Edit1.text);
inf.f:=Edit2.Text;
List.Add(inf);
end;

end.
