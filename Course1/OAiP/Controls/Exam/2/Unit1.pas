unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Button1: TButton;
    Edit2: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ob: TClass;
  a:mas;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
 i:word;
begin
randomize;
for i:=1 to 15 do
 begin
  StringGrid1.Cells[0,i-1]:=IntToStr(i*3);
  StringGrid1.Cells[1,i-1]:=IntToStr(random(100));
 end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 i:word;
begin
for i:=1 to 15 do
 begin
  a[i].k:=StrToInt(StringGrid1.Cells[0,i-1]);
  a[i].i:=StrToInt(StringGrid1.Cells[1,i-1]);
 end;
ob:= TClass.Create(a);
i:=StrToInt(Edit1.Text);
Edit2.Text:= IntToStr(ob.Find(i,1,15));
ob.Free;
end;

end.
