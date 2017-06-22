unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Buttons, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Label1: TLabel;
    StringGrid2: TStringGrid;
    BitBtn1: TBitBtn;
    Edit2: TEdit;
    Label2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure BitBtn1Click(Sender: TObject);
    procedure StringGrid1KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  n,n1:integer;
   a:pmas;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
 edit2.Clear;
 n:=strtoint(edit1.text);
 stringgrid1.ColCount:=n;
 stringgrid2.Visible:=false;
end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
 if key=#13 then
 begin
 n:=strtoint(edit1.text);
 stringgrid1.ColCount:=n;
 end;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
begin
form1.Close;
end;

procedure TForm1.StringGrid1KeyPress(Sender: TObject; var Key: Char);
var i:integer;
begin
if key=#13 then
begin
stringgrid2.Visible:=true;
getmem(a,4*n);
for i:=1 to n do a[i]:=strtoint(stringgrid1.Cells[i-1,0]);
n1:=n;
func1(a,n1);
stringgrid2.ColCount:=n1;
i:=1;
while i<=n1 do
begin
 stringgrid2.Cells[i-1,0]:=inttostr(a[i]);
 i:=i+1;
end;
edit2.text:=inttostr(n1);
freemem(a,4*n);
end;
end;

end.
