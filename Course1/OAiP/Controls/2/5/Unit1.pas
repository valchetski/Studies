unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Label1: TLabel;
    Edit2: TEdit;
    Label2: TLabel;
    Memo1: TMemo;
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
  Wmax:Extended;

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
var i:word;
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
      cmax:=0;
      s:=[];
      sopt:=[];
      pp(1);
      memo1.Clear;
      memo1.Lines.Add('Номер  Вес    Цена');
      for i:=1 to n do
         if i in sopt then
            memo1.Lines.Add(inttostr(i)+':    '+inttostr(a[i].w)
               +'   '+inttostr(a[i].c));
      memo1.Lines.Add('     Wmax='+inttostr(wmax)+'  Cmax='
         +inttostr(cmax));
   end;


end;

end.
