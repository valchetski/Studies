unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Edit5: TEdit;
    Label6: TLabel;
    Edit6: TEdit;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Memo1: TMemo;
    BitBtn1: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;
Type
  TKniga = record
    Nazvanie: string[40];
    Avtor : string[40];
    god : integer;
    izdatelstvo : string[40] ;
    stranica : string[5];
    nomer : string[6];
    end;
var
  Fz  : file of  Tkniga;
  Ft  : TextFile;
  kniga : array[1..100] of Tkniga;
  nzap : integer;
  FileNameZ, FileNameT : string;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edit1.text:='';
edit2.text:='';
edit3.text:='';
edit4.text:='';
Memo1.Clear;
Button1.Hide;
nzap:=0;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
OpenDialog1.Title :='������� ����� ����';

 if OpenDialog1.Execute then
   begin
    FileNameZ:= OpenDialog1.FileName;

    AssignFile(Fz, FileNameZ);

     Rewrite(Fz);
   end;
    Button1.Show;

end;

procedure TForm1.Button1Click(Sender: TObject);
begin
    nzap:=nzap+1;
  with kniga[nzap] do begin
           nazvanie:=Edit1.Text;
           avtor:=Edit2.Text;
           god:=StrToInt(Edit3.Text);
           izdatelstvo:=Edit4.Text;
           stranica:=edit5.text;
           nomer:=edit6.Text;
Memo1.Lines.Add(nazvanie+'   '+avtor+'   '+ IntToStr(god)+
                          '  '+izdatelstvo+'  '+stranica+'  '+nomer);
                                end;
     Write(fz,kniga[nzap]);
   Edit1.Clear;   Edit2.Clear;   Edit3.Clear;   Edit4.Clear; Edit5.Clear;
   Edit6.Clear;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
 Memo1.Clear;
 if OpenDialog1.Execute then
    begin
    FileNameZ:= OpenDialog1.FileName;
    AssignFile(Fz, FileNameZ);
    Reset(Fz);
   end;
    nzap:=0;
  while not eof(fz) do begin
   nzap:=nzap+1;
     Read(fz,kniga[nzap]);
         with kniga[nzap] do
     Memo1.Lines.Add(nazvanie+'   '+avtor+'   '+ IntToStr(god)+
                          '  '+izdatelstvo+'  '+stranica+'  '+nomer);
                                 end;
     Button1.Show;

end;

procedure TForm1.Button5Click(Sender: TObject);
var i:word;
begin
  if SaveDialog1.Execute then begin
   FileNameT:= SaveDialog1.FileName;
   AssignFile(Ft, FileNameT);
   Rewrite(Ft);
  end;
  for i:=1 to nzap do
    with kniga[i] do  Writeln(Ft,i,'. ',nazvanie,god);
    CloseFile(Fz);
  end;

procedure TForm1.BitBtn1Click(Sender: TObject);
begin
CloseFile(fz);
end;

procedure TForm1.Button4Click(Sender: TObject);
var i,j :  word; kn : Tkniga;
begin
Memo1.Clear;
 for i:=1 to nzap-1 do
  for j:=i+1 to nzap do  begin
      if kniga[i].avtor > kniga[j].avtor then begin
         kn:=kniga[i];
         kniga[i]:=kniga[j];
         kniga[j]:=kn;
      end; end;
  for i:=1 to nzap do
          with kniga[i] do
     Memo1.Lines.Add(IntToStr(i)+'  '+nazvanie+'  '+avtor+'   '+ IntToStr(god)+
                          '  '+izdatelstvo+'  '+stranica+'  '+nomer);

end;

end.
