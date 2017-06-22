unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Label1: TLabel;
    Memo1: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
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
var i,k:word;
begin
   edit1.Clear;
   memo1.Clear;
   stringgrid1.Cells[0,0]:='Имя';
   stringgrid1.Cells[1,0]:='Ключ';
   n:=stringgrid1.RowCount-1;
   randomize;
   for i:=1 to n do
   begin
      k:=1+random(100);
      stringgrid1.Cells[1,i]:=inttostr(k);
      stringgrid1.Cells[0,i]:=chr(k)+chr(k+50)+chr(k+75);
   end;

end;

procedure TForm1.Button1Click(Sender: TObject);
var i:word; inf:Tinf;
begin
   zad:=Tzad.create;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      zad.AddB(inf);
   end;


end;

procedure TForm1.Button2Click(Sender: TObject);
var inf:Tinf;
begin
   inf.k:=strtoint(edit1.Text);
   inf:=zad.poiskb(inf.k);
   if inf.k<>nok then
      memo1.Lines.Add('Имя: '+inf.f+'  ключ: '
         +inttostr(inf.k))
   else
      showmessage('Не найдено!');
   zad.free;

end;

end.
