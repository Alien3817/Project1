﻿#pragma checksum "..\..\information.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "19E0D420FF5B06FB7A12BCEF97516C866DF96ACE704A155725AD7BE693B11948"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Front_1;
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


namespace Front_1 {
    
    
    /// <summary>
    /// information
    /// </summary>
    public partial class information : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border close;
        
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
            System.Uri resourceLocater = new System.Uri("/Front_1;component/information.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\information.xaml"
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
            this.close = ((System.Windows.Controls.Border)(target));
            
            #line 20 "..\..\information.xaml"
            this.close.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.header_PreviewMouseUp);
            
            #line default
            #line hidden
            
            #line 20 "..\..\information.xaml"
            this.close.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.header_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\information.xaml"
            this.close.MouseLeave += new System.Windows.Input.MouseEventHandler(this.header_MouseLeave);
            
            #line default
            #line hidden
            
            #line 20 "..\..\information.xaml"
            this.close.MouseEnter += new System.Windows.Input.MouseEventHandler(this.header_MouseEnter);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
