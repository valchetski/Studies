unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Unit3;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Button1: TButton;
    Edit2: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  T:TClass;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
StringGrid1.Cells[0,0]:='a';
StringGrid1.Cells[0,1]:='b';
StringGrid1.Cells[0,2]:='c';
StringGrid1.Cells[0,3]:='d';
StringGrid1.Cells[0,4]:='e';
StringGrid1.Cells[1,0]:='1';
StringGrid1.Cells[1,1]:='1';
StringGrid1.Cells[1,2]:='1';
StringGrid1.Cells[1,3]:='1';
StringGrid1.Cells[1,4]:='1';
end;

procedure TForm1.Button1Click(Sender: TObject);
var
 i:byte;
 Ch:char;
 strp:string;
 m:extended;
begin
 T:=TClass.Create();
 strp:=Edit1.Text;
 for i:=0 to 4 do
  begin
   Ch:=StringGrid1.Cells[0,i][1];
   T.mszn[ch]:=StrToFloat(StringGrid1.Cells[1,i]);
  end;
 m:=T.AV(strp);
 Edit2.Text:=FloatToStr(m);
 T.Free;
end;


end.
