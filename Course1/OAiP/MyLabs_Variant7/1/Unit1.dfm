object Form1: TForm1
  Left = 415
  Top = 212
  Width = 928
  Height = 480
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'1. '#1057#1090'. '#1075#1088'. 252005 '#1042#1086#1083#1095#1077#1094#1082#1080#1081' '#1040'.'#1052'.'
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
    Left = 136
    Top = 48
    Width = 16
    Height = 13
    Caption = ' X='
  end
  object Label2: TLabel
    Left = 136
    Top = 80
    Width = 16
    Height = 13
    Caption = ' Y='
  end
  object Label3: TLabel
    Left = 136
    Top = 112
    Width = 16
    Height = 13
    Caption = ' Z='
  end
  object Label4: TLabel
    Left = 24
    Top = 152
    Width = 182
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090' '#1074#1099#1087#1086#1083#1085#1077#1085#1080#1103' '#1087#1088#1086#1075#1088#1072#1084#1084#1099':'
  end
  object Edit1: TEdit
    Left = 176
    Top = 40
    Width = 121
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clBlack
    Font.Height = -16
    Font.Name = 'MS Mincho'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 176
    Top = 72
    Width = 121
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clBlack
    Font.Height = -16
    Font.Name = 'MS PMincho'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 176
    Top = 104
    Width = 121
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clBlack
    Font.Height = -16
    Font.Name = 'MS PMincho'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Text = 'Edit3'
  end
  object Button1: TButton
    Left = 40
    Top = 280
    Width = 153
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -16
    Font.Name = 'MS PMincho'
    Font.Style = [fsBold, fsItalic]
    ParentFont = False
    TabOrder = 3
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 24
    Top = 176
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    TabOrder = 4
  end
end
