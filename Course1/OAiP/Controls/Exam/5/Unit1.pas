unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Memo1: TMemo;
    Button1: TButton;
    Edit1: TEdit;
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
  ob: TPerebor;
  ocm:extended;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var i:word;
begin
randomize;
ocm:=0;
for i:=0 to 9 do
        begin
         StringGrid1.Cells[0,i]:=IntToStr(random(50));
         StringGrid1.Cells[1,i]:=IntToStr(random(20));
        end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 i:word;
begin
ob:=TPerebor.Create();
with ob do
  begin
   n:=strToInt(Edit1.Text);
   ocm:=0;
   for i:=1 to n do
    begin
     a[i].w:=StrToInt(StringGrid1.Cells[0,i-1]);
     a[i].c:=StrToInt(StringGrid1.Cells[1,i-1]);
     ocm:=ocm+a[i].c;
    end;
   Wmax:=StrToInt(Edit2.Text);
   Cmax:=0;
   S:=[];
   Sopt:=[];
ob.vbrpp(1,0,ocm);
   Memo1.Lines.Add('#  wght  price ');
   for i:=1 to n do if i in Sopt then Memo1.Lines.Add(IntToStr(i)+'  '+FloatToStrF(a[i].w,ffFixed,8,2)+'  '+FloatToStrF (a[i].c,ffFixed,8,2));
   Memo1.Lines.Add('Cmax='+FloatToStrF (Cmax,ffFixed,8,2)+'  Wmax='+FloatToStrF (Wmax,ffFixed,8,2));
  end;
end;

end.
