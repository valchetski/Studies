unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Edit2: TEdit;
    Button1: TButton;
    Button2: TButton;
    Edit3: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  k: word;
  hash: THash;

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
StringGrid1.Cells[1,0]:='qqqq';
StringGrid1.Cells[1,1]:='wwww';
StringGrid1.Cells[1,2]:='eeee';
StringGrid1.Cells[1,3]:='rrrr';
StringGrid1.Cells[1,4]:='tttt';
StringGrid1.Cells[1,5]:='yyyy';
StringGrid1.Cells[1,6]:='uuuu';
StringGrid1.Cells[1,7]:='iiii';
StringGrid1.Cells[1,8]:='oooo';
StringGrid1.Cells[1,9]:='pppp';
end;

procedure TForm1.Button2Click(Sender: TObject);
var
i:word;
inf: TInf;

begin
hash := THash.create(StrToInt(Edit2.Text));
for i:=1 to k do
 begin
  inf.f:=StringGrid1.Cells[1,i-1];
  inf.k:=StrToInt(StringGrid1.Cells[0,i-1]);
  hash.add(inf);
 end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 inf:Tinf;
begin
hash.read(StrToInt(Edit1.Text),inf);
Edit3.Text:=inf.f;
end;

end.
