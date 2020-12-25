namespace Foundation.WebSockets.Server
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SocketAttribute : Attribute
    {
        public string Path { get; set; }

        public SocketAttribute(string path)
        {
            Path = path;
        }
    }
}
