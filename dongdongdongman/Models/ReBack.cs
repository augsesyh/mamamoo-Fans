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
    
    public partial class ReBack
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReBack()
        {
            this.ReBack1 = new HashSet<ReBack>();
            this.Report = new HashSet<Report>();
        }
    
        public int ReBack_id { get; set; }
        public int Comment_id { get; set; }
        public int User_id { get; set; }
        public string ReBack_intro { get; set; }
        public Nullable<System.DateTime> ReBack_time { get; set; }
        public Nullable<int> Reback1_id { get; set; }
    
        public virtual Comment Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReBack> ReBack1 { get; set; }
        public virtual ReBack ReBack2 { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Report { get; set; }
    }
}
