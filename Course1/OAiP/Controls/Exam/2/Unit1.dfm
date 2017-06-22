object Form1: TForm1
  Left = 192
  Top = 114
  Width = 592
  Height = 459
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object StringGrid1: TStringGrid
    Left = 8
    Top = 16
    Width = 161
    Height = 393
    ColCount = 2
    FixedColor = clSilver
    FixedCols = 0
    RowCount = 15
    FixedRows = 0
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 248
    Top = 48
    Width = 185
    Height = 21
    TabOrder = 1
  end
  object Button1: TButton
    Left = 256
    Top = 112
    Width = 177
    Height = 73
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 248
    Top = 216
    Width = 193
    Height = 21
    TabOrder = 3
  end
end
