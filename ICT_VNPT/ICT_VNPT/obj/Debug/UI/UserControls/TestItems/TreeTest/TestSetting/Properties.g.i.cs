﻿#pragma checksum "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37AC29EC6341D1B74017E0F2CFC91A458470F7D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ICT_VNPT.UI.UserControls.TestItems.TreeTest.TestSetting;
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


namespace ICT_VNPT.UI.UserControls.TestItems.TreeTest.TestSetting {
    
    
    /// <summary>
    /// Properties
    /// </summary>
    public partial class Properties : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbIsPower;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbIsCheck;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbGuide;
        
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
            System.Uri resourceLocater = new System.Uri("/ICT_VNPT;component/ui/usercontrols/testitems/treetest/testsetting/properties.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
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
            
            #line 57 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
            ((System.Windows.Controls.TextBox)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.FrameWorkElement_Focus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbbIsPower = ((System.Windows.Controls.ComboBox)(target));
            
            #line 59 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
            this.cbbIsPower.GotFocus += new System.Windows.RoutedEventHandler(this.FrameWorkElement_Focus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbbIsCheck = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\..\..\..\..\..\UI\UserControls\TestItems\TreeTest\TestSetting\Properties.xaml"
            this.cbbIsCheck.GotFocus += new System.Windows.RoutedEventHandler(this.FrameWorkElement_Focus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbGuide = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

