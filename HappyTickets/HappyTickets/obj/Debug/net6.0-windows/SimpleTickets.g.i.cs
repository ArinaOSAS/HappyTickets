﻿#pragma checksum "..\..\..\SimpleTickets.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D01CBB9919B94CD6A3C00055C6A47D5563726968"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HappyTickets;
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


namespace HappyTickets {
    
    
    /// <summary>
    /// SimpleTickets
    /// </summary>
    public partial class SimpleTickets : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 108 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EvenOdd;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fullSquare;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fullCube;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NumberPartionsCombo;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextComboBox;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PartionComboBox;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DivisionInteger;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NumberTicketsCombo;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextComboBoxTickets;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\SimpleTickets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TicketsComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HappyTickets;component/simpletickets.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SimpleTickets.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 69 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.WrapPanel_mouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 78 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_minimized);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 81 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_close);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 105 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_EvenOdd);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EvenOdd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 110 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_FullCubesSquares);
            
            #line default
            #line hidden
            return;
            case 7:
            this.fullSquare = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.fullCube = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.NumberPartionsCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 116 "..\..\..\SimpleTickets.xaml"
            this.NumberPartionsCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.TextComboBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.PartionComboBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            
            #line 120 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_DivisionInteger);
            
            #line default
            #line hidden
            return;
            case 13:
            this.DivisionInteger = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            
            #line 125 "..\..\..\SimpleTickets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Back);
            
            #line default
            #line hidden
            return;
            case 15:
            this.NumberTicketsCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 130 "..\..\..\SimpleTickets.xaml"
            this.NumberTicketsCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChangedTickets);
            
            #line default
            #line hidden
            return;
            case 16:
            this.TextComboBoxTickets = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.TicketsComboBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

