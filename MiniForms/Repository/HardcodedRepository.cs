using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MiniForms.Interfaces;
using MiniForms.Login;
using MiniForms.Services;

namespace MiniForms.Repository
{
    class HardcodedRepository : IUserRepository
    {
        private IEnumerable<IUser> _GetUsers()
        {
            yield return new User("ANDRE", "P@ssword");
        }
        public IUser FindByName(string name)
        {
            return _GetUsers().FirstOrDefault(user => user.Username == name);
        }
    }
}
