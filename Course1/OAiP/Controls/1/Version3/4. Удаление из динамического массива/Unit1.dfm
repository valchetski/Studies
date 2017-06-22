object Form1: TForm1
  Left = 373
  Top = 278
  Width = 574
  Height = 207
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
    Left = 408
    Top = 32
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object StringGrid1: TStringGrid
    Left = 24
    Top = 32
    Width = 329
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 440
    Top = 32
    Width = 89
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object StringGrid2: TStringGrid
    Left = 24
    Top = 104
    Width = 329
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    TabOrder = 2
  end
  object Button1: TButton
    Left = 400
    Top = 112
    Width = 121
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 392
    Top = 64
    Width = 137
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100' '#1088#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100
    TabOrder = 4
    OnClick = Button2Click
  end
end
