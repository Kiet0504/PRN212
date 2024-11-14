// Updated by XamlIntelliSenseFileGenerator 11/14/2024 10:12:08 AM
#pragma checksum "..\..\..\SongDetail.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E454A37EA3DAA62C2B0D55A5F5B51813C99527B2"
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


namespace AppMediaMusic
{


    /// <summary>
    /// SongDetail
    /// </summary>
    public partial class SongDetail : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 11 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mediaPlayer;

#line default
#line hidden


#line 14 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SongTitleText;

#line default
#line hidden


#line 15 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ArtistNameText;

#line default
#line hidden


#line 31 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CurrentTimeText;

#line default
#line hidden


#line 32 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider TimelineSlider;

#line default
#line hidden


#line 41 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalTimeText;

#line default
#line hidden


#line 47 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlayPauseButton;

#line default
#line hidden


#line 150 "..\..\..\SongDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider VolumeSlider;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppMediaMusic;V1.0.0.0;component/songdetail.xaml", System.UriKind.Relative);

#line 1 "..\..\..\SongDetail.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.mediaPlayer = ((System.Windows.Controls.MediaElement)(target));
                    return;
                case 2:
                    this.SongTitleText = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.ArtistNameText = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 4:
                    this.CurrentTimeText = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 5:
                    this.TimelineSlider = ((System.Windows.Controls.Slider)(target));

#line 34 "..\..\..\SongDetail.xaml"
                    this.TimelineSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.TimelineSlider_ValueChanged);

#line default
#line hidden

#line 35 "..\..\..\SongDetail.xaml"
                    this.TimelineSlider.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TimelineSlider_PreviewMouseDown);

#line default
#line hidden

#line 36 "..\..\..\SongDetail.xaml"
                    this.TimelineSlider.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TimelineSlider_PreviewMouseUp);

#line default
#line hidden
                    return;
                case 6:
                    this.TotalTimeText = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 7:
                    this.PlayPauseButton = ((System.Windows.Controls.Button)(target));

#line 52 "..\..\..\SongDetail.xaml"
                    this.PlayPauseButton.Click += new System.Windows.RoutedEventHandler(this.PlayPause_Click);

#line default
#line hidden
                    return;
                case 8:

#line 72 "..\..\..\SongDetail.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RewindButton_Click);

#line default
#line hidden
                    return;
                case 9:

#line 92 "..\..\..\SongDetail.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FastForwardButton_Click);

#line default
#line hidden
                    return;
                case 10:

#line 112 "..\..\..\SongDetail.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Previous_Click);

#line default
#line hidden
                    return;
                case 11:

#line 132 "..\..\..\SongDetail.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Next_Click);

#line default
#line hidden
                    return;
                case 12:
                    this.VolumeSlider = ((System.Windows.Controls.Slider)(target));

#line 150 "..\..\..\SongDetail.xaml"
                    this.VolumeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.VolumeSlider_ValueChanged);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Media.RotateTransform rotateTransform;
    }
}

