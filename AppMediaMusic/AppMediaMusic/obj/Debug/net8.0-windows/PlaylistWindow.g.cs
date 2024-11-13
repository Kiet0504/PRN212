﻿#pragma checksum "..\..\..\PlaylistWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05B7C3A582BD863CD05E67739C74DE5BA1205404"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppMediaMusic;
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


namespace AppMediaMusic {
    
    
    /// <summary>
    /// PlaylistWindow
    /// </summary>
    public partial class PlaylistWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 39 "..\..\..\PlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlaylistButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\PlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PlayListDataGrid;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\PlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AddPlaylistPopup;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\PlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlaylistNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\PlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border UpdatePlaylistPopup;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\PlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdatePlaylistNameTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppMediaMusic;component/playlistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PlaylistWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlaylistButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            
            #line 44 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPlaylistButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 45 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeletePlayListButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 46 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdatePlayListButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PlayListDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.AddPlaylistPopup = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.PlaylistNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 82 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveNewPlaylist_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 83 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelNewPlaylist_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.UpdatePlaylistPopup = ((System.Windows.Controls.Border)(target));
            return;
            case 13:
            this.UpdatePlaylistNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            
            #line 96 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveUpdatedPlaylist_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 97 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelUpdatePlaylist_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 67 "..\..\..\PlaylistWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewPlaylist_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

