using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace App.Common
{
    public class EnumHelper
    {
        /// <summary>
        /// 取得列舉key,value
        /// </summary>
        /// <typeparam name="T">列舉泛型</typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumList<T>()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            Type type = typeof(T);
            if (type.IsEnum)
            {
                foreach (T item in System.Enum.GetValues(type))
                {
                    System.Enum en = System.Enum.Parse(typeof(T), item.ToString()) as System.Enum;
                    //取得Display名稱
                    var member = type.GetMember(item.ToString());
                    DisplayAttribute displayName = (DisplayAttribute)member[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();
                    d.Add(Convert.ToInt32(en), displayName.Name);
                }
            }
            return d;
        }


        public static object GetValueOf(Type enumType, string enumConst)
        {
            object value = System.Enum.Parse(enumType, enumConst);
            return value;
        }
    }

}
