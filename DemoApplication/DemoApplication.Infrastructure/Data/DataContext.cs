#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Data
{
    #region

    using System.Data.Entity;
    using Core.Model;

    #endregion

    public partial class DataContext : BaseContext<DataContext>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Log> Log { get; set; }        
    }    
}