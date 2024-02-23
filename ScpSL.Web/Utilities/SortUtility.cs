using ScpSL.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScpSL.Web.Utilities
{
    public static class SortUtility
    {
        /* 
         * Attempts to sort the full server list based on official code and distance to the server the info was retrieved from
         * Similar to how Northwood does it for their full server display
         * It is not accurate!
        */
        public static List<FullServerInfo> SortFullServerList(this List<FullServerInfo> list)
        {
            return list.OrderByDescending(ls => ls.OfficialCode)
                .ThenBy(ls => ls.Distance)
                .ThenBy(ls => ls.AccountId)
                .ThenBy(ls => ls.Port)
                .ToList();
        }
    }
}
