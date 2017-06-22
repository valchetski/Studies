object Form1: TForm1
  Left = 192
  Top = 114
  Width = 592
  Height = 364
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
    Left = 16
    Top = 16
    Width = 145
    Height = 273
    ColCount = 2
    FixedColor = clGray
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 416
    Top = 16
    Width = 145
    Height = 273
    ColCount = 2
    FixedColor = clGray
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 1
  end
  object Button1: TButton
    Left = 216
    Top = 80
    Width = 153
    Height = 105
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
end
