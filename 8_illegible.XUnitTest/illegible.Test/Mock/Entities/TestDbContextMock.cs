//using illegible.DataStructure.DataContextDefine;
//using illegible.DataStructure.DataDefineExtentions;
//using illegible.Entity.BaseEntities;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace illegible.Test.Mock.Entities
//{
//    public partial class TestDbContextMock : DataContext
//    {
//        public TestDbContextMock(DbContextOptions<DataContext> options) : base(options)
//        {
//        }
//        //define entities here
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            modelBuilder.HasDefaultSchema("dbo");

//            var assembly = typeof(IBaseEntity).Assembly;
//            //dbset entities
//            modelBuilder.RegisterAllEntities<IBaseEntity>(assembly);

//            //config entities (config shiits like IEntityTypeConfiguration,.....)
//            modelBuilder.RegisterEntityTypeConfiguration(assembly);

//        }
//    }
//}
