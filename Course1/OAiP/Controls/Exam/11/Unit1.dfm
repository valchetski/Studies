object Form1: TForm1
  Left = 527
  Top = 237
  Width = 397
  Height = 226
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
    Left = 16
    Top = 24
    Width = 145
    Height = 145
    ColCount = 2
    FixedCols = 0
    FixedRows = 0
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 176
    Top = 24
    Width = 145
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 176
    Top = 56
    Width = 75
    Height = 25
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 176
    Top = 96
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit2'
  end
end
