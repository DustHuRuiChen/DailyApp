using Microsoft.EntityFrameworkCore;

namespace DailyApp.API.DataModel
{

    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DailyDbContext:DbContext
    {
        public DailyDbContext(DbContextOptions<DailyDbContext> options):base(options)
        {
            
        }

        /// <summary>
        /// 账号表
        /// </summary>
        public DbSet<AccountInfo> Accounts { get; set; }

        /// <summary>
        /// 待办事项
        /// </summary>
        public DbSet<WaitInfo> WaitInfo { get; set; }
        
    }
}
