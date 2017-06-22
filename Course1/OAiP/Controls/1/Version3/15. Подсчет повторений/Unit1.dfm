object Form1: TForm1
  Left = 192
  Top = 114
  Width = 759
  Height = 142
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
    Left = 96
    Top = 24
    Width = 13
    Height = 13
    Caption = '"("'
  end
  object Label2: TLabel
    Left = 408
    Top = 24
    Width = 13
    Height = 13
    Caption = '")"'
  end
  object Button1: TButton
    Left = 232
    Top = 64
    Width = 243
    Height = 25
    Caption = #1057#1082#1086#1083#1100#1082#1086' '#1087#1086#1074#1090#1086#1088#1077#1085#1080#1081' "(" '#1080' ")" '#1074' '#1092#1072#1081#1083#1077
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 112
    Top = 24
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 440
    Top = 24
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = '.txt'
    Left = 120
    Top = 64
  end
end
