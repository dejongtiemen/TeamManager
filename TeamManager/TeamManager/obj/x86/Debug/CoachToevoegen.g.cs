#pragma checksum "C:\Users\Gebruiker\Desktop\Informatica\2.Hoofdfase\13. Visual C#\TeamManager\TeamManager\CoachToevoegen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B95D5EB5AB2D2FB26BE4BFA6CF49D2D055FBB0C93531DF4EA091AEB22BE340FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamManager
{
    partial class CoachToevoegen : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // CoachToevoegen.xaml line 25
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element2).SelectionChanged += this.TextBlock_SelectionChanged;
                }
                break;
            case 3: // CoachToevoegen.xaml line 28
                {
                    this.InvoerNaam = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // CoachToevoegen.xaml line 29
                {
                    this.VoegCoachToe = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.VoegCoachToe).Click += this.KlikCoachToevoegenAsync;
                }
                break;
            case 5: // CoachToevoegen.xaml line 30
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Terug_click;
                }
                break;
            case 6: // CoachToevoegen.xaml line 31
                {
                    this.InvoerLeeftijd = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 7: // CoachToevoegen.xaml line 32
                {
                    this.CoachToegevoegd = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 8: // CoachToevoegen.xaml line 37
                {
                    this.VeldenNietIngevuld = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 9: // CoachToevoegen.xaml line 42
                {
                    this.NaamTeLang = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

