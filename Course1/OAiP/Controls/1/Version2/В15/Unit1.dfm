object Form1: TForm1
  Left = 192
  Top = 124
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
  object Edit1: TEdit
    Left = 160
    Top = 48
    Width = 121
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 160
    Top = 80
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
  end
  object Button1: TButton
    Left = 328
    Top = 48
    Width = 75
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = '.pas'
    Filter = #1060#1072#1081#1083' '#1087#1086#1080#1089#1082#1072'|*.pas|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 88
    Top = 8
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = '.pas'
    Filter = #1060#1072#1081#1083' '#1087#1086#1080#1089#1082#1072'|*.pas|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 128
    Top = 8
  end
end
