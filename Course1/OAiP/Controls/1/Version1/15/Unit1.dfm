object Form1: TForm1
  Left = 192
  Top = 107
  Width = 333
  Height = 182
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
    Left = 8
    Top = 72
    Width = 39
    Height = 13
    Caption = #1057#1080#1084#1074#1086#1083
  end
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Open file'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 8
    Top = 40
    Width = 73
    Height = 25
    Caption = 'exit'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 8
    Top = 88
    Width = 89
    Height = 21
    TabOrder = 2
    Text = 'Edit1'
  end
  object Button3: TButton
    Left = 8
    Top = 120
    Width = 89
    Height = 17
    Caption = 'Go'
    TabOrder = 3
    OnClick = Button3Click
  end
  object Memo1: TMemo
    Left = 128
    Top = 24
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    TabOrder = 4
  end
  object SaveDialog1: TSaveDialog
    Left = 88
    Top = 8
  end
end
