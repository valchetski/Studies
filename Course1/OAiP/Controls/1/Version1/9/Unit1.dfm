object Form1: TForm1
  Left = 192
  Top = 107
  Width = 189
  Height = 219
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
    Left = 160
    Top = 16
    Width = 7
    Height = 13
    Caption = 'A'
  end
  object Label2: TLabel
    Left = 168
    Top = 48
    Width = 7
    Height = 13
    Caption = 'B'
  end
  object Label3: TLabel
    Left = 160
    Top = 80
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Edit1: TEdit
    Left = 8
    Top = 8
    Width = 113
    Height = 21
    TabOrder = 0
    Text = '1'
  end
  object Edit2: TEdit
    Left = 16
    Top = 40
    Width = 121
    Height = 21
    TabOrder = 1
    Text = '2'
  end
  object Edit3: TEdit
    Left = 8
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 2
    Text = '10'
  end
  object Button1: TButton
    Left = 24
    Top = 112
    Width = 75
    Height = 25
    Caption = 'Go'
    TabOrder = 3
    OnClick = Button1Click
  end
  object Edit4: TEdit
    Left = 16
    Top = 152
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit4'
  end
end
