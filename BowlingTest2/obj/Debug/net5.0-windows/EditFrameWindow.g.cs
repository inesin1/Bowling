﻿#pragma checksum "..\..\..\EditFrameWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0FBF9BD4F5DA6C2820E6B98310FFA850FC307EFA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BowlingTest2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace BowlingTest2 {
    
    
    /// <summary>
    /// EditFrameWindow
    /// </summary>
    public partial class EditFrameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\EditFrameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox frameTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\EditFrameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox shot1TextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\EditFrameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox shot2TextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\EditFrameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox shot3TextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\EditFrameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BowlingTest2;component/editframewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditFrameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.frameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\EditFrameWindow.xaml"
            this.frameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.frameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.shot1TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\EditFrameWindow.xaml"
            this.shot1TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.shotTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.shot2TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\EditFrameWindow.xaml"
            this.shot2TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.shotTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.shot3TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\EditFrameWindow.xaml"
            this.shot3TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.shotTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.okButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\EditFrameWindow.xaml"
            this.okButton.Click += new System.Windows.RoutedEventHandler(this.OKButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

