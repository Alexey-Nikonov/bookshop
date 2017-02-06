using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data;
using System.Reflection;

namespace REST.Extensions
{
    public static class Extensions
    {
        public static IEnumerable ToList(this DataTable table, string resource)
        {
            Type type = Assembly.Load("REST").GetType($"REST.Models.{resource}"); // получаем тип таблицы
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type)); // создаём обобщённый список типа таблицы

            foreach (DataRow row in table.Rows)
            {
                var item = Activator.CreateInstance(type); // создаём объект типа таблицы
                foreach (DataColumn column in table.Columns)
                {
                    type.GetProperty(column.ColumnName).SetValue(item, row[column]);
                }

                list.Add(item);
            }

            return list;
        }

        public static object ToItem(this DataTable table, string resource)
        {
            Type type = Assembly.Load("REST").GetType($"REST.Models.{resource}");
            var item = Activator.CreateInstance(type);

            foreach (DataColumn column in table.Columns)
            {
                type.GetProperty(column.ColumnName).SetValue(item, table.Rows[0][column]);
            }

            return item;
        }

        public static string CorrectTableName(this string source)
        {
            return Assembly.Load("REST")
                .GetTypes()
                .Where(x => x.FullName.ToUpper() == $"REST.MODELS.{source.ToUpper()}")
                .First()
                .Name;
        }
    }
}