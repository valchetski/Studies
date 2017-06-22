object Form1: TForm1
  Left = 192
  Top = 124
  Width = 798
  Height = 415
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object StringGrid1: TStringGrid
    Left = 16
    Top = 16
    Width = 737
    Height = 49
    ColCount = 11
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssHorizontal
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 16
    Top = 80
    Width = 737
    Height = 49
    ColCount = 11
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssHorizontal
    TabOrder = 1
  end
  object Edit1: TEdit
    Left = 304
    Top = 152
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 448
    Top = 152
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit2'
  end
  object Button1: TButton
    Left = 352
    Top = 176
    Width = 75
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 4
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 448
    Top = 176
    Width = 75
    Height = 25
    Caption = #1055#1088#1086#1095#1080#1090#1072#1090#1100
    TabOrder = 5
    OnClick = Button2Click
  end
  object StringGrid3: TStringGrid
    Left = 24
    Top = 280
    Width = 737
    Height = 73
    ColCount = 11
    RowCount = 2
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssHorizontal
    TabOrder = 6
  end
  object Button3: TButton
    Left = 64
    Top = 144
    Width = 75
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100
    TabOrder = 7
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 160
    Top = 144
    Width = 75
    Height = 25
    Caption = #1042#1099#1074#1077#1089#1090#1080
    TabOrder = 8
    OnClick = Button4Click
  end
end
