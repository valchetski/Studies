object Form1: TForm1
  Left = 378
  Top = 119
  Width = 508
  Height = 366
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
    Top = 16
    Width = 145
    Height = 265
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    FixedRows = 0
    TabOrder = 0
  end
  object Memo1: TMemo
    Left = 288
    Top = 16
    Width = 201
    Height = 289
    Lines.Strings = (
      'Memo1')
    TabOrder = 1
  end
  object Button1: TButton
    Left = 168
    Top = 128
    Width = 105
    Height = 49
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 160
    Top = 32
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 160
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit2'
  end
end
