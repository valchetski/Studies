object Form1: TForm1
  Left = 192
  Top = 117
  Width = 618
  Height = 417
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
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 609
    Height = 385
    ActivePage = TabSheet1
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = 'Image'
      object Image1: TImage
        Left = 0
        Top = 0
        Width = 601
        Height = 305
      end
      object Button2: TButton
        Left = 128
        Top = 320
        Width = 105
        Height = 25
        Caption = #1056#1080#1089#1086#1074#1072#1090#1100' '#1075#1088#1072#1092#1080#1082
        TabOrder = 0
        OnClick = Button2Click
      end
      object Button1: TButton
        Left = 256
        Top = 320
        Width = 155
        Height = 25
        Caption = #1050#1086#1087#1080#1088#1086#1074#1072#1090#1100' '#1074' '#1073#1091#1092#1077#1088' '#1086#1073#1084#1077#1085#1072
        TabOrder = 1
        OnClick = Button1Click
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'Chart'
      ImageIndex = 1
      object Chart1: TChart
        Left = 0
        Top = -8
        Width = 601
        Height = 297
        BackWall.Brush.Color = clWhite
        BackWall.Brush.Style = bsClear
        Title.Text.Strings = (
          'TChart')
        BottomAxis.ExactDateTime = False
        BottomAxis.Increment = 0.200000000000000000
        LeftAxis.ExactDateTime = False
        LeftAxis.Increment = 0.200000000000000000
        Legend.Inverted = True
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
      end
      object Button3: TButton
        Left = 120
        Top = 312
        Width = 105
        Height = 25
        Caption = #1056#1080#1089#1086#1074#1072#1090#1100' '#1075#1088#1072#1092#1080#1082
        TabOrder = 1
        OnClick = Button3Click
      end
      object Button4: TButton
        Left = 272
        Top = 312
        Width = 153
        Height = 25
        Caption = #1050#1086#1087#1080#1088#1086#1074#1072#1090#1100' '#1074' '#1073#1091#1092#1077#1088' '#1086#1073#1084#1077#1085#1072
        TabOrder = 2
        OnClick = Button4Click
      end
    end
    object TabSheet3: TTabSheet
      Caption = #1048#1089#1093#1086#1076#1085#1099#1077' '#1076#1072#1085#1085#1099#1077
      ImageIndex = 2
      object Label1: TLabel
        Left = 24
        Top = 24
        Width = 13
        Height = 13
        Caption = 'Xn'
      end
      object Label2: TLabel
        Left = 24
        Top = 64
        Width = 13
        Height = 13
        Caption = 'Xk'
      end
      object Label3: TLabel
        Left = 24
        Top = 104
        Width = 8
        Height = 13
        Caption = 'N'
      end
      object Label4: TLabel
        Left = 296
        Top = 8
        Width = 77
        Height = 13
        Caption = #1056#1072#1079#1084#1077#1090#1082#1072' '#1086#1089#1077#1081
      end
      object Label5: TLabel
        Left = 248
        Top = 32
        Width = 23
        Height = 13
        Caption = 'Xmin'
      end
      object Label6: TLabel
        Left = 248
        Top = 64
        Width = 26
        Height = 13
        Caption = 'Xmax'
      end
      object Label7: TLabel
        Left = 416
        Top = 32
        Width = 23
        Height = 13
        Caption = 'Ymin'
      end
      object Label8: TLabel
        Left = 416
        Top = 64
        Width = 26
        Height = 13
        Caption = 'Ymax'
      end
      object Edit1: TEdit
        Left = 56
        Top = 24
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 0
        Text = 'Edit1'
      end
      object Edit2: TEdit
        Left = 56
        Top = 64
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 1
        Text = 'Edit2'
      end
      object Edit3: TEdit
        Left = 56
        Top = 104
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 2
        Text = 'Edit3'
      end
      object Edit4: TEdit
        Left = 288
        Top = 32
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 3
        Text = 'Edit4'
      end
      object Edit5: TEdit
        Left = 288
        Top = 64
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 4
        Text = 'Edit4'
      end
      object Edit6: TEdit
        Left = 456
        Top = 32
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 5
        Text = 'Edit4'
      end
      object Edit7: TEdit
        Left = 456
        Top = 64
        Width = 121
        Height = 19
        Ctl3D = False
        ParentCtl3D = False
        TabOrder = 6
        Text = 'Edit4'
      end
    end
  end
end
