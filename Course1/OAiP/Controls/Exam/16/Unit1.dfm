object Form1: TForm1
  Left = 658
  Top = 140
  Width = 412
  Height = 435
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
    Left = 24
    Top = 8
    Width = 145
    Height = 369
    ColCount = 2
    FixedCols = 0
    RowCount = 14
    FixedRows = 0
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 208
    Top = 32
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 208
    Top = 192
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object Button1: TButton
    Left = 208
    Top = 64
    Width = 75
    Height = 25
    Caption = 'Button1'
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 200
    Top = 224
    Width = 137
    Height = 153
    Caption = 'Button2'
    TabOrder = 4
    OnClick = Button2Click
  end
  object Edit3: TEdit
    Left = 208
    Top = 96
    Width = 121
    Height = 21
    TabOrder = 5
    Text = 'Edit3'
  end
end
