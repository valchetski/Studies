object Form3: TForm3
  Left = 307
  Top = 236
  Width = 427
  Height = 343
  Caption = #1052#1086#1080' '#1089#1090#1072#1074#1082#1080
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
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 411
    Height = 304
    ActivePage = TabSheet1
    Align = alClient
    TabIndex = 0
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1058#1077#1082#1091#1097#1080#1077
      object Memo1: TMemo
        Left = 0
        Top = 0
        Width = 403
        Height = 276
        Align = alClient
        Lines.Strings = (
          'Memo1')
        ScrollBars = ssBoth
        TabOrder = 0
      end
    end
    object TabSheet2: TTabSheet
      Caption = #1057#1099#1075#1088#1072#1074#1096#1080#1077
      ImageIndex = 1
      object Memo2: TMemo
        Left = 0
        Top = 0
        Width = 403
        Height = 276
        Align = alClient
        Lines.Strings = (
          'Memo2')
        ScrollBars = ssBoth
        TabOrder = 0
      end
    end
    object TabSheet3: TTabSheet
      Caption = #1053#1077' '#1089#1099#1075#1088#1072#1074#1096#1080#1077
      ImageIndex = 2
      object Memo3: TMemo
        Left = 0
        Top = 0
        Width = 403
        Height = 276
        Align = alClient
        Lines.Strings = (
          'Memo3')
        ScrollBars = ssBoth
        TabOrder = 0
      end
    end
  end
end
