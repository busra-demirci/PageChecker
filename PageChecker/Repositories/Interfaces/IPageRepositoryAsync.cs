﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PageCheckerAPI.DTOs.Page;
using PageCheckerAPI.DTOs.Shared;

namespace PageCheckerAPI.Repositories.Interfaces
{
    public interface IPageRepositoryAsync
    {
        Task<List<PageDto>> GetPages(Guid userId);
        Task<PageDto> GetPage(Guid pageId);
        Task<PageDto> AddPage(AddPageDto pageDto);
        Task DeletePage(DeleteDto pageDto, Guid userId);
        Task<PageDto> EditPage(PageDto pageDto);
    }
}
