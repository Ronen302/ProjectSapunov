//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectSapunov
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int IdOrder { get; set; }
        public string OrderName { get; set; }
        public string Status { get; set; }
        public int CountOfPart { get; set; }
        public decimal PriceOfPart { get; set; }
        public Nullable<decimal> FinalPriceOfPart { get; set; }
        public int IdProvider { get; set; }
    
        public virtual Provider Provider { get; set; }
    }
}
