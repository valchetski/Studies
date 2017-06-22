object Form1: TForm1
  Left = 192
  Top = 124
  Width = 687
  Height = 502
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
    Left = 272
    Top = 40
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Label2: TLabel
    Left = 272
    Top = 104
    Width = 30
    Height = 13
    Caption = 'Wmax'
  end
  object StringGrid1: TStringGrid
    Left = 16
    Top = 16
    Width = 225
    Height = 409
    ColCount = 3
    RowCount = 11
    TabOrder = 0
  end
  object Button1: TButton
    Left = 296
    Top = 168
    Width = 75
    Height = 25
    Caption = #1056#1072#1089#1089#1095#1080#1090#1072#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 272
    Top = 64
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 272
    Top = 128
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit2'
  end
  object Memo1: TMemo
    Left = 400
    Top = 16
    Width = 241
    Height = 425
    Lines.Strings = (
      'Memo1')
    TabOrder = 4
  end
end
