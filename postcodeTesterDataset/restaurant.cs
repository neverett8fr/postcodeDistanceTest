using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;
using System.Reflection;

namespace postcodeTesterDataset
{
    class restaurant
    {
        public string name { get; set; }
        public string postcode { get; set; }

        public restaurant(string name, string postcode)
        {
            this.name = name;
            this.postcode = postcode;

        }
        public restaurant()
        {

        }


    }
}
