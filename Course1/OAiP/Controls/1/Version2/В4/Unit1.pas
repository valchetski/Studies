unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Label1: TLabel;
    Edit1: TEdit;
    Label2: TLabel;
    Button1: TButton;
    Button2: TButton;
    Edit2: TEdit;
    Label3: TLabel;
    StringGrid2: TStringGrid;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
type
 Mas=array[1..1] of integer;
 PMas=^Mas;
var
  Form1: TForm1;
  n, n1, i : integer;
  a : PMas;
implementation
uses Unit2;

{$R *.dfm}
{$R-}
procedure TForm1.FormCreate(Sender: TObject);
begin

Edit1.Clear;
Edit2.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
n:=StrToInt(Edit1.Text);
StringGrid1.ColCount:=n;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
n1:=0;
GetMem(a,n*4);
for i:=1 to n do
a[i]:=StrToInt(StringGrid1.Cells[i-1,0]);
udal(a,n,n1);
Edit2.Text:=IntToStr(n1);
StringGrid2.ColCount:=n1;
for i:=1 to n1 do
StringGrid2.Cells[i-1,0]:=IntToStr(a[i]);
FreeMem(a,4*n);
end;
end.
