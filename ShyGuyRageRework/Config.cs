using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ShyGuyRageRework
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}