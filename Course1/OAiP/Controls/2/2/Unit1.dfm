object Form1: TForm1
  Left = 192
  Top = 124
  Width = 542
  Height = 465
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 200
    Top = 104
    Width = 26
    Height = 13
    Caption = #1050#1083#1102#1095
  end
  object Label2: TLabel
    Left = 200
    Top = 160
    Width = 52
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 177
    Height = 393
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssVertical
    TabOrder = 0
    ColWidths = (
      83
      64)
  end
  object Edit1: TEdit
    Left = 200
    Top = 128
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 208
    Top = 24
    Width = 105
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080' '#1076#1072#1085#1085#1099#1077
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 344
    Top = 144
    Width = 75
    Height = 25
    Caption = #1055#1086#1080#1089#1082
    TabOrder = 3
    OnClick = Button2Click
  end
  object Edit2: TEdit
    Left = 200
    Top = 184
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit2'
  end
end
