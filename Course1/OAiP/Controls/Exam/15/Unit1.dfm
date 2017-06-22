object Form1: TForm1
  Left = 294
  Top = 159
  Width = 513
  Height = 386
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
  object StringGrid1: TStringGrid
    Left = 24
    Top = 24
    Width = 153
    Height = 273
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 0
  end
  object Button1: TButton
    Left = 192
    Top = 48
    Width = 75
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 192
    Top = 160
    Width = 75
    Height = 25
    Caption = #1052#1080#1085
    TabOrder = 2
    OnClick = Button2Click
  end
  object Memo1: TMemo
    Left = 296
    Top = 16
    Width = 193
    Height = 321
    Lines.Strings = (
      'Memo1')
    TabOrder = 3
  end
end
