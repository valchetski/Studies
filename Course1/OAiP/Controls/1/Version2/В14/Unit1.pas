unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
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
  st : string;
implementation
uses Unit2;
{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Memo1.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
Memo1.Clear;
st:=Edit1.Text;
search(st,Memo1);
end;

end.
