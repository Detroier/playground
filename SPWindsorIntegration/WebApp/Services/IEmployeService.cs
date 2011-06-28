using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Services
{
    public interface IEmployeService
    {
        List<Employe> GetTopPerformers(int count);
    }
}