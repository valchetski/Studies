object Form5: TForm5
  Left = 357
  Top = 151
  Width = 277
  Height = 224
  Caption = #1042#1093#1086#1076
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
    Left = 8
    Top = 16
    Width = 46
    Height = 20
    Caption = #1051#1086#1075#1080#1085
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -17
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 8
    Top = 56
    Width = 58
    Height = 20
    Caption = #1055#1072#1088#1086#1083#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -17
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 8
    Top = 120
    Width = 247
    Height = 20
    Caption = #1053#1077#1087#1088#1072#1074#1080#1083#1100#1085#1099#1081' '#1083#1086#1075#1080#1085'/'#1087#1072#1088#1086#1083#1100
    Font.Charset = ANSI_CHARSET
    Font.Color = clRed
    Font.Height = -17
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 72
    Top = 16
    Width = 185
    Height = 28
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -17
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = 'Edit1'
    OnChange = Edit1Change
  end
  object Edit2: TEdit
    Left = 72
    Top = 56
    Width = 185
    Height = 28
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -17
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    PasswordChar = '*'
    TabOrder = 1
    Text = 'Edit2'
    OnChange = Edit2Change
  end
  object BitBtn1: TBitBtn
    Left = 40
    Top = 144
    Width = 75
    Height = 25
    Caption = #1042#1093#1086#1076
    TabOrder = 2
    OnClick = BitBtn1Click
    Kind = bkOK
  end
  object Button1: TButton
    Left = 152
    Top = 144
    Width = 83
    Height = 25
    Caption = #1056#1077#1075#1080#1089#1090#1088#1072#1094#1080#1103
    TabOrder = 3
    OnClick = Button1Click
  end
  object CheckBox1: TCheckBox
    Left = 8
    Top = 96
    Width = 129
    Height = 17
    Caption = #1047#1072#1087#1086#1084#1085#1080#1090#1100' '#1084#1077#1085#1103
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
  end
end
