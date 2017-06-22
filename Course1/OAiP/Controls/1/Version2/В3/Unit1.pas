unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Button1: TButton;
    SaveDialog1: TSaveDialog;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  m : integer;
  Fl : textfile;
implementation
uses Unit2;
{$R *.dfm}

function fx(x : extended):extended;
var  s, w : extended;
     n : integer;
begin
w:=1; s:=0; n:=0;
while n<m do begin
inc(n);
w:=w*x/n;
s:=s+w;
end;
Result:=s;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Edit2.Clear;
Edit3.Clear;
Edit4.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
var a,b,n:integer;
    FileName : string;
begin
a:=StrToInt(Edit1.Text);
b:=StrToInt(Edit2.Text);
n:=StrToInt(Edit3.Text);
m:=StrToInt(Edit4.Text);

if SaveDialog1.Execute then begin
FileName:=SaveDialog1.FileName;
assignfile(fl,filename);
rewrite(fl);
sap(a,b,n,fx,fl);
closefile(fl);
end;
end;

end.
