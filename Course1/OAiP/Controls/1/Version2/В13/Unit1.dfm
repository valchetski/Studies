object Form1: TForm1
  Left = 731
  Top = 238
  Width = 928
  Height = 480
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
    Left = 72
    Top = 72
    Width = 13
    Height = 13
    Caption = 'X='
  end
  object Label2: TLabel
    Left = 72
    Top = 112
    Width = 13
    Height = 13
    Caption = 'Y='
  end
  object Edit1: TEdit
    Left = 88
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 88
    Top = 112
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
  end
  object Button1: TButton
    Left = 64
    Top = 152
    Width = 75
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = '.pas'
    Filter = #1056#1077#1076#1072#1082#1090#1080#1088#1091#1077#1084#1099#1081' '#1092#1072#1081#1083'|*.pas|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 24
    Top = 8
  end
end
