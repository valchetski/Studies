unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,Unit2, Grids;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    StringGrid1: TStringGrid;
    Memo1: TMemo;
    Memo2: TMemo;
    Memo3: TMemo;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Edit1: TEdit;
    Button6: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
   procedure Button4Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
   zad: Tzad;
   n:integer;
implementation

{$R *.dfm}
procedure TForm1.FormCreate(Sender: TObject);
var i,j:integer;
begin
  Memo1.Clear; Memo2.Clear; Memo3.Clear; Edit1.Clear;
  StringGrid1.Cells[0,0]:='Фамилия'; StringGrid1.cells[1,0]:='Номер';
  n:=stringgrid1.RowCount-1;
  randomize;
  for i:=1 to n do begin
    j:=-50+random(100);
    stringgrid1.Cells[1,i]:=inttostr(j);
    stringgrid1.Cells[0,i]:=chr(j)+chr(10+j)+chr(100+j);
  end;
  zad:=Tzad.create;
end;

procedure TForm1.Button1Click(Sender: TObject);
var i:integer;
begin
  if sp1<>nil then
  for i:=1 to n do zad.Reads(b);
  for i:=1 to n do begin
    inf.i1:=StringGrid1.cells[0,i];
    inf.key:=StrToInt(StringGrid1.cells[1,i]);
    zad.Adds(inf);
  end;
  StringGrid1.RowCount:=n+1;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  n:=n+1;
  inf.I1:=StringGrid1.Cells[0,n-1];
  inf.key:=StrToInt(StringGrid1.cells[1,n-1]);
  zad.Adds(inf);
  StringGrid1.RowCount:=n+1;
end;

procedure TForm1.Button5Click(Sender: TObject);
var i:integer;
begin
  memo1.Clear;
  for i:=1 to n do begin
    StringGrid1.Cells[0,i]:=StringGrid1.Cells[0,i+1];
    StringGrid1.Cells[1,i]:=StringGrid1.Cells[1,i+1];
  end;
  n:=n-1;
  StringGrid1.RowCount:=n+1;
  zad.Reads(b);
  zad.Print(Memo1,sp1);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  Memo1.clear;
  zad.SortBublInf;
  zad.Print(Memo1,sp1);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  zad.resh(sp1,sp2,sp3);
  zad.Print(Memo2,sp2);
  zad.Print(Memo3,sp3);
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  Memo1.Clear;
  zad.Print(memo1,zad.Poisk(StrToInt(Edit1.Text)));
end;

end.
