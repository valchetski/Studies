unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, unit2;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    Edit2: TEdit;
    Label2: TLabel;
    SaveDialog1: TSaveDialog;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  FNT:String;
  fl:TFl;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edit1.Clear; Edit2.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
if SaveDialog1.Execute then
begin
 FNT:=SaveDialog1.FileName;
 AssignFile(fl,fnt);
 reset(fl);
end;
 Edit1.Text:=IntToStr(Resh(fl,'('));
 seek(fl,0);
 Edit2.Text:=IntToStr(Resh(fl,')'));
 closeFile(fl);
end;

end.
