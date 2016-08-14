﻿#pragma checksum "..\..\MealAddWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B01D9052228999D5E1D066CED3C6FD0C"
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


namespace DyningManagementSystem {
    
    
    /// <summary>
    /// MealAddWindow
    /// </summary>
    public partial class MealAddWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BorderIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MealTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PaymenTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MealAddButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IdLabel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DateLabel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PaymentLabel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label MealLabel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RedirectToRegisterPageButton;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MealAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image WindowColseIcon;
        
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
            System.Uri resourceLocater = new System.Uri("/DyningManagementSystem;component/mealaddwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MealAddWindow.xaml"
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
            
            #line 1 "..\..\MealAddWindow.xaml"
            ((DyningManagementSystem.MealAddWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MealAddWindow_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BorderIdTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\MealAddWindow.xaml"
            this.BorderIdTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.BorderIdTextBox_OnKeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MealTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\MealAddWindow.xaml"
            this.MealTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.MealTextBox_OnKeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PaymenTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\MealAddWindow.xaml"
            this.PaymenTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.PaymenTextBox_OnKeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MealAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MealAddWindow.xaml"
            this.MealAddButton.Click += new System.Windows.RoutedEventHandler(this.MealAddButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 30 "..\..\MealAddWindow.xaml"
            this.DatePicker.CalendarClosed += new System.Windows.RoutedEventHandler(this.DatePicker_OnCalendarClosed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.IdLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.DateLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.PaymentLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.MealLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.RedirectToRegisterPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MealAddWindow.xaml"
            this.RedirectToRegisterPageButton.Click += new System.Windows.RoutedEventHandler(this.RedirectToRegisterPageButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.WindowColseIcon = ((System.Windows.Controls.Image)(target));
            
            #line 45 "..\..\MealAddWindow.xaml"
            this.WindowColseIcon.MouseLeave += new System.Windows.Input.MouseEventHandler(this.WindowColseIcon_OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 45 "..\..\MealAddWindow.xaml"
            this.WindowColseIcon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.WindowColseIcon_OnMouseDown);
            
            #line default
            #line hidden
            
            #line 45 "..\..\MealAddWindow.xaml"
            this.WindowColseIcon.MouseEnter += new System.Windows.Input.MouseEventHandler(this.WindowColseIcon_OnMouseEnter);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

