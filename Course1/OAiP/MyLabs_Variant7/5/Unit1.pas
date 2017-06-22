unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, Grids;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Label1: TLabel;
    Label2: TLabel;
    StringGrid2: TStringGrid;
    BitBtn1: TBitBtn;
    BitBtn2: TBitBtn;
    Button1: TButton;
    Edit1: TEdit;
    Label3: TLabel;
    Button2: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
const N=6;
Type
Mas=array[1..1] of integer;
PMas=^Mas;
var
  Form1: TForm1;
  a:Pmas;
  i,j,t,m,s:integer;
implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
M:=StrToInt(Edit1.Text);
StringGrid1.ColCount:=m;
StringGrid2.ColCount:=m
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
randomize;
for j:=1 to m+1 do
StringGrid1.Cells[j-1,0]:=IntToStr(Random(50)-25);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
m:=6;
Edit1.Text:=IntToStr(m);
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
begin
m:=StrToInt(Edit1.Text);
GetMem(a,M*Sizeof(integer));
for i:=1 to m do
a[i]:=StrToInt(StringGrid1.Cells[i-1,0]);
s:=0;
 for i:=1 to m do
  if a[i]<0 then
   begin
    j:=i;
    while j>s+1 do
     begin
      t:=a[j];
      a[j]:=a[j-1];
      a[j-1]:=t;
      dec(j);
     end;
    inc(m);
   end;
   for i:=1 to m do
   StringGrid2.Cells[i-1,0]:=IntToStr(a[i]);
   FreeMem(a,M*sizeof(integer));
   end;

end.
