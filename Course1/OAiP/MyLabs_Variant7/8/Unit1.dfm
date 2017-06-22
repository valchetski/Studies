object Form1: TForm1
  Left = 188
  Top = 98
  Width = 696
  Height = 473
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
    Left = 56
    Top = 40
    Width = 120
    Height = 20
    Caption = #1053#1072#1079#1074#1072#1085#1080#1077' '#1082#1085#1080#1075#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 136
    Top = 64
    Width = 47
    Height = 20
    Caption = #1040#1074#1090#1086#1088
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 88
    Top = 88
    Width = 97
    Height = 20
    Caption = #1043#1086#1076' '#1080#1079#1076#1072#1085#1080#1103
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 72
    Top = 112
    Width = 115
    Height = 20
    Caption = #1048#1079#1076#1072#1090#1077#1083#1100#1089#1090#1074#1086' '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 24
    Top = 136
    Width = 161
    Height = 20
    Caption = #1050#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1089#1090#1088#1072#1085#1080#1094' '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 0
    Top = 160
    Width = 186
    Height = 20
    Caption = #1056#1077#1075#1080#1089#1090#1088#1072#1094#1080#1086#1085#1085#1099#1081' '#1085#1086#1084#1077#1088
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 192
    Top = 40
    Width = 185
    Height = 21
    TabOrder = 0
  end
  object Edit2: TEdit
    Left = 192
    Top = 64
    Width = 185
    Height = 21
    TabOrder = 1
  end
  object Edit3: TEdit
    Left = 192
    Top = 88
    Width = 89
    Height = 21
    TabOrder = 2
  end
  object Edit4: TEdit
    Left = 192
    Top = 112
    Width = 185
    Height = 21
    TabOrder = 3
  end
  object Edit5: TEdit
    Left = 192
    Top = 136
    Width = 65
    Height = 21
    TabOrder = 4
  end
  object Edit6: TEdit
    Left = 192
    Top = 160
    Width = 121
    Height = 21
    TabOrder = 5
  end
  object Button1: TButton
    Left = 328
    Top = 152
    Width = 97
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080' '#1079#1072#1087#1080#1089#1100
    TabOrder = 6
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 24
    Top = 360
    Width = 75
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100
    TabOrder = 7
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 128
    Top = 360
    Width = 75
    Height = 25
    Caption = #1054#1090#1082#1088#1099#1090#1100
    TabOrder = 8
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 224
    Top = 360
    Width = 75
    Height = 25
    Caption = #1057#1086#1088#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 9
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 320
    Top = 360
    Width = 75
    Height = 25
    Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100
    TabOrder = 10
    OnClick = Button5Click
  end
  object Memo1: TMemo
    Left = 24
    Top = 184
    Width = 473
    Height = 153
    Lines.Strings = (
      'Memo1')
    TabOrder = 11
  end
  object BitBtn1: TBitBtn
    Left = 424
    Top = 360
    Width = 75
    Height = 25
    TabOrder = 12
    OnClick = BitBtn1Click
    Kind = bkClose
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = '*.dat'
    Filter = #1060#1072#1081#1083' '#1076#1072#1085#1085#1099#1093'|*.dat|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 248
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = '*.txt'
    Filter = #1060#1072#1081#1083' '#1076#1072#1085#1085#1099#1093'|*.txt|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 280
  end
end
