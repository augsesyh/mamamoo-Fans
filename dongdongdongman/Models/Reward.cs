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
    
    public partial class Reward
    {
        public int Reward_id { get; set; }
        public int UP_id { get; set; }
        public decimal Reward_num { get; set; }
        public System.DateTime Reward_time { get; set; }
        public int User_id { get; set; }
    
        public virtual UP UP { get; set; }
        public virtual User User { get; set; }
    }
}
