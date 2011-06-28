using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Services
{
    public class EmployeService : IEmployeService
    {
        public List<Employe> GetTopPerformers(int count)
        {
            List<Employe> result = new List<Employe>();

            for (int i = 0; i < count; i++)
            {
                result.Add(new Employe
                {
                    Name = "Employe" + i.ToString(),
                    Points = 1000 - i,
                    PositionName = "Position"
                });
            };

            return result;
        }
    }
}