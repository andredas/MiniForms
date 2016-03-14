using System.Collections.Generic;

namespace MiniForms.Interfaces
{
    interface IModuleLoader
    {
        IEnumerable<IModuleDetail> GetModuleDetails();

    }
}
