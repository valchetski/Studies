unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,Unit2, StdCtrls;
  function sx(x:extended):extended;
type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Button1: TButton;
    Memo1: TMemo;
    SaveDialog1: TSaveDialog;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  m: integer;

implementation

{$R *.dfm}
 function sx;
 var s,r:extended; k: integer;
 begin
 k:=1; s:=x; r:=0;
 while k<=m do begin
 Inc(k);
 s:=s*(x/(k*(k-1)));
 r:=r+s
 end;
 Result:=r;
 end;
procedure TForm1.Button1Click(Sender: TObject);
var a,b,n: integer; Fl: TextFile;
begin
Memo1.Clear;
if SaveDialog1.Execute then AssignFile(Fl,SaveDialog1.FileName);
Rewrite(Fl);
a:=StrToInt(Edit1.Text);
b:=StrToInt(Edit2.Text);
n:=StrToInt(Edit3.Text);
m:=StrToInt(Edit4.Text);
Tabl(a,b,n,sx,Fl);
CloseFile(Fl);
end;

end.
