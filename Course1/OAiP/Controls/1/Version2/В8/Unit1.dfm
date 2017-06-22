object Form1: TForm1
  Left = 177
  Top = 173
  Width = 928
  Height = 480
  Caption = 'Form1'
  Color = clWindow
  Ctl3D = False
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
    Left = 88
    Top = 32
    Width = 13
    Height = 13
    Caption = 'A='
  end
  object Label2: TLabel
    Left = 88
    Top = 56
    Width = 13
    Height = 13
    Caption = 'B='
  end
  object Label3: TLabel
    Left = 88
    Top = 80
    Width = 14
    Height = 13
    Caption = 'N='
  end
  object Edit1: TEdit
    Left = 104
    Top = 32
    Width = 121
    Height = 19
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 104
    Top = 56
    Width = 121
    Height = 19
    TabOrder = 1
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 104
    Top = 80
    Width = 121
    Height = 19
    TabOrder = 2
    Text = 'Edit3'
  end
  object Chart1: TChart
    Left = 248
    Top = 16
    Width = 641
    Height = 402
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    Title.Text.Strings = (
      'TChart')
    View3D = False
    TabOrder = 3
    object Series1: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clRed
      Title = #1056#1077#1072#1083#1100#1085#1072#1103' '#1095#1072#1089#1090#1100
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
    object Series2: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clGreen
      Title = #1052#1085#1080#1084#1072#1103' '#1095#1072#1089#1090#1100
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
  object BitBtn1: TBitBtn
    Left = 104
    Top = 120
    Width = 75
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 4
    OnClick = BitBtn1Click
  end
end
