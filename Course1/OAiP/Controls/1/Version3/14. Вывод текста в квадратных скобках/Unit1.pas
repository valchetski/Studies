unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
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
  St:string;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.text:='Какой [фрагмент] [этого [текста] взят в основные] квадратные скобки?';
memo1.clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
memo1.clear;
st:=edit1.text;
resh(st,memo1);
end;

end.
