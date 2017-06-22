object Form1: TForm1
  Left = 192
  Top = 124
  Width = 447
  Height = 400
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
    Left = 208
    Top = 112
    Width = 26
    Height = 13
    Caption = #1050#1083#1102#1095
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 161
    Height = 345
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 200
    Top = 136
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 192
    Top = 32
    Width = 129
    Height = 49
    Caption = #1042#1074#1077#1089#1090#1080
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 200
    Top = 168
    Width = 75
    Height = 25
    Caption = #1053#1072#1081#1090#1080
    TabOrder = 3
    OnClick = Button2Click
  end
  object Memo1: TMemo
    Left = 192
    Top = 216
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    TabOrder = 4
  end
end
