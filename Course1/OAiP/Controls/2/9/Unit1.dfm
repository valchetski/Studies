object Form1: TForm1
  Left = 192
  Top = 124
  Width = 595
  Height = 491
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
    Top = 8
    Width = 161
    Height = 425
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssVertical
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 392
    Top = 8
    Width = 161
    Height = 425
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssVertical
    TabOrder = 1
  end
  object BitBtn1: TBitBtn
    Left = 224
    Top = 176
    Width = 105
    Height = 25
    Caption = #1057#1086#1088#1090#1088#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 2
    OnClick = BitBtn1Click
    Kind = bkRetry
  end
end
