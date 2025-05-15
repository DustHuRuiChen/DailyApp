using AutoMapper;
using DailyApp.API.DataModel;
using DailyApp.API.DTOs;

namespace DailyApp.API.AutoMappers
{
    /// <summary>
    /// model之间转换设置
    /// </summary>
    public class AutoMapperSetting:Profile
    {
        public AutoMapperSetting()
        {
            CreateMap<AccountInfoDTO, AccountInfo>().ReverseMap();
            
        }
    }
}
