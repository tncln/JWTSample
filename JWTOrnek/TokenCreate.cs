﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTOrnek
{
    public class TokenCreate
    {
        public string TokenOlustur()
        {
            var bytes= Encoding.UTF8.GetBytes("ademtunçalın");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",
                        audience:"http://localhost",
                        notBefore:DateTime.Now,
                        expires:DateTime.Now.AddMinutes(2),
                        signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
