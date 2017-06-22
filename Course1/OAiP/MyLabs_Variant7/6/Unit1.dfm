object Form1: TForm1
  Left = 192
  Top = 124
  Width = 452
  Height = 215
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
    Top = 16
    Width = 13
    Height = 13
    Caption = 'Xn'
  end
  object Label2: TLabel
    Left = 8
    Top = 48
    Width = 13
    Height = 13
    Caption = 'Xk'
  end
  object Label3: TLabel
    Left = 8
    Top = 80
    Width = 6
    Height = 13
    Caption = 'e'
  end
  object Label4: TLabel
    Left = 8
    Top = 112
    Width = 8
    Height = 13
    Caption = 'm'
  end
  object Edit1: TEdit
    Left = 40
    Top = 16
    Width = 65
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 40
    Top = 48
    Width = 65
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 40
    Top = 80
    Width = 65
    Height = 21
    TabOrder = 2
    Text = 'Edit3'
  end
  object Edit4: TEdit
    Left = 40
    Top = 112
    Width = 65
    Height = 21
    TabOrder = 3
    Text = 'Edit4'
  end
  object Memo1: TMemo
    Left = 216
    Top = 16
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    ScrollBars = ssBoth
    TabOrder = 4
  end
  object RadioGroup1: TRadioGroup
    Left = 120
    Top = 16
    Width = 81
    Height = 121
    Caption = #1060#1091#1085#1082#1094#1080#1103
    Items.Strings = (
      'S(x)'
      'Y(x)')
    TabOrder = 5
  end
  object BitBtn1: TBitBtn
    Left = 216
    Top = 112
    Width = 89
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 6
    OnClick = BitBtn1Click
    Kind = bkOK
  end
  object BitBtn2: TBitBtn
    Left = 328
    Top = 112
    Width = 75
    Height = 25
    Caption = #1047#1072#1082#1088#1099#1090#1100
    TabOrder = 7
    Kind = bkClose
  end
end
