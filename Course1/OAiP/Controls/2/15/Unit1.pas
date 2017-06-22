unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    Memo1: TMemo;
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
  zad:Tzad;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var I:word;
begin
   stringgrid1.Cells[0,0]:='Имя';
   stringgrid1.Cells[1,0]:='Ключ';
   n:=stringgrid1.RowCount-1;
   for i:=1 to n do
   begin
      stringgrid1.Cells[1,i]:=inttostr(i+10);
      stringgrid1.Cells[0,i]:=chr(100+i)+chr(150+i);
   end;
   memo1.Clear;

end;

procedure TForm1.Button1Click(Sender: TObject);
var i:word; inf:Tinf; a:mas;
begin
   zad:=Tzad.create;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      a[i]:=inf;
   end;
   zad.Blns(a,n);

   inf:=zad.mink;
   memo1.Lines.Add('Имя: '+inf.f+'  ключ: '
         +inttostr(inf.k));

   zad.free;


end;

end.
