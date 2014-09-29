using System;

namespace Problem3_GenericList
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class
        | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method,
        AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        public string Version { get; private set; }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}
