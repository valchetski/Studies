﻿#pragma checksum "..\..\..\Autorun\AutorunControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C2841833F2F04BF258E882ACE114E596"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MyUninstaller {
    
    
    /// <summary>
    /// AutorunControl
    /// </summary>
    public partial class AutorunControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Autorun\AutorunControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AutorunProgramNameLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Autorun\AutorunControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DisableButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Autorun\AutorunControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProgramButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Autorun\AutorunControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AutorunProgramsListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyUninstaller;component/autorun/autoruncontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Autorun\AutorunControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AutorunProgramNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.DisableButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.AddProgramButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Autorun\AutorunControl.xaml"
            this.AddProgramButton.Click += new System.Windows.RoutedEventHandler(this.AddProgramButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AutorunProgramsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 18 "..\..\..\Autorun\AutorunControl.xaml"
            this.AutorunProgramsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AutorunProgramsListView_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

