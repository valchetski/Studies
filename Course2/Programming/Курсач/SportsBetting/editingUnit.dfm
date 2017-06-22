object Editing: TEditing
  Left = 210
  Top = 99
  Width = 417
  Height = 546
  Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1085#1080#1077
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
    Width = 401
    Height = 507
    ActivePage = TabSheet1
    Align = alClient
    TabIndex = 0
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1044#1086#1073#1072#1074#1080#1090#1100' '#1084#1072#1090#1095
      object Label1: TLabel
        Left = 8
        Top = 16
        Width = 118
        Height = 25
        Caption = #1044#1072#1090#1072' '#1085#1072#1095#1072#1083#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label2: TLabel
        Left = 8
        Top = 112
        Width = 131
        Height = 25
        Caption = #1042#1088#1077#1084#1103' '#1085#1072#1095#1072#1083#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label3: TLabel
        Left = 8
        Top = 152
        Width = 152
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1093#1086#1079#1103#1077#1074
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label4: TLabel
        Left = 8
        Top = 192
        Width = 151
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1075#1086#1089#1090#1077#1081
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label5: TLabel
        Left = 8
        Top = 232
        Width = 170
        Height = 25
        Caption = #1050#1086#1101#1092#1092#1080#1094#1080#1077#1085#1090' '#1055'1'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label6: TLabel
        Left = 8
        Top = 272
        Width = 158
        Height = 25
        Caption = #1050#1086#1101#1092#1092#1080#1094#1080#1077#1085#1090' '#1053
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label7: TLabel
        Left = 8
        Top = 312
        Width = 170
        Height = 25
        Caption = #1050#1086#1101#1092#1092#1080#1094#1080#1077#1085#1090' '#1055'2'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label8: TLabel
        Left = 8
        Top = 56
        Width = 105
        Height = 25
        Caption = #1042#1080#1076' '#1089#1087#1086#1088#1090#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label22: TLabel
        Left = 128
        Top = 440
        Width = 142
        Height = 25
        Caption = #1052#1072#1090#1095' '#1076#1086#1073#1072#1074#1083#1077#1085
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object DateTimePicker1: TDateTimePicker
        Left = 200
        Top = 16
        Width = 145
        Height = 28
        CalAlignment = dtaLeft
        Date = 41621.871699294
        Time = 41621.871699294
        DateFormat = dfShort
        DateMode = dmComboBox
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        Kind = dtkDate
        ParseInput = False
        ParentFont = False
        TabOrder = 0
      end
      object UpDown1: TUpDown
        Left = 233
        Top = 112
        Width = 17
        Height = 28
        Min = 0
        Max = 23
        Position = 0
        TabOrder = 1
        Wrap = False
      end
      object UpDown2: TUpDown
        Left = 281
        Top = 112
        Width = 17
        Height = 28
        Min = 0
        Max = 60
        Position = 0
        TabOrder = 2
        Wrap = False
        OnMouseUp = UpDown2MouseUp
      end
      object Edit1: TEdit
        Left = 200
        Top = 112
        Width = 33
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 3
        Text = '0'
      end
      object Edit2: TEdit
        Left = 248
        Top = 112
        Width = 33
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 4
        Text = '0'
      end
      object Edit3: TEdit
        Left = 200
        Top = 152
        Width = 137
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 5
        Text = '0'
        OnChange = Edit3Change
      end
      object Edit4: TEdit
        Left = 200
        Top = 192
        Width = 137
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 6
        Text = '0'
      end
      object Edit5: TEdit
        Left = 200
        Top = 232
        Width = 137
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 7
        Text = 'Edit5'
      end
      object Edit6: TEdit
        Left = 200
        Top = 272
        Width = 137
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 8
        Text = 'Edit6'
      end
      object Edit7: TEdit
        Left = 200
        Top = 312
        Width = 137
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 9
        Text = 'Edit7'
      end
      object ComboBox1: TComboBox
        Left = 200
        Top = 56
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ItemHeight = 20
        ParentFont = False
        TabOrder = 10
        Text = 'ComboBox1'
        Items.Strings = (
          #1060#1091#1090#1073#1086#1083
          #1061#1086#1082#1082#1077#1081
          #1041#1072#1089#1082#1077#1090#1073#1086#1083)
      end
      object BitBtn1: TBitBtn
        Left = 144
        Top = 368
        Width = 105
        Height = 57
        Caption = #1044#1086#1073#1072#1074#1080#1090#1100
        TabOrder = 11
        OnClick = BitBtn1Click
        Kind = bkOK
      end
    end
    object TabSheet2: TTabSheet
      Caption = #1059#1076#1072#1083#1080#1090#1100' '#1084#1072#1090#1095
      ImageIndex = 1
      object Label9: TLabel
        Left = 8
        Top = 16
        Width = 118
        Height = 25
        Caption = #1044#1072#1090#1072' '#1085#1072#1095#1072#1083#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label10: TLabel
        Left = 8
        Top = 80
        Width = 152
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1093#1086#1079#1103#1077#1074
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label11: TLabel
        Left = 8
        Top = 120
        Width = 151
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1075#1086#1089#1090#1077#1081
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label12: TLabel
        Left = 8
        Top = 48
        Width = 105
        Height = 25
        Caption = #1042#1080#1076' '#1089#1087#1086#1088#1090#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object DateTimePicker2: TDateTimePicker
        Left = 200
        Top = 16
        Width = 145
        Height = 28
        CalAlignment = dtaLeft
        Date = 41621.871699294
        Time = 41621.871699294
        DateFormat = dfShort
        DateMode = dmComboBox
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        Kind = dtkDate
        ParseInput = False
        ParentFont = False
        TabOrder = 0
      end
      object Edit8: TEdit
        Left = 200
        Top = 80
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
        Text = 'Edit8'
      end
      object Edit9: TEdit
        Left = 200
        Top = 120
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 2
        Text = 'Edit9'
      end
      object BitBtn2: TBitBtn
        Left = 152
        Top = 176
        Width = 89
        Height = 57
        Caption = #1059#1076#1072#1083#1080#1090#1100
        TabOrder = 3
        OnClick = BitBtn2Click
        Kind = bkOK
      end
      object ComboBox2: TComboBox
        Left = 200
        Top = 48
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ItemHeight = 20
        ParentFont = False
        TabOrder = 4
        Text = 'ComboBox2'
        Items.Strings = (
          #1060#1091#1090#1073#1086#1083
          #1061#1086#1082#1082#1077#1081
          #1041#1072#1089#1082#1077#1090#1073#1086#1083)
      end
    end
    object TabSheet3: TTabSheet
      Caption = #1044#1086#1073#1072#1074#1080#1090#1100' '#1088#1077#1079#1091#1083#1100#1090#1072#1090
      ImageIndex = 2
      object Label13: TLabel
        Left = 8
        Top = 16
        Width = 118
        Height = 25
        Caption = #1044#1072#1090#1072' '#1085#1072#1095#1072#1083#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label14: TLabel
        Left = 8
        Top = 88
        Width = 152
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1093#1086#1079#1103#1077#1074
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label15: TLabel
        Left = 8
        Top = 128
        Width = 151
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1075#1086#1089#1090#1077#1081
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label16: TLabel
        Left = 8
        Top = 168
        Width = 99
        Height = 25
        Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label17: TLabel
        Left = 8
        Top = 56
        Width = 105
        Height = 25
        Caption = #1042#1080#1076' '#1089#1087#1086#1088#1090#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object DateTimePicker3: TDateTimePicker
        Left = 200
        Top = 16
        Width = 145
        Height = 28
        CalAlignment = dtaLeft
        Date = 41621.871699294
        Time = 41621.871699294
        DateFormat = dfShort
        DateMode = dmComboBox
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        Kind = dtkDate
        ParseInput = False
        ParentFont = False
        TabOrder = 0
      end
      object Edit10: TEdit
        Left = 200
        Top = 88
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
        Text = '0'
      end
      object Edit11: TEdit
        Left = 200
        Top = 128
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 2
        Text = '0'
      end
      object ComboBox3: TComboBox
        Left = 200
        Top = 56
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ItemHeight = 20
        ParentFont = False
        TabOrder = 3
        Text = 'ComboBox2'
        Items.Strings = (
          #1060#1091#1090#1073#1086#1083
          #1061#1086#1082#1082#1077#1081
          #1041#1072#1089#1082#1077#1090#1073#1086#1083)
      end
      object BitBtn3: TBitBtn
        Left = 136
        Top = 224
        Width = 113
        Height = 65
        Caption = #1044#1086#1073#1072#1074#1080#1090#1100
        TabOrder = 4
        OnClick = BitBtn3Click
        Kind = bkOK
      end
      object ComboBox4: TComboBox
        Left = 200
        Top = 168
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ItemHeight = 20
        ParentFont = False
        TabOrder = 5
        Text = 'ComboBox4'
        Items.Strings = (
          #1055'1'
          #1053
          #1055'2')
      end
    end
    object TabSheet4: TTabSheet
      Caption = #1059#1076#1072#1083#1080#1090#1100' '#1088#1077#1079#1091#1083#1100#1090#1072#1090
      ImageIndex = 3
      object Label18: TLabel
        Left = 8
        Top = 16
        Width = 118
        Height = 25
        Caption = #1044#1072#1090#1072' '#1085#1072#1095#1072#1083#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label19: TLabel
        Left = 8
        Top = 56
        Width = 105
        Height = 25
        Caption = #1042#1080#1076' '#1089#1087#1086#1088#1090#1072
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label20: TLabel
        Left = 8
        Top = 88
        Width = 152
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1093#1086#1079#1103#1077#1074
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label21: TLabel
        Left = 8
        Top = 128
        Width = 151
        Height = 25
        Caption = #1050#1086#1084#1072#1085#1076#1072' '#1075#1086#1089#1090#1077#1081
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -20
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object DateTimePicker4: TDateTimePicker
        Left = 200
        Top = 16
        Width = 145
        Height = 28
        CalAlignment = dtaLeft
        Date = 41621.871699294
        Time = 41621.871699294
        DateFormat = dfShort
        DateMode = dmComboBox
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        Kind = dtkDate
        ParseInput = False
        ParentFont = False
        TabOrder = 0
      end
      object ComboBox5: TComboBox
        Left = 200
        Top = 56
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ItemHeight = 20
        ParentFont = False
        TabOrder = 1
        Text = 'ComboBox2'
        Items.Strings = (
          #1060#1091#1090#1073#1086#1083
          #1061#1086#1082#1082#1077#1081
          #1041#1072#1089#1082#1077#1090#1073#1086#1083)
      end
      object Edit12: TEdit
        Left = 200
        Top = 88
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 2
        Text = '0'
      end
      object Edit13: TEdit
        Left = 200
        Top = 128
        Width = 145
        Height = 28
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -17
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 3
        Text = '0'
      end
      object BitBtn4: TBitBtn
        Left = 144
        Top = 176
        Width = 113
        Height = 65
        Caption = #1059#1076#1072#1083#1080#1090#1100
        TabOrder = 4
        OnClick = BitBtn4Click
        Kind = bkOK
      end
    end
  end
end
