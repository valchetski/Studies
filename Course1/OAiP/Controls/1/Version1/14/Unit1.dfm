object Form1: TForm1
  Left = 192
  Top = 107
  Width = 234
  Height = 197
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
  object Edit1: TEdit
    Left = 48
    Top = 8
    Width = 121
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
  end
  object Memo1: TMemo
    Left = 24
    Top = 64
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    TabOrder = 1
    OnClick = Memo1Click
  end
end
