﻿#pragma checksum "C:\Users\Gebruiker\Desktop\Informatica\2.Hoofdfase\13. Visual C#\TeamManager\TeamManager\SpelerToevoegen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "789A7CCC91A70B7677614FBA6C4E736F5DAFBCEBA367A550DC32EA76AEF85772"
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
    partial class SpelerToevoegen : 
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
            case 1: // SpelerToevoegen.xaml line 1
                {
                    this.SpelerToevoegen1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2: // SpelerToevoegen.xaml line 30
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element2).SelectionChanged += this.TextBlock_SelectionChanged;
                }
                break;
            case 3: // SpelerToevoegen.xaml line 37
                {
                    this.InvoerNummer = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // SpelerToevoegen.xaml line 38
                {
                    this.Invoerpositie = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // SpelerToevoegen.xaml line 52
                {
                    this.InvoerLengte = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 6: // SpelerToevoegen.xaml line 53
                {
                    this.InvoerLeeftijd = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 7: // SpelerToevoegen.xaml line 54
                {
                    this.InvoerNaam = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // SpelerToevoegen.xaml line 55
                {
                    this.InvoerGewicht = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 9: // SpelerToevoegen.xaml line 56
                {
                    this.VoegSpelerToe = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.VoegSpelerToe).Click += this.KlikSpelerToevoegen;
                }
                break;
            case 10: // SpelerToevoegen.xaml line 57
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Terug_Click;
                }
                break;
            case 11: // SpelerToevoegen.xaml line 58
                {
                    this.SpelerToegevoegd = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 12: // SpelerToevoegen.xaml line 63
                {
                    this.VeldenNietIngevuld = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 13: // SpelerToevoegen.xaml line 68
                {
                    this.NummerIsInGebruik = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 14: // SpelerToevoegen.xaml line 73
                {
                    this.TeVeelCharacters = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
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

