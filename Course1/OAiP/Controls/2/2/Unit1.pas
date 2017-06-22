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
    Button1: TButton;
    Button2: TButton;
    Edit2: TEdit;
    Label2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;
  n:Integer;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var i,k:integer;
begin
   zad:=Tzad.create;
   edit1.clear;
   edit2.clear;
   with stringgrid1 do
   begin
      n:=rowcount-1;
      zad.n:=n;
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

procedure TForm1.Button1Click(Sender: TObject);
var I:word;
begin
   with stringgrid1 do
   for i:=1 to n do
      begin
         zad.a[i].f:=Cells[0,i];
         zad.a[i].k:=strtoint(Cells[1,i]);
      end;
   zad.sort;

end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
   zad.Free;
end;

procedure TForm1.Button2Click(Sender: TObject);
var k:Tkey;  rez:Tinf;
begin
   k:=strtoint(edit1.Text);
   rez:=zad.poiskd(k);
   if rez.k<>nok then edit2.Text:=rez.f;



end;

end.
