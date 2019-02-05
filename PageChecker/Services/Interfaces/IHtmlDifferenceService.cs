﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PageCheckerAPI.Models;

namespace PageCheckerAPI.Services.Interfaces
{
    public interface IHtmlDifferenceService
    {
        string GetDifference(string html1, string html2, CheckingTypeEnum checkingType);
    }
}