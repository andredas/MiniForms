using System;
using MiniForms.Interfaces;
namespace MiniForms.Modules
{
    class ModuleDetail : IModuleDetail
    {
        public string Name { get; set; }
        public Type ModuleType { get; set; }
        public ModuleDetail(string name, Type moduleType)
        {
            Name = name;
            ModuleType = moduleType;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}