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
    
    public partial class ProductIntake
    {
        public int Id { get; set; }
        public Nullable<int> IntakeId { get; set; }
        public int SerialNumber { get; set; }
        public int Count { get; set; }
        public Nullable<int> Summa { get; set; }
    
        public virtual Intake Intake { get; set; }
        public virtual Product Product { get; set; }
    }
}
