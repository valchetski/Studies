unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
    BitBtn1: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;
  n:word;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var i,k:word;
begin
   stringgrid1.Cells[0,0]:='Имя';
   stringgrid1.Cells[1,0]:='Ключ';
   stringgrid2.Cells[0,0]:='Имя';
   stringgrid2.Cells[1,0]:='Ключ';
   n:=stringgrid1.RowCount-1;
   randomize;
   for i:=1 to n do
   begin
      k:=1+random(100);
      stringgrid1.cells[1,i]:=inttostr(k);
      stringgrid1.cells[0,i]:=chr(k)+chr(k+50)+chr(k+75);
   end;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var i:word; inf:Tinf;
begin
   zad:=Tzad.create;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.cells[0,i];
      inf.k:=strtoint(stringgrid1.cells[1,i]);
      zad.addk(inf);
   end;

   zad.sortslip;
   
   for i:=1 to n do
   begin
      zad.read1(inf);
      stringgrid2.cells[1,i]:=inttostr(inf.k);
      stringgrid2.cells[0,i]:=inf.f;
   end;

   zad.Free;


end;

end.
