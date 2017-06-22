unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Label1: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Label2: TLabel;
    Label3: TLabel;
    Edit3: TEdit;
    Edit4: TEdit;
    Label4: TLabel;
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
  R,x,y,h:extended;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
 Edit1.Text:='10'; Edit2.Text:='8'; Edit3.Text:='12';
 Edit4.Text:='0,05';
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
 r:=StrToFloat(Edit1.text); x:=StrToFloat(Edit2.text);
 y:=StrToFloat(Edit3.text); h:=StrToFloat(Edit4.text);
 Resh(r,x,y,h,Image1);
end;

end.
