﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface IMarksService
    {
        Task<IEnumerable<Marks>> GetAllMarks();
        Task<Marks> AddMark(MarkDTO marks);

    }
}
