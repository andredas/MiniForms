using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using MiniForms.Interfaces;
using MiniForms.Repository;

namespace MiniForms.Services
{
    class AuthericationService
    {
        private IEnumerable<IUserRepository> _repo = new List<IUserRepository>
        {
            new HardcodedRepository(),
            //new FileRepository("admins.txt"),
            //new FileRepository("users.txt"),
            new FileRepository()
        };

        public bool IsValid(string username, string pass)
        {
            var users = _repo.Select(x => x.FindByName(username.ToUpper())).Where(x => x != null).ToList();

            if (users.Count() > 1)
            {
                MessageBox.Show("Error: Duplicated user in the repository");
                return false;
            }
            else
            {
                var user = users.FirstOrDefault();
                return (user != null && user.Password == pass);
            }

        }
    }
}
