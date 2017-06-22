object Form1: TForm1
  Left = 206
  Top = 111
  Width = 492
  Height = 164
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
  object Label1: TLabel
    Left = 344
    Top = 8
    Width = 68
    Height = 13
    Caption = #1056#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100
  end
  object Label2: TLabel
    Left = 344
    Top = 48
    Width = 118
    Height = 13
    Caption = #1048#1090#1086#1075#1086#1074#1072#1103' '#1088#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 329
    Height = 49
    ColCount = 10
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    OnKeyPress = StringGrid1KeyPress
    ColWidths = (
      64
      64
      62
      64
      64
      64
      64
      64
      64
      64)
    RowHeights = (
      24)
  end
  object Edit1: TEdit
    Left = 344
    Top = 24
    Width = 121
    Height = 21
    TabOrder = 1
    Text = '5'
    OnKeyPress = Edit1KeyPress
  end
  object StringGrid2: TStringGrid
    Left = 8
    Top = 64
    Width = 329
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    TabOrder = 2
    RowHeights = (
      24)
  end
  object BitBtn1: TBitBtn
    Left = 344
    Top = 88
    Width = 121
    Height = 25
    Caption = 'Exit'
    TabOrder = 3
    OnClick = BitBtn1Click
  end
  object Edit2: TEdit
    Left = 344
    Top = 64
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit2'
  end
end
