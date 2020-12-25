namespace Foundation.Connect
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SiteNameAttribute : Attribute
    {
        public string Name { get; set; }

        public SiteNameAttribute(string name)
        {
            Name = name;
        }
    }
}
