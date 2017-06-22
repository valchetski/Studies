unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,Unit2, StdCtrls;

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
    Memo1: TMemo;
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

procedure TForm1.Button1Click(Sender: TObject);
var x0,x1,a,e:extended;
begin
Memo1.Clear;
x0:=StrToFloat(Edit1.Text);
x1:=StrToFloat(Edit2.Text);
a:=StrToFloat(Edit3.Text);
e:=StrToFloat(Edit4.Text);
Memo1.Lines.Add('x0='+FloatToStr(x0));
Memo1.Lines.Add('x1='+FloatToStr(x1));
Memo1.Lines.Add('a='+FloatToStr(a));
Memo1.Lines.Add('e='+FloatToStr(e));
Memo1.Lines.Add('Предел='+FloatToStr(lim(x0,x1,a,e)));
end;

end.
