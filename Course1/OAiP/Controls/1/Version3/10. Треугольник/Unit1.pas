unit Unit1;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Edit5: TEdit;
    Edit6: TEdit;
    Edit7: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  x1,y1,x2,y2,x3,y3,h:extended;
implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
x1:=StrToFloat(edit1.Text); y1:=StrToFloat(edit2.Text);
x2:=StrToFloat(edit3.Text); y2:=StrToFloat(edit4.Text);
x3:=StrToFloat(edit5.Text); y3:=StrToFloat(edit6.Text);
h:=StrToFloat(edit7.Text);
Resh(x1,y1,x2,y2,x3,y3,h,image1);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Text:='1'; Edit2.Text:='1';
Edit3.Text:='7'; Edit4.Text:='10';
Edit5.Text:='10'; Edit6.text:='5';
Edit7.Text:='0,025';
end;

end.
 