using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Prospect
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid ProgramId { get; set; } // Interés académico
    public string LastComment { get; set; } = string.Empty;
    public DateTime? NextReminder { get; set; } // Tu función de recordatorio
    public string Status { get; set; } = "Nuevo"; // Nuevo, Interesado, Inscrito
}
