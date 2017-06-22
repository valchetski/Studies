unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit3;

type
  TForm1 = class(TForm)
    OpenDialog1: TOpenDialog;
    Button1: TButton;
    Edit3: TEdit;
    Label1: TLabel;
    Button3: TButton;
    Edit3: TEdit;
    Label3: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  fl:tfl;


implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
if opendialog1.Execute then assignfile(fl,opendialog1.FileName);
reset(fl);
end;

procedure TForm1.Button3Click(Sender: TObject);
var x,y:string; i,d1,d3: integer;
begin
x:=edit3.text;
y:=edit3.text;
d1:=Length(x);
d3:=Length(y);
if d1<>d3 then ShowMessage('Error')
else begin
 for i:=1 to d1 do
 sr(fl,x[i],y[i]);
end;
CloseFile(fl);
end;
end.
