object Form1: TForm1
  Left = 192
  Top = 124
  Width = 720
  Height = 543
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
    Left = 240
    Top = 32
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Label2: TLabel
    Left = 240
    Top = 96
    Width = 30
    Height = 13
    Caption = 'Wmax'
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 225
    Height = 465
    ColCount = 3
    RowCount = 11
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 240
    Top = 56
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 240
    Top = 120
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object Memo1: TMemo
    Left = 392
    Top = 8
    Width = 265
    Height = 465
    Lines.Strings = (
      'Memo1')
    TabOrder = 3
  end
  object Button1: TButton
    Left = 248
    Top = 184
    Width = 75
    Height = 25
    Caption = #1056#1072#1089#1089#1095#1080#1090#1072#1090#1100
    TabOrder = 4
    OnClick = Button1Click
  end
end
