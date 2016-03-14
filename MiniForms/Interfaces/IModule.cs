using MiniForms.Process;

namespace MiniForms.Interfaces
{
    interface IModule
    {
        string Name { get; set; }

        string Description { get; set; }

        void EditModule();
        void Run(ProcessInstance instance);

        string ToString();
    }
}
