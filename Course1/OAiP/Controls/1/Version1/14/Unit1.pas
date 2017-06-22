unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Memo1: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure Memo1Click(Sender: TObject);
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
edit1.Clear;
end;

procedure TForm1.Memo1Click(Sender: TObject);
var st:string;
begin
memo1.Clear;
st:=edit1.text;
viv(st,form1.memo1);
end;

end.
