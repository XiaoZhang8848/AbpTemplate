using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Zhang.APi.Bases;

namespace Zhang.APi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : AbpControllerBase
{
    protected ResultDto<T> Success<T>(T data)
    {
        return new ResultDto<T>(true, "响应成功", data);
    }

    protected ResultDto<bool> Success()
    {
        return new ResultDto<bool>(true, "响应成功", true);
    }

    protected ResultDto<bool> Fail(string message)
    {
        return new ResultDto<bool>(false, message, false);
    }
}