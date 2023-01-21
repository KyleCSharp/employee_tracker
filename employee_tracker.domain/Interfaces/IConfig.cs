using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_tracker.domain.Interfaces
{
    public interface IConfig
    {
        string GetConnectionString();
    }
}
