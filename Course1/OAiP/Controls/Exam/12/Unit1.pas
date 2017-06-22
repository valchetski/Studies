unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit3;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  T:TClass;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
T:=TClass.Create();
Edit2.Text:=T.OBP(Edit1.Text);
end;

end.
