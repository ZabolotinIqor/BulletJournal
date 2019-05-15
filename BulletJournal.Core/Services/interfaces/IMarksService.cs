using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface IMarksService
    {
        Task<IEnumerable<Marks>> GetAllMarks();
        Task AddMark(Marks marks);

    }
}
