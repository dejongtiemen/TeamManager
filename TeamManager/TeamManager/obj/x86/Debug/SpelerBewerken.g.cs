#pragma checksum "C:\Users\Gebruiker\Desktop\Informatica\2.Hoofdfase\13. Visual C#\TeamManager\TeamManager\SpelerBewerken.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "07A0EE55E0E682DFEC741F0B23D0C4DCFFF6B808D3EBA9B08712D6E34BB26AF4"
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
    partial class SpelerBewerken : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedValue(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedValue = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_NumberBox_Value(global::Microsoft.UI.Xaml.Controls.NumberBox obj, global::System.Double value)
            {
                obj.Value = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class SpelerBewerken_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ISpelerBewerken_Bindings
        {
            private global::TeamManager.SpelerBewerken dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBox obj2;
            private global::Windows.UI.Xaml.Controls.ComboBox obj3;
            private global::Microsoft.UI.Xaml.Controls.NumberBox obj4;
            private global::Microsoft.UI.Xaml.Controls.NumberBox obj5;
            private global::Windows.UI.Xaml.Controls.TextBox obj6;
            private global::Microsoft.UI.Xaml.Controls.NumberBox obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2TextDisabled = false;
            private static bool isobj3SelectedValueDisabled = false;
            private static bool isobj4ValueDisabled = false;
            private static bool isobj5ValueDisabled = false;
            private static bool isobj6TextDisabled = false;
            private static bool isobj7ValueDisabled = false;

            public SpelerBewerken_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 36 && columnNumber == 22)
                {
                    isobj2TextDisabled = true;
                }
                else if (lineNumber == 37 && columnNumber == 23)
                {
                    isobj3SelectedValueDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 29)
                {
                    isobj4ValueDisabled = true;
                }
                else if (lineNumber == 52 && columnNumber == 29)
                {
                    isobj5ValueDisabled = true;
                }
                else if (lineNumber == 53 && columnNumber == 71)
                {
                    isobj6TextDisabled = true;
                }
                else if (lineNumber == 54 && columnNumber == 29)
                {
                    isobj7ValueDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // SpelerBewerken.xaml line 36
                        this.obj2 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        break;
                    case 3: // SpelerBewerken.xaml line 37
                        this.obj3 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        break;
                    case 4: // SpelerBewerken.xaml line 51
                        this.obj4 = (global::Microsoft.UI.Xaml.Controls.NumberBox)target;
                        break;
                    case 5: // SpelerBewerken.xaml line 52
                        this.obj5 = (global::Microsoft.UI.Xaml.Controls.NumberBox)target;
                        break;
                    case 6: // SpelerBewerken.xaml line 53
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        break;
                    case 7: // SpelerBewerken.xaml line 54
                        this.obj7 = (global::Microsoft.UI.Xaml.Controls.NumberBox)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // ISpelerBewerken_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::TeamManager.SpelerBewerken)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::TeamManager.SpelerBewerken obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_speler(obj.speler, phase);
                    }
                }
            }
            private void Update_speler(global::DataAccessLibrary.Speler obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_speler_nummer(obj.nummer, phase);
                        this.Update_speler_positie(obj.positie, phase);
                        this.Update_speler_lengte(obj.lengte, phase);
                        this.Update_speler_leeftijd(obj.leeftijd, phase);
                        this.Update_speler_naam(obj.naam, phase);
                        this.Update_speler_gewicht(obj.gewicht, phase);
                    }
                }
            }
            private void Update_speler_nummer(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // SpelerBewerken.xaml line 36
                    if (!isobj2TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj2, obj.ToString(), null);
                    }
                }
            }
            private void Update_speler_positie(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // SpelerBewerken.xaml line 37
                    if (!isobj3SelectedValueDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedValue(this.obj3, obj, null);
                    }
                }
            }
            private void Update_speler_lengte(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // SpelerBewerken.xaml line 51
                    if (!isobj4ValueDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NumberBox_Value(this.obj4, obj);
                    }
                }
            }
            private void Update_speler_leeftijd(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // SpelerBewerken.xaml line 52
                    if (!isobj5ValueDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NumberBox_Value(this.obj5, obj);
                    }
                }
            }
            private void Update_speler_naam(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // SpelerBewerken.xaml line 53
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj6, obj, null);
                    }
                }
            }
            private void Update_speler_gewicht(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // SpelerBewerken.xaml line 54
                    if (!isobj7ValueDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NumberBox_Value(this.obj7, obj);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // SpelerBewerken.xaml line 36
                {
                    this.InvoerNummer = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // SpelerBewerken.xaml line 37
                {
                    this.Invoerpositie = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4: // SpelerBewerken.xaml line 51
                {
                    this.InvoerLengte = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 5: // SpelerBewerken.xaml line 52
                {
                    this.InvoerLeeftijd = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 6: // SpelerBewerken.xaml line 53
                {
                    this.InvoerNaam = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // SpelerBewerken.xaml line 54
                {
                    this.InvoerGewicht = (global::Microsoft.UI.Xaml.Controls.NumberBox)(target);
                }
                break;
            case 8: // SpelerBewerken.xaml line 56
                {
                    this.CompetitieCombobox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.CompetitieCombobox).SelectionChanged += this.CompetitieCombobox_SelectionChanged;
                }
                break;
            case 9: // SpelerBewerken.xaml line 57
                {
                    this.TeamCombobox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 10: // SpelerBewerken.xaml line 58
                {
                    this.terugButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.terugButton).Click += this.TerugButton_Click;
                }
                break;
            case 11: // SpelerBewerken.xaml line 59
                {
                    this.BewerkenButtonn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BewerkenButtonn).Click += this.BewerkenButton_Click;
                }
                break;
            case 12: // SpelerBewerken.xaml line 60
                {
                    this.SpelerToegevoegd = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 13: // SpelerBewerken.xaml line 65
                {
                    this.VeldenNietIngevuld = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 14: // SpelerBewerken.xaml line 70
                {
                    this.NummerIsInGebruik = (global::Microsoft.UI.Xaml.Controls.InfoBar)(target);
                }
                break;
            case 15: // SpelerBewerken.xaml line 75
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
            switch(connectionId)
            {
            case 1: // SpelerBewerken.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    SpelerBewerken_obj1_Bindings bindings = new SpelerBewerken_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

