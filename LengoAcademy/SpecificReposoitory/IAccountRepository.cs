using LengoAcademy.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LengoAcademy.SpecificReposoitory
{
    public interface IAccountRepository
    {
        IdentityResult CreateUser(SignUpDTO signUpModel);
        IdentityResult NewRole(RoleDTO roleModel);
        List<IdentityRole> GetRoles();
    }
}
