﻿

#pragma checksum "C:\Users\Nasos\Desktop\RadioApp\RadioApp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2F56175F5F90FEA98F3701C7898E2A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RadioApp
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 29 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ItemGridView_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 26 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MediaElement)(target)).CurrentStateChanged += this.myMediaElement_CurrentStateChanged;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 22 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Play_Button_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 23 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Pause_Button_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 24 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.RangeBase)(target)).ValueChanged += this.volumeSlider_ValueChanged;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 51 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Web_Button_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


