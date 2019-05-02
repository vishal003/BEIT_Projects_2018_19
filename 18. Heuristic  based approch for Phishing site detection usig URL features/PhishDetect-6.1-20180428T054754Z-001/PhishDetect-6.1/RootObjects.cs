using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionTreeAlgorithmID3
{
    public class RootObject
    {
        public List<output> output_data { get; set; }
    }
    public class output
    {
        public string domain { get; set; }
        public string created_on { get; set; }
        public string expires_on { get; set; }
    }

}
