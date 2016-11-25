using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearnApi.Models
{
    public abstract  class clsJSONResource
    {
        public List<clsLink> Links = new List<clsLink>();

        public void agregarLink(clsLink lobj_link)
        {
            Links.Add(lobj_link);
        }
    }
}