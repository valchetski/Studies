unit Unit1;

interface

uses

  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Label4: TLabel;
    Button1: TButton;
    Memo1: TMemo;
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
    Edit1.Text:='0,1722';
    Edit2.Text:='6,33';
    Edit3.Text:='3,25E-4';
    Memo1.Clear;

end;

procedure TForm1.Button1Click(Sender: TObject);
   var x,y,z,a,b,c,t : extended;
begin
  Memo1.Clear;
 Memo1.Lines.Add(' Исходные данные:');
     x:=StrToFloat(Edit1.Text);
 Memo1.Lines.Add(' X = '+FloatToStrF(x,fffixed,8,4));
     y:=StrToFloat(Edit2.Text);
 Memo1.Lines.Add(' Y = '+FloatToStrF(y,fffixed,8,4));
     z:=StrToFloat(Edit3.Text);
  Memo1.Lines.Add(' Z = '+FloatToStrF(z,fffixed,8,4));
     a:=5*arctan(x);
     b:=0.25*arccos(x)*(x+3*abs(x-y)+sqr(x));
     c:=abs(x-y)*z+sqr(x);
      t:=a-b/c;
    Memo1.Lines.Add(' Результат T = '+FloatToStrF(t,fffixed,8,6));

end;
end.


