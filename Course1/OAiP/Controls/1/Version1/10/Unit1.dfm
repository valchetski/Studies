object Form1: TForm1
  Left = 192
  Top = 107
  Width = 429
  Height = 513
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
  object Image1: TImage
    Left = 0
    Top = 0
    Width = 409
    Height = 409
  end
  object Label1: TLabel
    Left = 8
    Top = 416
    Width = 7
    Height = 13
    Caption = 'X'
  end
  object Label2: TLabel
    Left = 8
    Top = 448
    Width = 7
    Height = 13
    Caption = 'Y'
  end
  object Label3: TLabel
    Left = 256
    Top = 448
    Width = 13
    Height = 13
    Caption = 'S='
  end
  object StringGrid1: TStringGrid
    Left = 24
    Top = 416
    Width = 201
    Height = 57
    ColCount = 3
    FixedCols = 0
    RowCount = 2
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object Button1: TButton
    Left = 232
    Top = 416
    Width = 73
    Height = 17
    Caption = #1056#1080#1089#1086#1074#1072#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 312
    Top = 416
    Width = 97
    Height = 17
    Caption = #1042#1099#1093#1086#1076
    TabOrder = 2
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 272
    Top = 448
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit1'
  end
end
