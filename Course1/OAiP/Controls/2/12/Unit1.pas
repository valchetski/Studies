unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,unit2;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
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
  zad:tzad;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
   edit1.Text:='(a+b+c)*(d+e)/a';
   edit2.Clear;
   
end;

procedure TForm1.Button1Click(Sender: TObject);
var si,sp:string;
begin
   zad:=Tzad.Create;
   si:=edit1.Text;
   zad.OBP(si,sp);
   edit2.Text:=sp;

end;

end.
