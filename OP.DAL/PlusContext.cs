using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Configuration;
using OP.Model;

namespace OP.DAL
{
    public class PlusContext:DbContext
    {
        public PlusContext()
            : base(nameOrConnectionString: ConnectionString())
        //: base("Data Source=LI-PC;Initial Catalog=MyProject;Integrated Security=True")
        {
            //this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<PlusContext>(null);
            //Database.SetInitializer<BaseContext>(new DropCreateDatabaseAlways<BaseContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BaseContext>());
        }

        /// <summary>
        /// 通过代码方式，获取连接字符串的名称返回。
        /// </summary>
        /// <returns></returns>
        private static string ConnectionString()
        {
            //根据不同的数据库类型，构造相应的连接字符串名称
            string dbType = System.Configuration.ConfigurationManager.AppSettings["ComponentDbType"];
            if (string.IsNullOrEmpty(dbType))
            {
                dbType = "sqlserver";
            }

            return string.Format("name={0}", dbType.ToLower());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //属性中，属性名称是ID的定义为主键。
            //modelBuilder.Properties<int>()
            //            .Where(p => p.Name == "ID")
            //            .Configure(p => p.IsKey());

        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<SysModules> SysModules { get; set; }
    }
}
