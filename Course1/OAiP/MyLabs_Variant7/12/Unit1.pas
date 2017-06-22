unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, XPMan, Grids, StdCtrls, ExtCtrls, Buttons;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    rg1: TRadioGroup;
    cbb1: TComboBox;
    cbb2: TComboBox;
    btn1: TBitBtn;
    Memo1: TMemo;
    btn2: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure cbb2Change(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  choice:Tchoice;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  choice:=Tchoice.Create;
  memo1.clear;
  rg1.itemindex:=0;
  StrnGrd1.Cells[0,0]:='Вес, кг';  StrnGrd1.Cells[1,0]:='Цена, $';
  StrnGrd1.Cells[0,1]:='12';   StrnGrd1.Cells[1,1]:='18';
  StrnGrd1.Cells[0,2]:='11';   StrnGrd1.Cells[1,2]:='20';
  StrnGrd1.Cells[0,3]:='12';   StrnGrd1.Cells[1,3]:='17';
  StrnGrd1.Cells[0,4]:='13';   StrnGrd1.Cells[1,4]:='19';
  StrnGrd1.Cells[0,5]:='14';   StrnGrd1.Cells[1,5]:='17';
  choice.n:=5;
  btn2.Hide;
end;

procedure TForm1.cbb2Change(Sender: TObject); // при изменении количества элементов
begin                                         // через ComboBox
  case cbb2.ItemIndex of
    0: begin strngrd1.RowCount:=4; strngrd1.height:=103; strngrd1.width:=133; choice.N:=3; btn2.Hide; end;
    1: begin strngrd1.RowCount:=6; strngrd1.height:=153; strngrd1.width:=133; choice.N:=5; btn2.Hide; end;
    2: begin strngrd1.RowCount:=11; strngrd1.height:=278; strngrd1.width:=133; choice.N:= 10; btn2.Show; end;
    3: begin strngrd1.RowCount:=21; strngrd1.height:=315; strngrd1.width:=151; choice.N:=20; btn2.Show; end;
  end;
end;

procedure TForm1.btn1Click(Sender: TObject);
var i:integer; weight,cost:word;
begin
  Memo1.Clear; weight:=0; cost:=0;
  With choice do begin
   try for i:=1 to N do
      begin
        CWmas[i].w:=strtoint(StrnGrd1.Cells[0,i]);
        CWmas[i].c:=strtoint(StrnGrd1.Cells[1,i]);
        weight:=weight+CWmas[i].w;
        cost:=cost+CWmas[i].c;
      end;
    case cbb1.ItemIndex of
      0: Wmax:=30;
      1: Wmax:=40;
      2: Wmax:=50;
      else Wmax:=30;
    end;
    if weight<Wmax then ShowMessage('Мы можем взять все предметы :-)') else
      begin
       Cmax:=0; S:=[]; Optimal_Choice:=[];
        case rg1.ItemIndex of
          0:  Vetvi_granici(1,0,cost);
          1:  PP(1,0,0);
          2:  Max_Cost();
          3:  Min_Weight();
          4:  Balanced_Cost();
          5:  Random_Search();
        end;
        Memo1.Lines.Add('Результаты:');
        Memo1.Lines.Add('');
        Memo1.Lines.Add('№     Вес    Цена');
        for i:=1 to n do
          if i in Optimal_Choice then Memo1.Lines.Add(IntToStr(i)+'       '+FloatToStr(CWmas[i].w)+'       '+FloatToStr(CWmas[i].c));
        Memo1.Lines.Add('');
        Memo1.Lines.Add('Общая стоимость — '+FloatToStr(Cmax)+', максимальный вес — '+FloatToStr(Wmax)+'.');
      end;
   except ShowMessage('Заполните таблицу целочисленными значениями'); end;
  end;
  end;

procedure TForm1.btn2Click(Sender: TObject); //заполняем пустые ячейки
var i,j:Byte;
begin
  Randomize;
  for i:=5 to choice.n do
   for j:=0 to 1 do
    strngrd1.Cells[j,i]:=IntToStr(Random(20)+1);
end;

end.
