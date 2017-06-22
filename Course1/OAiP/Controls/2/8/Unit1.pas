unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids,unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
    Edit1: TEdit;
    Edit2: TEdit;
    Button1: TButton;
    Button2: TButton;
    StringGrid3: TStringGrid;
    Button3: TButton;
    Button4: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  n:word;
  zad:Tzad;
  inf:Tinf;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var i,k:word;
begin
   edit1.clear;
   edit2.clear;
   stringgrid1.Cells[0,0]:='Имя';
   stringgrid2.Cells[0,0]:='Ключ';
   stringgrid3.Cells[0,0]:='Имя';
   stringgrid3.Cells[0,1]:='Ключ';
   n:=stringgrid1.colcount-1;
   randomize;
   for i:=1 to n do
   begin
      k:=1+random(100);
      stringgrid1.Cells[i,0]:=chr(k)+chr(k+50)+chr(k+75);
      stringgrid2.Cells[i,0]:=inttostr(k);
   end;
end;

procedure TForm1.Button3Click(Sender: TObject);
var  i:word;
begin
   zad:=Tzad.create;
   for i:=1 to n do
   begin
      inf.f:= stringgrid1.Cells[i,0];
      inf.k:=strtoint(stringgrid2.Cells[i,0]);
      zad.addk(inf);
   end;
   zad.print(stringgrid3);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
   inf.f:=edit1.Text;
   inf.k:=strtoint(edit2.Text);
   zad.addk(inf);
   stringgrid3.ColCount:=stringgrid3.ColCount+1;
   zad.print(stringgrid3);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
   zad.read1(inf);
   edit1.Text:=inf.f;
   edit2.Text:=inttostr(inf.k);
   stringgrid3.ColCount:=stringgrid3.ColCount-1;
   zad.print(stringgrid3);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
   zad.print(stringgrid3);
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
   zad.Free;
end;

end.
