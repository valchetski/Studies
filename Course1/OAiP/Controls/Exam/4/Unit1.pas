unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    StringGrid2: TStringGrid;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  N:word;
  a: mas;
  ob: TClass;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
 i: word;
begin
N:=14;
randomize;
for i:=1 to n do
        begin
         StringGrid1.Cells[0,i-1]:=IntToStr(random(30));
         StringGrid1.Cells[1,i-1]:=IntToStr(random(100));
        end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 i:word;
begin
for i:=1 to n do
begin
 a[i].key:=StrToInt(StringGrid1.Cells[0,i-1]);
 a[i].f:=StrToInt(StringGrid1.Cells[1,i-1]);
end;
ob:= TClass.Create();
ob.qsort(a,1,n);
for i:=1 to n do
begin
 StringGrid2.Cells[0,i-1]:=IntToStr(a[i].key);
 StringGrid2.Cells[1,i-1]:=IntToStr(a[i].f);
end;
ob.Free;
end;

end.
