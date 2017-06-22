unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Edit2: TEdit;
    Edit3: TEdit;
    Label3: TLabel;
    Memo1: TMemo;
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
  a,b:extended; N,h:integer;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
 Edit1.Text:='1';
 Edit2.Text:='5';
 Edit3.Text:='10';
 Memo1.clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
 Memo1.clear;
 a:=StrToFloat(edit1.text);
 b:=StrToFloat(edit2.text);
 n:=StrToInt(edit3.text);
 Memo1.Lines.Add('Значение интеграла= '+FloatToStrF(Resh(a,b,n,F),fffixed,4,3));
end;

end.
