object Form1: TForm1
  Left = 192
  Top = 114
  Width = 733
  Height = 500
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
    Left = 24
    Top = 16
    Width = 161
    Height = 377
    ColCount = 2
    FixedCols = 0
    RowCount = 14
    FixedRows = 0
    TabOrder = 0
  end
  object Button1: TButton
    Left = 240
    Top = 88
    Width = 217
    Height = 193
    Caption = 'Button1'
    TabOrder = 1
    OnClick = Button1Click
  end
  object StringGrid2: TStringGrid
    Left = 512
    Top = 16
    Width = 161
    Height = 377
    ColCount = 2
    FixedCols = 0
    RowCount = 14
    FixedRows = 0
    TabOrder = 2
  end
end
