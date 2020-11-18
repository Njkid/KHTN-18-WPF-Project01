﻿#pragma checksum "..\..\AddRP.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5F2A88983C37D266F1E0F31B7BD3E24584AE0DDE386BC7B03660EE0B1649E59E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Fluent;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using foodrecipe;


namespace foodrecipe {
    
    
    /// <summary>
    /// AddRP
    /// </summary>
    public partial class AddRP : Fluent.RibbonWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rpNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock stepCurrentText;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView stepsListView;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PreImgButton;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button currentStepUpload;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image NextImgButton;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\AddRP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StepText;
        
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
            System.Uri resourceLocater = new System.Uri("/foodrecipe;component/addrp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddRP.xaml"
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
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\AddRP.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\AddRP.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rpNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\AddRP.xaml"
            this.rpNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rpNameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 26 "..\..\AddRP.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.preStepButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stepCurrentText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 28 "..\..\AddRP.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.nextStepButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.stepsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 40 "..\..\AddRP.xaml"
            this.stepsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataTemplate_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 95 "..\..\AddRP.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.preStepButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PreImgButton = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.currentStepUpload = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\AddRP.xaml"
            this.currentStepUpload.Click += new System.Windows.RoutedEventHandler(this.currentStepUpload_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 99 "..\..\AddRP.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.nextStepButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.NextImgButton = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.StepText = ((System.Windows.Controls.TextBox)(target));
            
            #line 105 "..\..\AddRP.xaml"
            this.StepText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.StepText_TextChanged);
            
            #line default
            #line hidden
            
            #line 105 "..\..\AddRP.xaml"
            this.StepText.KeyUp += new System.Windows.Input.KeyEventHandler(this.StepText_KeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

