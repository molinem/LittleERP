﻿#pragma checksum "..\..\..\..\Presentacion\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "00F8DECDF1CEFA5FA9C01C4D50C0D8E7D3DD4EC0B474F6B2A34C3FB1C92BBB9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ERP;
using SourceChord.GridExtra;
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


namespace ERP {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtTitulo;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFiltroNombre;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFiltroApellidos;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBusqueda;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFiltroNombre;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFiltroApellidos;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Presentacion\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgCustomer;
        
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
            System.Uri resourceLocater = new System.Uri("/ERP;component/presentacion/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentacion\MainWindow.xaml"
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
            this.txtTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            
            #line 39 "..\..\..\..\Presentacion\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnNewCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 42 "..\..\..\..\Presentacion\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnModifyCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblFiltroNombre = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblFiltroApellidos = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnBusqueda = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\Presentacion\MainWindow.xaml"
            this.btnBusqueda.Click += new System.Windows.RoutedEventHandler(this.btnBusqueda_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtFiltroNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtFiltroApellidos = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.dgCustomer = ((System.Windows.Controls.DataGrid)(target));
            
            #line 85 "..\..\..\..\Presentacion\MainWindow.xaml"
            this.dgCustomer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgClientes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

