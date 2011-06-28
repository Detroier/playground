using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Services
{
    public class SpecialEmployeServiceWhichDoesVerySpecialThings : IEmployeService
    {
        private IEmployeService _innerService;

        public SpecialEmployeServiceWhichDoesVerySpecialThings(IEmployeService innerService)
        {
            _innerService = innerService;
        }

        public List<Employe> GetTopPerformers(int count)
        {
            List<Employe> employes = _innerService.GetTopPerformers(count);
            employes[0].Name += " the Performer";
            return employes;
        }
    }
}