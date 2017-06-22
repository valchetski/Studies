unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2, Buttons;

type
  TForm1 = class(TForm)
    Label2: TLabel;
    BitBtn1: TBitBtn;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad1:Tzad1;
  {a,e,x0:extended;}
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  Edit1.Text:='4'; Edit2.Text:='0,001'; Edit3.Clear; Edit4.Clear;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var a,e,x0:extended; 
begin
  a:=StrToFloat(Edit1.Text);
  e:=StrToFloat(Edit2.Text);
  x0:=0.5*(1+a);
  zad1:=Tzad1.create;
  Edit3.Text:=FloatToStr(zad1.srec(x0));
  Edit4.Text:=FloatToStr(zad1.bezrec(x0));
  Zad1.free;
end;

end.
