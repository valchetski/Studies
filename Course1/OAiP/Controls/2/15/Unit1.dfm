object Form1: TForm1
  Left = 192
  Top = 124
  Width = 502
  Height = 395
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
    Left = 8
    Top = 8
    Width = 169
    Height = 321
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object Button1: TButton
    Left = 208
    Top = 56
    Width = 201
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080' '#1080' '#1085#1072#1081#1090#1080' '#1084#1080#1085#1080#1084#1072#1083#1100#1085#1086#1077
    TabOrder = 1
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 208
    Top = 112
    Width = 201
    Height = 65
    Lines.Strings = (
      'Memo1')
    TabOrder = 2
  end
end
