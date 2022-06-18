using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zhang.APi.Options;

namespace Zhang.APi.Helpers;

public class JwtHelper
{
    public string CreateToken(JwtOption jwtOption)
    {
        //1.定义需要存储的Claims
        var claims = new List<Claim>();

        //2.从appsettings.json读取密钥
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Key));

        //3.选择加密算法
        var algorithms = SecurityAlgorithms.HmacSha256;

        //4.生成签名证书
        var signingCredentials = new SigningCredentials(key, algorithms);

        //5.生成Token
        var token = new JwtSecurityToken(
            issuer: jwtOption.Issuer,
            audience: jwtOption.Audience,
            expires: DateTime.Now.AddDays(jwtOption.Expires),
            claims: claims,
            signingCredentials: signingCredentials
        );

        //6.将token变成string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}