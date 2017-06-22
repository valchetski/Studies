object Form1: TForm1
  Left = 192
  Top = 114
  Width = 953
  Height = 606
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
    Left = 8
    Top = 16
    Width = 7
    Height = 13
    Caption = 'A'
  end
  object Label2: TLabel
    Left = 8
    Top = 48
    Width = 7
    Height = 13
    Caption = 'B'
  end
  object Label3: TLabel
    Left = 8
    Top = 80
    Width = 6
    Height = 13
    Caption = 'e'
  end
  object Label4: TLabel
    Left = 8
    Top = 112
    Width = 6
    Height = 13
    Caption = 'n'
  end
  object Chart1: TChart
    Left = 176
    Top = 8
    Width = 761
    Height = 553
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    Title.Text.Strings = (
      'TChart')
    View3D = False
    TabOrder = 0
    object Series1: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clRed
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      Pointer.Visible = False
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
  end
  object Edit1: TEdit
    Left = 24
    Top = 16
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 24
    Top = 48
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 24
    Top = 80
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit3'
  end
  object Edit4: TEdit
    Left = 24
    Top = 112
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit4'
  end
  object Button1: TButton
    Left = 40
    Top = 152
    Width = 75
    Height = 25
    Caption = #1053#1072#1088#1080#1089#1086#1074#1072#1090#1100
    TabOrder = 5
    OnClick = Button1Click
  end
end
