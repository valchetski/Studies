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
    Edit3: TEdit;
    Label2: TLabel;
    Button1: TButton;
    Button2: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  n:word;
  zad:Tzad;
  m0:word;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var i,k:word;
begin
   edit1.Text:='16';
   edit2.Clear;
   edit3.Clear;
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

procedure TForm1.Button2Click(Sender: TObject);
var inf:Tinf;
begin
   inf.k:=strtoint(edit2.Text);
   inf:=zad.read(inf.k);
   if inf.k<>nok then
      edit3.Text:=inf.f
   else showmessage('Не найдено!');
   zad.Free;

end;

procedure TForm1.Button1Click(Sender: TObject);
var i:Word; inf:Tinf;
begin
   m0:=strtoint(edit1.Text);
   zad:=Tzad.create(m0);
   for i:=1 to zad.m-1 do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      zad.add(inf);
   end;
end;

end.
