
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
    
public partial class Friend
{

    public int idFriend { get; set; }

    public Nullable<int> idPlayer1 { get; set; }

    public Nullable<int> idPlayer2 { get; set; }



    public virtual Player Player { get; set; }

    public virtual Player Player1 { get; set; }

}

}
