using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniForms.Interfaces;
using MiniForms.Login;

namespace MiniForms.Repository
{
    class FileRepository : IUserRepository
    {
        private readonly FileInfo _userFile;

        public FileRepository(FileInfo userFile)
        {
            _userFile = userFile;
        }
        public FileRepository(string userFile)
        {
            _userFile = new FileInfo(userFile);
        }

        public FileRepository()
        {
            _userFile = new FileInfo(Path.Combine(Properties.Settings.Default.DefaultUserFileLocation, "Users.txt"));
        }

        private IEnumerable<IUser> _GetUsers()
        {
            if (!File.Exists(_userFile.FullName))
                return new List<IUser>();

            return File.ReadAllLines(_userFile.FullName)
                .Select(x => x.Split(','))
                .Select(x => new User(x[0], x[1]));
        }

        public IUser FindByName(string name)
        {
            return _GetUsers().FirstOrDefault(user => user.Username == name);
        }

    }
}
