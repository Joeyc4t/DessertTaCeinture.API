using System.Collections.Generic;

namespace Tools.Generic
{
    public class Query
    {
        public Query()
        {
            ParametersValues = new Dictionary<string, object>();
        }
        public string Text { get; set; }
        public IDictionary<string, object> ParametersValues { get; set; }
    }
}
