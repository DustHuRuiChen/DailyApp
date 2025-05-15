using DailyApp.API.ApiResponses;
using DailyApp.API.DataModel;
using DailyApp.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyApp.API.Controllers
{
    /// <summary>
    /// 待办事项接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WaitController : ControllerBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly DailyDbContext db;
/// <summary>
/// 构造函数
/// </summary>
/// <param name="db"></param>
        public WaitController(DailyDbContext _db) 
        {
            db = _db;
        }
        /// <summary>
        /// 统计待办数据
        /// </summary>
        /// <returns>1:统计成功 -99：出现异常</returns>

        [HttpGet]
        public IActionResult StatWait() 
        {
            ApiResponse res = new ApiResponse();

            try {
                var list = db.WaitInfo.ToList();
                var finishList = list.Where(t => t.Status == 1).ToList();

                StatWaitDTO statDto = new StatWaitDTO { TotalCount = list.Count, FinishCount = finishList.Count };

                res.ResultCode = 1;//统计成功
                res.Msg = "统计待办事项成功";
                res.ResultData = statDto;
            }
            catch(Exception) {
                res.ResultCode = -99;
                res.Msg = "服务器忙，请稍候";
            }

            return Ok(res);
        }
    }
}
