using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Zhang.APi.Dtos;

namespace Zhang.APi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : AbpControllerBase
{
    protected ResultDto Success()
    {
        return new ResultDto(true, "响应成功", true);
    }

    protected ResultDto Success(dynamic data)
    {
        return new ResultDto(true, "响应成功", data);
    }

    protected ResultDto Fail(string message)
    {
        return new ResultDto(false, message, false);
    }
}