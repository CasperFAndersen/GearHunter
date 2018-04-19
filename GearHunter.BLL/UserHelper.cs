using GearHunter.Core;
using GearHunter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.BLL
{
    public class UserHelper
    {
        private IndividualFacade individualFacade = new IndividualFacade();
        private CompanyFacade companyFacade = new CompanyFacade();
        internal bool EmailAlreadyExists(string email)
        {
            Individual tempIndividual = individualFacade.GetByEmail(email);
            Company tempCompany = companyFacade.GetByEmail(email);
            return (tempIndividual == null && tempCompany == null) ? true : false;
        }

        internal void ValidateUser(User user, bool validate)
        {
            user.isValidated = validate;
        }
    }
}
