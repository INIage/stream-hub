namespace Foundation.Utility.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Json;

    public static class ObjectExtentions
    {
        public static T Cast<T>(this object element)
        {
            return Json.Deserialize<T>(element.ToString());
        }
    }
}
