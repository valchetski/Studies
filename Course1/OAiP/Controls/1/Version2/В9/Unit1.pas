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
    Button1: TButton;
    Edit4: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation
uses Unit2;
{$R *.dfm}
	Function u(x:extended):extended;
		begin
		 result:=sqr(sin(x));
		end;

procedure TForm1.Button1Click(Sender: TObject);
var a,b,n:integer;
begin
a:=StrToInt(Edit1.Text);
b:=StrToInt(Edit2.Text);
n:=StrToInt(Edit3.Text);
edit4.Text:=FloatToStrF(intgf(a,b,n,u),fffixed,6,3);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Edit2.Clear;
Edit3.Clear;
Edit4.Clear;
end;

end.
