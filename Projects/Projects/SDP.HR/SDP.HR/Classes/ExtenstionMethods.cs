using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SDP.HR.Classes
{
    public static class ExtenstionMethods
    {
        public static object GetObjectFromForm(this object obj, NameValueCollection frm)
        {
            List<PropertyInfo> lstPropertyInfo = obj.GetType().GetProperties().ToList();
            foreach (PropertyInfo pi in lstPropertyInfo)
            {
                BindValueToObject(pi, obj, frm[pi.Name]);
            }
            return obj;
        }
        public static DataTable ToDataTable<T>(this List<T> lst)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dt.Columns.Add(prop.Name, type);
            }
            foreach (T item in lst)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
        public static void AddRange<T>(this List<T> lst, NameValueCollection frm, string prefix)
        {
            List<PropertyInfo> lstPropertyInfo = typeof(T).GetProperties().ToList();
            string searchKey = (prefix + "_" + lstPropertyInfo[0].Name + "_r").ToLower();
            List<string> searchResult = frm.AllKeys.Where(k => k.ToLower().StartsWith(searchKey)).ToList();
            foreach (string result in searchResult)
            {
                string index = result.ToLower().Replace(searchKey, string.Empty);
                object obj = (T)Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo pi in lstPropertyInfo)
                {
                  string str  = (prefix + "_" + pi.Name + "_r" + index).ToLower();
                    string formItem = frm.AllKeys.Where(k => k.ToLower().StartsWith(str)).FirstOrDefault();
                    BindValueToObject(pi, obj, frm[formItem]);
                }
                lst.Add((T)obj);

            }
        }
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> result = new List<T>();
            List<PropertyInfo> lstPropertyInfo = typeof(T).GetProperties().ToList();
            foreach (DataRow dr in dt.Rows)
            {
                object obj = (T)Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo pi in lstPropertyInfo)
                {
                    BindValueToObject(pi, obj, dr[pi.Name]);

                }
                result.Add((T)obj);
            }
            return result;
        }

        private static void BindValueToObject(PropertyInfo pi, object obj, object value)
        {

            try
            {
                string pt = pi.PropertyType.Name.ToLower();
                switch (pt)
                {
                    case "boolean":
                        if (value is null)
                            obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                        else if (value.ToString() == "on"  || value.ToString() == "true")
                            obj.GetType().GetProperty(pi.Name).SetValue(obj, true);
                        else
                            obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                        break;
                    case "int64":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, long.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "int32":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, int.Parse(value.ToString().Replace(",",string.Empty)));
                        break;
                    case "int16":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, short.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "byte":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, byte.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "single":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, float.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "string":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, value.ToString());
                        break;
                    case "nullable`1":
                        string type = obj.GetType().GetProperty(pi.Name).ToString().Replace("System.Nullable`1[", string.Empty).Replace("]", string.Empty).Replace(pi.Name, string.Empty).Trim().ToLower();
                        switch (type)
                        {
                            case "system.boolean":
                                if (value is null)
                                    obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                                else if (value.ToString() == "on" || value.ToString() == "true")
                                    obj.GetType().GetProperty(pi.Name).SetValue(obj, true);
                                else
                                    obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                                break;

                            case "system.byte":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, byte.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.int16":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, short.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.int32":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, int.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.int64":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, long.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.single":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, float.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

            }
            catch 
            {

            }
        }
    }
}