object Form1: TForm1
  Left = 232
  Top = 152
  Width = 924
  Height = 480
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
    Left = 72
    Top = 16
    Width = 13
    Height = 13
    Caption = 'X0'
  end
  object Label2: TLabel
    Left = 72
    Top = 40
    Width = 13
    Height = 13
    Caption = 'X1'
  end
  object Label3: TLabel
    Left = 72
    Top = 64
    Width = 7
    Height = 13
    Caption = 'A'
  end
  object Label4: TLabel
    Left = 72
    Top = 88
    Width = 7
    Height = 13
    Caption = 'E'
  end
  object Edit1: TEdit
    Left = 88
    Top = 8
    Width = 121
    Height = 21
    TabOrder = 0
    Text = '1'
  end
  object Edit2: TEdit
    Left = 88
    Top = 32
    Width = 121
    Height = 21
    TabOrder = 1
    Text = '5'
  end
  object Edit3: TEdit
    Left = 88
    Top = 56
    Width = 121
    Height = 21
    TabOrder = 2
    Text = '6'
  end
  object Edit4: TEdit
    Left = 88
    Top = 80
    Width = 121
    Height = 21
    TabOrder = 3
    Text = '0,00001'
  end
  object Button1: TButton
    Left = 96
    Top = 112
    Width = 75
    Height = 25
    Caption = 'Button1'
    TabOrder = 4
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 32
    Top = 144
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    TabOrder = 5
  end
end
