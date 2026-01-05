using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interfaces;

public interface IProspectService
{
    Task<IEnumerable<Prospect>> GetTodayReminders();
    Task<Guid> AddProspect(Prospect prospect);
    Task<bool> UpdateFollowUp(Guid id, string comment, DateTime nextReminder);
}
