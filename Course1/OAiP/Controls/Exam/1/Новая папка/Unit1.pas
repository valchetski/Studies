unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  Krug: TKrug;
  x0,y0: integer;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
Krug := TKrug.Create(x0,y0,50,clBlack,Image1.Canvas);
Krug.Show();
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
x0 := Image1.Width div 2;
y0 := Image1.Height div 2;
ColorBack:=clWhite;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
Krug.MoveTo(0,-10);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
Krug.MoveTo(0,10);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
Krug.MoveTo(-10,0);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
Krug.MoveTo(10,0);
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
Krug.Hide();
Krug.Free();
end;

end.
