unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, unit2;

type
  TForm1 = class(TForm)
    Button1: TButton;
    SaveDialog1: TSaveDialog;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  Fl:Tfl;
  FileNameT:string;
implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
If savedialog1.Execute then
begin
  FileNameT:=SaveDialog1.FileName;
  AssignFile(fl,filenamet);
  Reset(fl);
end;
  Resh(fl,'(','[');
  seek(fl,0);
  resh(fl,')',']');
  CloseFile(fl);
end;
end.
