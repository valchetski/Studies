unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    Button1: TButton;
    SaveDialog1: TSaveDialog;
    Button2: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    Button3: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  fl:tfl;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
if savedialog1.Execute then
begin
 assignfile(fl,savedialog1.filename);
 reset(fl)
end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
CloseFile(fl);
Form1.Close;
end;

procedure TForm1.Button3Click(Sender: TObject);
var i:integer; x:char;
begin
Memo1.Clear;
 for i:=1 to Length(Edit1.Text) do begin
 x:=Edit1.Text[i];
 Memo1.Lines.Add('Символ: '+x+' - Кол-во: '+src(fl,x));
 end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
Edit1.Clear;
end;

end.
