using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XCore.Repositories.Extensions.Utilities
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<TEntity>(string orderByQueryString)
        {
            string[] strArray = orderByQueryString.Trim().Split(',');
            PropertyInfo[] properties = typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str1 in strArray)
            {
                if (!string.IsNullOrWhiteSpace(str1))
                {
                    string propertyFromQueryName = str1.Split(" ")[0];
                    PropertyInfo propertyInfo = ((IEnumerable<PropertyInfo>)properties).FirstOrDefault<PropertyInfo>((Func<PropertyInfo, bool>)(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)));
                    if (!(propertyInfo == (PropertyInfo)null))
                    {
                        string str2 = str1.EndsWith(" desc") ? "descending" : "ascending";
                        stringBuilder.Append(propertyInfo.Name.ToString() + " " + str2 + ", ");
                    }
                }
            }
            return stringBuilder.ToString().TrimEnd(',', ' ');
        }
    }
}
