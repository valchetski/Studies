unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
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
var i:word;
begin
   edit1.text:='ab+c*d-';
   edit2.clear;
   n:=stringgrid1.RowCount-1;
   stringgrid1.Cells[0,0]:='Переменная';
   stringgrid1.Cells[1,0]:='Значение';
   for i:=1 to n do
   begin
      stringgrid1.Cells[0,i]:=chr(96+i);
      stringgrid1.Cells[1,i]:=inttostr(1+random(10));
   end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var i:word;
begin
   zad:=Tzad.Create;
   with stringgrid1 do
   for i:=1 to n do
      zad.zn[cells[0,i][1]]:=strtofloat(cells[1,i]);
   edit2.Text:=floattostr(zad.AV(edit1.Text));
   zad.Free;
end;

end.
