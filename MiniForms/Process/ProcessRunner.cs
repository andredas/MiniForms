using System;
using System.Collections.Generic;
using System.IO;
using MiniForms.Interfaces;
using MiniForms.Properties;

namespace MiniForms.Process
{
    class ProcessRunner
    {

        private readonly List<IModule> _stepsList;
        public bool Continue { get; set; }

        public ProcessRunner(List<IModule> stepsList)
        {
            _stepsList = stepsList;
        }

        public void Start()
        {
            ProcessInstance instance = new ProcessInstance(Directory.CreateDirectory(Path.Combine(Settings.Default.DefaultTempFolder, Guid.NewGuid().ToString())));
            foreach (var module in _stepsList)
            {
                if (!instance.IsRunning)
                    break;

                module.Run(instance);

            }
            instance.CleanUp();
        }
    }

}