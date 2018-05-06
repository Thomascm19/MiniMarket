//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniMarket
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            this.Compra = new HashSet<Compra>();
            this.Stock = new HashSet<Stock>();
        }
    
        public int Codigo_Proveedor { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Telefono { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Nit { get; set; }
        public string Ciudad { get; set; }
        public string Contacto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }

        [JsonIgnore]
        public virtual Proveedor proveedor { get; set; }
    }
}

