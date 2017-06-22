object Form1: TForm1
  Left = 192
  Top = 124
  Width = 593
  Height = 428
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
    Left = 192
    Top = 16
    Width = 112
    Height = 13
    Caption = #1050#1086#1083#1080#1095#1095#1077#1089#1090#1074#1086' '#1079#1072#1087#1080#1089#1077#1081':'
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 169
    Height = 361
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 376
    Top = 8
    Width = 169
    Height = 361
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object BitBtn1: TBitBtn
    Left = 216
    Top = 80
    Width = 75
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080
    TabOrder = 2
    OnClick = BitBtn1Click
  end
  object BitBtn2: TBitBtn
    Left = 216
    Top = 120
    Width = 75
    Height = 25
    Caption = #1055#1088#1086#1095#1080#1090#1072#1090#1100
    TabOrder = 3
    OnClick = BitBtn2Click
  end
  object Edit1: TEdit
    Left = 192
    Top = 32
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit1'
  end
end
