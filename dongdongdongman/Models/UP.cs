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
    
    public partial class UP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UP()
        {
            this.Video = new HashSet<Video>();
        }
    
        public string UP_id { get; set; }
        public string User_detail_id { get; set; }
        public string UP_account { get; set; }
        public string UP_password { get; set; }
        public Nullable<int> UP_money { get; set; }
    
        public virtual Comic Comic { get; set; }
        public virtual Reward Reward { get; set; }
        public virtual User_detail User_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Video { get; set; }
    }
}
