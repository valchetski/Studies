﻿#pragma checksum "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8C388688C9F9F93DE0E04F3B723DA24B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyUninstaller.Controls;
using MyUninstaller.UninstallerViews;
using MyUninstaller.UninstallerViews.ResidualFilesViews;
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


namespace MyUninstaller.UninstallerViews.ResidualFilesViews {
    
    
    /// <summary>
    /// FindResidualFiles
    /// </summary>
    public partial class FindResidualFiles : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem WaitTabItem;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem OutputTabItem;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView ResidualFilesTreeView;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem ResultTabItem;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ResultTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/MyUninstaller;component/uninstallerviews/residualfilesviews/findresidualfiles.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
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
            
            #line 9 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
            ((MyUninstaller.UninstallerViews.ResidualFilesViews.FindResidualFiles)(target)).ContentRendered += new System.EventHandler(this.FindResidualFiles_OnContentRendered);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WaitTabItem = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.OutputTabItem = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.ResidualFilesTreeView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 6:
            this.RemoveButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
            this.RemoveButton.Click += new System.Windows.RoutedEventHandler(this.RemoveButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ResultTabItem = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.ResultTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 51 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 13 "..\..\..\..\UninstallerViews\ResidualFilesViews\FindResidualFiles.xaml"
            ((System.Windows.Controls.CheckBox)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

