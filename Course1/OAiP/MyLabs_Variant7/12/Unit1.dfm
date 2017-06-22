object Form1: TForm1
  Left = 260
  Top = 150
  Width = 391
  Height = 514
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'12'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object strngrd1: TStringGrid
    Left = 216
    Top = 128
    Width = 137
    Height = 345
    ColCount = 2
    FixedCols = 0
    RowCount = 6
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ParentFont = False
    ScrollBars = ssVertical
    TabOrder = 1
  end
  object rg1: TRadioGroup
    Left = 112
    Top = 0
    Width = 241
    Height = 121
    Caption = 'M'#1077#1090#1086#1076':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    Items.Strings = (
      #1074#1077#1090#1074#1077#1081' '#1080' '#1075#1088#1072#1085#1080#1094
      #1087#1086#1083#1085#1086#1075#1086' '#1087#1077#1088#1077#1073#1086#1088#1072
      #1084#1072#1082#1089#1080#1084#1072#1083#1100#1085#1086#1081' '#1089#1090#1086#1080#1084#1086#1089#1090#1080
      #1084#1080#1085#1080#1084#1072#1083#1100#1085#1086#1075#1086' '#1074#1077#1089#1072
      #1089#1073#1072#1083#1072#1085#1089#1080#1088#1086#1074#1072#1085#1085#1086#1081' '#1089#1090#1086#1080#1084#1086#1089#1090#1080
      #1052#1086#1085#1090#1077'-'#1050#1072#1088#1083#1086)
    ParentFont = False
    TabOrder = 0
  end
  object cbb1: TComboBox
    Left = 0
    Top = 8
    Width = 113
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ItemHeight = 19
    ParentFont = False
    TabOrder = 2
    Text = #1052#1072#1082'c. '#1074#1077#1089
    Items.Strings = (
      '30 '#1082#1075
      '40 '#1082#1075
      '50 '#1082#1075)
  end
  object cbb2: TComboBox
    Left = 0
    Top = 32
    Width = 113
    Height = 27
    Hint = '5 '#1087#1086' '#1091#1084#1086#1083#1095#1072#1085#1080#1102
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ItemHeight = 19
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 3
    Text = #1050#1086'-'#1074#1086' '#1101#1083#1077#1084'.'
    OnChange = cbb2Change
    Items.Strings = (
      '3 '#1101#1083#1077#1084#1077#1085#1090#1072
      '5 '#1101#1083#1077#1084#1077#1085#1090#1086#1074
      '10 '#1101#1083#1077#1084#1077#1085#1090#1086#1074
      '20 '#1101#1083#1077#1084#1077#1085#1090#1086#1074)
  end
  object btn1: TBitBtn
    Left = 0
    Top = 56
    Width = 113
    Height = 65
    Caption = #1055#1091#1089#1082
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -24
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = btn1Click
    Kind = bkOK
  end
  object Memo1: TMemo
    Left = 0
    Top = 128
    Width = 217
    Height = 313
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Lines.Strings = (
      'Memo1')
    ParentFont = False
    ScrollBars = ssVertical
    TabOrder = 5
  end
  object btn2: TBitBtn
    Left = 0
    Top = 440
    Width = 353
    Height = 33
    Caption = #1047#1072#1087#1086#1083#1085#1080#1090#1100' =================>               '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = btn2Click
    Kind = bkAll
  end
end
