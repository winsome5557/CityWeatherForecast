﻿using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterface
{
    public interface ITokenService
    {
        Task<Token> GetToken();
    }
}
