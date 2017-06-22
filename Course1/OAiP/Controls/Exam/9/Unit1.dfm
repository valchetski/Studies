object Form1: TForm1
  Left = 192
  Top = 114
  Width = 499
  Height = 350
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
    Width = 153
    Height = 273
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 320
    Top = 16
    Width = 153
    Height = 273
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 1
  end
  object BitBtn1: TBitBtn
    Left = 200
    Top = 56
    Width = 97
    Height = 41
    Caption = 'BitBtn1'
    TabOrder = 2
    OnClick = BitBtn1Click
  end
end
