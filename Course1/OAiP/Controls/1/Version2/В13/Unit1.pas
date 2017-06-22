unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    OpenDialog1: TOpenDialog;
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
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
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Edit2.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
var FilNameD : string;
    x, y : char;
    Fl : tfl;
begin
x:=Edit1.Text[1];
y:=Edit2.Text[1];
If OpenDialog1.Execute then begin
 FilNameD:=OpenDialog1.FileName;
 AssignFile(Fl,FilNameD);
 Reset(Fl);
 samena(fl,x,y);
 CloseFile(Fl);
 end;
end;

end.
