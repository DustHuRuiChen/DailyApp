namespace DailyApp.API.DTOs
{

    /// <summary>
    /// 账号DTO （用来接受注册信息）
    /// </summary>
    public class AccountInfoDTO
    {
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Pwd { get; set; }
    }
}
