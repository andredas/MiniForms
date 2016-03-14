using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Wap.Helper.WbXml;
using MiniForms.Services;

namespace MiniForms.Interfaces
{
    interface IUserRepository
    {
        IUser FindByName(string name);
    }
}
