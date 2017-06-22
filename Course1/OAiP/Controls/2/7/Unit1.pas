unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
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
  zad:Tzad;
  n:integer;

implementation

{$R *.dfm}





procedure TForm1.FormCreate(Sender: TObject);
var i:word;
begin
   edit1.Text:='10';
   edit2.Text:='40';
   memo1.Clear;
   stringgrid1.Cells[1,0]:='Вес';
   stringgrid1.Cells[2,0]:='Цена';
   n:=stringgrid1.RowCount-1;
   randomize;
   for i:=1 to n do
   begin
      stringgrid1.Cells[0,i]:=inttostr(i);
      stringgrid1.Cells[1,i]:=inttostr(1+random(15));
      stringgrid1.Cells[2,i]:=inttostr(1+random(30));
   end;
end;


procedure TForm1.Button1Click(Sender: TObject);
var i:Integer;
begin
   zad:=Tzad.Create;
   with zad do begin
      n:=strtoint(edit1.Text);
      for i:=1 to n do
      begin
         a[i].w:=strtoint(stringgrid1.Cells[1,i]);
         a[i].c:=strtoint(stringgrid1.Cells[2,i]);
      end;
      wmax:=strtoint(edit2.Text);
      minw;
      memo1.Clear;
      memo1.Lines.Add('Номер  Вес    Цена');
      for i:=1 to n do
         if i in sopt then
            memo1.Lines.Add(inttostr(i)+':          '+inttostr(a[i].w)
               +'         '+inttostr(a[i].c));
      memo1.Lines.Add('Wmax='+inttostr(wmax)+'  Cmax='
         +inttostr(cmax));
   end;

end;

end.
