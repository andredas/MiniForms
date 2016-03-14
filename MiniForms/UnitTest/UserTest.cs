using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniForms.Interfaces;
using MiniForms.Login;
using NUnit.Framework;

namespace MiniForms.UnitTest
{
    [TestFixture]
    class UserTest
    {
       
        private IEnumerable<IUser> _GetUsers()
        {
            yield return new User("Andre", "P@ssword");

        }
        
        public IUser FindByName(string name)
        {
            return (from IUser user in _GetUsers() where user.Username == name select user).FirstOrDefault();
        }
        [Test]
        public void GetUser()
        {
            Console.WriteLine(FindByName("Andre").Username);
        }
    }
}
