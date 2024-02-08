//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Produckt.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductIntake = new HashSet<ProductIntake>();
        }
    
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public byte[] MainImage { get; set; }
        public int UnitId { get; set; }
        public int Count { get; set; }
        public Nullable<bool> IsDelette { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductIntake> ProductIntake { get; set; }
    }
}
