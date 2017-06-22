object Form1: TForm1
  Left = 192
  Top = 107
  Width = 431
  Height = 350
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Chart1: TChart
    Left = 0
    Top = 0
    Width = 400
    Height = 250
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
    object Series2: TLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clGreen
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
    Left = 0
    Top = 256
    Width = 97
    Height = 33
    Caption = 'GO'
    TabOrder = 1
    OnClick = BitBtn1Click
  end
  object LabeledEdit1: TLabeledEdit
    Left = 112
    Top = 272
    Width = 57
    Height = 21
    EditLabel.Width = 7
    EditLabel.Height = 13
    EditLabel.Caption = 'A'
    TabOrder = 2
  end
  object LabeledEdit2: TLabeledEdit
    Left = 184
    Top = 272
    Width = 57
    Height = 21
    EditLabel.Width = 7
    EditLabel.Height = 13
    EditLabel.Caption = 'B'
    TabOrder = 3
  end
  object LabeledEdit3: TLabeledEdit
    Left = 256
    Top = 272
    Width = 57
    Height = 21
    EditLabel.Width = 8
    EditLabel.Height = 13
    EditLabel.Caption = 'N'
    TabOrder = 4
  end
  object BitBtn2: TBitBtn
    Left = 320
    Top = 256
    Width = 81
    Height = 33
    Caption = 'Exit'
    TabOrder = 5
    OnClick = BitBtn2Click
  end
end
