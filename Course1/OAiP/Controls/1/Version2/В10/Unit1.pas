unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Edit4: TEdit;
    Label4: TLabel;
    Edit5: TEdit;
    Label5: TLabel;
    Edit6: TEdit;
    Label6: TLabel;
    Edit7: TEdit;
    Label7: TLabel;
    Image1: TImage;
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

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
Edit2.Clear;
Edit3.Clear;
Edit4.Clear;
Edit5.Clear;
Edit6.Clear;
Edit7.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
var x1,y1,x2,y2,x3,y3,h : real;
begin
x1:=StrToFloat(Edit1.Text);
y1:=StrToFloat(Edit2.Text);
x2:=StrToFloat(Edit3.Text);
y2:=StrToFloat(Edit4.Text);
x3:=StrToFloat(Edit5.Text);
y3:=StrToFloat(Edit6.Text);
h:=StrToFloat(Edit7.Text);
treu(x1,y1,x2,y2,x3,y3,h,Image1);
end;

end.
