using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyApp.API.DataModel
{

    
    public class AccountInfo
    {
        /// <summary>
        /// 登录账号数据模型
        /// </summary>


        
        [Key]//主键 自增
        /// <summary>
        /// 用户ID
        /// </summary>
        public int AccountId { get; set; }
      
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account  { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Pwd { get; set; }

    }
}
