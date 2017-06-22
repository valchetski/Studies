unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Label1: TLabel;
    StringGrid2: TStringGrid;
    Button1: TButton;
    Button2: TButton;
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
  n,i:integer;
  a:Pmas; n1:integer;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
Randomize;
Edit1.Text:='5'; N:=StrToInt(Edit1.text);
For i:=1 to n do stringGrid1.Cells[i-1,0]:=IntToStr(Random(10));
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
N:=StrToInt(Edit1.text);  StringGrid1.ColCount:=n;
For i:=1 to n do stringGrid1.Cells[i-1,0]:=IntToStr(Random(10));
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
 GetMem(a,4*n);
 For I:=0 to n-1 do A[i]:=StrToInt(StringGrid1.Cells[i,0]);
 Resh(n,a,n1);
 StringGrid2.ColCount:=n1+1;
 for i:=0 to n1 do StringGrid2.Cells[i,0]:=IntToStr(a[i]);
 FreeMem(a,4*n);
end;

end.
