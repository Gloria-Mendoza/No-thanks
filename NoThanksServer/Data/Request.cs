//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Request
    {
        public int idRequest { get; set; }
        public Nullable<int> senders { get; set; }
        public Nullable<int> receives { get; set; }
        public Nullable<int> states { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Player Player1 { get; set; }
    }
}
