object Form1: TForm1
  Left = 330
  Top = 164
  Width = 221
  Height = 116
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 80
    Top = 0
    Width = 48
    Height = 13
    Caption = #1057#1080#1084#1074#1086#1083' 1'
  end
  object Label3: TLabel
    Left = 144
    Top = 0
    Width = 48
    Height = 13
    Caption = #1057#1080#1084#1074#1086#1083' 2'
  end
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 65
    Height = 25
    Caption = 'Open'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 80
    Top = 16
    Width = 65
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
  end
  object Button2: TButton
    Left = 8
    Top = 48
    Width = 65
    Height = 25
    Caption = #1055#1059#1057#1050
    TabOrder = 2
    OnClick = Button2Click
  end
  object Edit3: TEdit
    Left = 144
    Top = 16
    Width = 65
    Height = 21
    TabOrder = 3
    Text = 'Edit3'
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = '*.*'
    Filter = #1074#1089#1077' '#1092#1072#1081#1083#1099'|*.*|TExt files|*.txt'
    Left = 144
    Top = 56
  end
end
