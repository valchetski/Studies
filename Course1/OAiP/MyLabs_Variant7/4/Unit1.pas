unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    StringGrid1: TStringGrid;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    StringGrid2: TStringGrid;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
  Const
  Nmax=10;
Type
Mas1=array[1..Nmax,1..Nmax] of integer;
Mas2=array[1..Nmax] of integer;
var
  Form1: TForm1;
  a:Mas1;
  b:Mas2;
  N,M,i,j,c,r,k:integer;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
N:=3;
M:=3;
Edit1.Text:=IntToStr(N);
Edit2.Text:=IntToStr(M);
StringGrid1.RowCount:=N+1;
StringGrid1.ColCount:=N+1;
StringGrid1.Cells[0,0]:='������ A';
for i:=1 to N do
StringGrid1.Cells[0,i]:='i='+IntToStr(i);
for j:=1 to M do
StringGrid1.Cells[j,0]:='j='+IntToStr(j);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
N:=StrToInt(Edit1.Text);
M:=StrToInt(Edit2.Text);
StringGrid1.RowCount:=N+1;
StringGrid1.ColCount:=M+1;
StringGrid1.Cells[0,0]:='������ A';
for i:=1 to N do
StringGrid1.Cells[0,i]:='i='+IntToStr(i);
for j:=1 to M do
StringGrid1.Cells[j,0]:='j='+IntToStr(j);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
randomize;
for i:=1 to N do
for j:=1 to M do begin
A[i,j]:=Random(10);
StringGrid1.Cells[j,i]:=IntToStr(A[i,j]);
end;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
{$R+}
try
for i:=1 to n do
for j:=1 to m do
a[i,j]:=StrToInt(StringGrid1.Cells[j,i]);
for i:=1 to N do begin
c:=0;
for j:=1 to M do
c:=c+StrToInt(StringGrid1.Cells[j,i]);
b[i]:=c;
end;
for k:=2 to N do begin
for i:=N downto k do
if b[i-1]>b[i] then
for j:=1 to M do begin
r:=a[i,j];
a[i,j]:=a[i-1,j];
a[i-1,j]:=r;
end;
end;
for i:=1 to N do begin
for j:=1 to M do
StringGrid2.Cells[j,i]:=IntToStr(a[i,j]);
end;
except
on ERangeError do begin ShowMessage('����� �� ������� �������. ��������� ������ �������'); Exit; end;
on EConvertError do begin ShowMessage('� ������ ����������� ��������, ���� ����� ������� �� ���������'); Exit; end;
else begin ShowMessage('�������� ����������� �������������� ��������!'); Exit; end;
end;
end;
end.