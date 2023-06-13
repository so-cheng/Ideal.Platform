using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Data
{
    public enum RedisType
    {
        Authorize = 0,//授权
        Company = 1,//公司
        Dept = 2,//部门
        Post = 3,//岗位
        Role = 4,//角色
        Menu = 5,//菜单
        RoleMenu = 6,//角色菜单
        Account = 7,//账号
        Login = 8,//登录
        Sex = 10,//性别
        UserStatus = 11,//人员状态
        PoliticalStatus = 12,//政治面貌
        MyNation = 13,//名族
        MyEducationDegree = 14,//学历
        AccountStatus = 15,//账号类型
        IDCardType = 16,//证件类型
        CheckType = 17,//核算类型
        User = 18,//人员
        UserPost = 19,//人员岗位
        AccountLevel = 20//账号级别
    }
}
