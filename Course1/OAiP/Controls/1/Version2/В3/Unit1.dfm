object Form1: TForm1
  Left = 192
  Top = 124
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
    Left = 56
    Top = 80
    Width = 13
    Height = 13
    Caption = 'A='
  end
  object Label2: TLabel
    Left = 56
    Top = 112
    Width = 13
    Height = 13
    Caption = 'B='
  end
  object Label3: TLabel
    Left = 56
    Top = 144
    Width = 14
    Height = 13
    Caption = 'N='
  end
  object Label4: TLabel
    Left = 56
    Top = 176
    Width = 15
    Height = 13
    Caption = 'M='
  end
  object Edit1: TEdit
    Left = 80
    Top = 80
    Width = 121
    Height = 19
    TabOrder = 0
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 80
    Top = 112
    Width = 121
    Height = 19
    TabOrder = 1
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 80
    Top = 144
    Width = 121
    Height = 19
    TabOrder = 2
    Text = 'Edit3'
  end
  object Edit4: TEdit
    Left = 80
    Top = 176
    Width = 121
    Height = 19
    TabOrder = 3
    Text = 'Edit4'
  end
  object Button1: TButton
    Left = 56
    Top = 208
    Width = 75
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 4
    OnClick = Button1Click
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = '.txt'
    Filter = #1058#1077#1082#1089#1090#1086#1074#1099#1081' '#1092#1072#1081#1083'|*.txt|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 80
    Top = 24
  end
end
