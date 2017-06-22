﻿#pragma checksum "..\..\Uninstaller1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CFC33939F907ED381B179776D18D901A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyUninstaller;
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
    /// UninstallerControl
    /// </summary>
    public partial class Uninstaller1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel ProgramDockPanel;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel InfoPanel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ProgramNameLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label VersionLabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PublisherLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LocationLabel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Uninstaller1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView programsListView;
        
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
            System.Uri resourceLocater = new System.Uri("/MyUninstaller;component/uninstaller1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Uninstaller1.xaml"
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
            this.ProgramDockPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.InfoPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.ProgramNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.RemoveButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Uninstaller1.xaml"
            this.RemoveButton.Click += new System.Windows.RoutedEventHandler(this.RemoveButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.VersionLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PublisherLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.LocationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.programsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 23 "..\..\Uninstaller1.xaml"
            this.programsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.programsListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 29 "..\..\Uninstaller1.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ProgramsListViewHeader_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 34 "..\..\Uninstaller1.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ProgramsListViewHeader_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 39 "..\..\Uninstaller1.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ProgramsListViewHeader_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

