//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShoppingCart
    {
        public int Cart_id { get; set; }
        public int Goods_id { get; set; }
        public int User_id { get; set; }
        public int Goods_num { get; set; }
    
        public virtual Goods Goods { get; set; }
        public virtual User User { get; set; }
    }
}
