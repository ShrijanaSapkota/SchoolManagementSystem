using Microsoft.AspNet.Identity.EntityFramework;

namespace DBSchoolManagementSystem
{
    internal class roleInstructor<T>
    {
        private RoleStore<IdentityRole> roleStore;

        public roleInstructor(RoleStore<IdentityRole> roleStore)
        {
            this.roleStore = roleStore;
        }
    }
}