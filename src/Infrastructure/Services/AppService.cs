﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayApp.Application.Common.Models;
using ArrayApp.Infrastructure.Services.Interfaces;

namespace ArrayApp.Infrastructure.Services;
public class AppService : IAppService
{
    public Task<AppDto> CreateAppAsync(AppCreateDto appCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppDto>> GetAllAppsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AppDto> GetAppByIdAsync(int appId)
    {
        throw new NotImplementedException();
    }
}
