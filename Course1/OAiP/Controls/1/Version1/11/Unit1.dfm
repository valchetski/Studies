object Form1: TForm1
  Left = 192
  Top = 107
  Width = 294
  Height = 302
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
    Left = 8
    Top = 8
    Width = 273
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
  end
  object Memo1: TMemo
    Left = 8
    Top = 64
    Width = 273
    Height = 201
    Lines.Strings = (
      'Memo1')
    TabOrder = 1
  end
  object Button1: TButton
    Left = 8
    Top = 32
    Width = 265
    Height = 25
    Caption = 'Go-go-go'
    TabOrder = 2
    OnClick = Button1Click
  end
end
