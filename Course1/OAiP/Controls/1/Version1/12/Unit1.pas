unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    Edit2: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}


procedure TForm1.Button1Click(Sender: TObject);
var st:string;
begin
 st:=Edit1.Text;
 Edit2.Visible:=true;
 Edit2.Text:=IntToStr(pod(st));
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
if key=#27 then form1.Close;
end;

end.
