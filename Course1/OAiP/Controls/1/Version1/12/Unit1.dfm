object Form1: TForm1
  Left = 192
  Top = 107
  Width = 218
  Height = 158
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
    Top = 16
    Width = 193
    Height = 21
    TabOrder = 0
    Text = 'Edit1'
    OnKeyPress = Edit1KeyPress
  end
  object Button1: TButton
    Left = 8
    Top = 48
    Width = 193
    Height = 25
    Caption = 'Start'
    TabOrder = 1
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 8
    Top = 88
    Width = 193
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
    Visible = False
  end
end
