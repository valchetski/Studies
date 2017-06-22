unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Edit4: TEdit;
    Edit5: TEdit;
    Image1: TImage;
    Button1: TButton;
    Label7: TLabel;
    Edit6: TEdit;
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
  Edit1.Text:='-3'; Edit2.Text:='3'; Edit3.Text:='-3';
  Edit4.Text:='4'; Edit5.Text:='14'; Edit6.Text:='0,05';
end;

procedure TForm1.Button1Click(Sender: TObject);
var a,b,c,h:extended; x1,y1:integer;
begin
  a:=StrToFloat(Edit1.Text);
  b:=StrToFloat(Edit2.Text);
  c:=StrToFloat(Edit3.Text);
  x1:=StrToInt(Edit4.Text);
  y1:=StrToInt(Edit5.Text);
  h:=StrToFloat(Edit6.Text);
  Tochka(a,b,c,h,x1,y1,Image1);
end;
end.
