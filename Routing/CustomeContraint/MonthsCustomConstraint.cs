
using System.Text.RegularExpressions;

namespace Routing.CustomeContraint
{
    //sales-report/2020/apr
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check whether the value existit
            if (!values.ContainsKey(routeKey)){
                return false; // not a match
            }
            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string? monthvalue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthvalue)) { 
                return true; //its a match
            }
            return false; //its not match
        }
    }
}
