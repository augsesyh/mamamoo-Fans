﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dongdongdongEntities : DbContext
    {
        public dongdongdongEntities()
            : base("name=dongdongdongEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Audiences> Audiences { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Comic> Comic { get; set; }
        public virtual DbSet<Comic_chapter> Comic_chapter { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Goods_Assess> Goods_Assess { get; set; }
        public virtual DbSet<Goods_Cate> Goods_Cate { get; set; }
        public virtual DbSet<Goods_Cate_Goods> Goods_Cate_Goods { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Reward> Reward { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Subscribe> Subscribe { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }
        public virtual DbSet<UP> UP { get; set; }
        public virtual DbSet<Usage> Usage { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_detail> User_detail { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<Video_Access> Video_Access { get; set; }
        public virtual DbSet<Video_detail> Video_detail { get; set; }
    }
}