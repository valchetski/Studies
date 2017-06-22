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
  n:word;
  zad:Tzad;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var I,k:word;
begin
   with stringgrid1 do
   begin
      n:=rowcount-1;
      Cells[1,0]:='Ключ';
      Cells[0,0]:='Имя';
      randomize;
      for i:=1 to n do
      begin
         k:=1+random(100);
         cells[1,i]:=inttostr(k);
         cells[0,i]:=chr(k)+chr(k+50)+chr(k+75);
      end;
   end;

end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var i:word;
begin
   zad:=Tzad.Create;
   zad.n:=n;
   with stringgrid1 do begin
   for i:=1 to n do
   begin
      zad.a[i].k:=strtoint(cells[1,i]);
      zad.a[i].f:=cells[0,i];
   end;
   end;
   zad.sortsliv;
   with stringgrid2 do begin
   for i:=1 to n do
   begin
      cells[1,i]:=inttostr(zad.a[i].k);
      cells[0,i]:=zad.a[i].f;
   end;
   end;
   zad.Free;

end;

end.
