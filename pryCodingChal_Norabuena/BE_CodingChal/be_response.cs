using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CodingChal
{
    public class be_response
    {
        public class be_response_google
        {
            public SearchInformation searchInformation;
            public class SearchInformation
            {
                public string totalResults;
            }
        }

        public class be_response_bing
        {
            public webPages WebPages;
            public class webPages
            {
                public string totalEstimatedMatches;
            }
        }
    }
}
