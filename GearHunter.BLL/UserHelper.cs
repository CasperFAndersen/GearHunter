using GearHunter.Core;
using GearHunter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.BLL
{
    public static class UserHelper
    {
        private static IndividualFacade individualFacade = new IndividualFacade();
        private static CompanyFacade companyFacade = new CompanyFacade();

        internal static bool EmailAlreadyExists(string email)
        {
            Individual tempIndividual = individualFacade.GetByEmail(email);
            Company tempCompany = companyFacade.GetByEmail(email);
            return (tempIndividual == null && tempCompany == null) ? true : false;
        }

        internal static void ValidateUser(User user, bool validate)
        {
            user.isValidated = validate;
        }
    }
}
