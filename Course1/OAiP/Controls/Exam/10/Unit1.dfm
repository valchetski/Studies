object Form1: TForm1
  Left = 199
  Top = 141
  Width = 521
  Height = 365
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
    Top = 24
    Width = 145
    Height = 265
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 344
    Top = 24
    Width = 145
    Height = 265
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 1
  end
  object Button1: TButton
    Left = 184
    Top = 72
    Width = 129
    Height = 145
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
end
