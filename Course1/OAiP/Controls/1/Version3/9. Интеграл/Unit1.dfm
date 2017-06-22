object Form1: TForm1
  Left = 192
  Top = 114
  Width = 565
  Height = 337
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
    Top = 32
    Width = 7
    Height = 13
    Caption = 'A'
  end
  object Label2: TLabel
    Left = 8
    Top = 64
    Width = 7
    Height = 13
    Caption = 'B'
  end
  object Label3: TLabel
    Left = 8
    Top = 96
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Edit1: TEdit
    Left = 32
    Top = 32
    Width = 121
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 32
    Top = 64
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 32
    Top = 96
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit3'
  end
  object Memo1: TMemo
    Left = 216
    Top = 24
    Width = 281
    Height = 249
    Lines.Strings = (
      'Memo1')
    TabOrder = 3
  end
  object Button1: TButton
    Left = 64
    Top = 160
    Width = 75
    Height = 25
    Caption = #1042#1099#1095#1080#1089#1083#1080#1090#1100
    TabOrder = 4
    OnClick = Button1Click
  end
end
