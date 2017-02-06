using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using REST.Extensions;
using System.Web.Routing;
using System.Threading.Tasks;

namespace REST.Providers
{
    public class MssqlProvider: IProvider
    {
        DataTable table;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        public MssqlProvider(string connectionString)
        {
            this.table = new DataTable();
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand() { Connection = this.connection };
            this.adapter = new SqlDataAdapter() { SelectCommand = this.command };
        }

        // GET: api/resource или api/resource/id
        public async Task<DataTable> SelectAsync(string resource, int? id)
        {
            this.command.CommandText = (id == null) ?
                $"SELECT * FROM \"{resource}\";" : // заключение параметров в одинарные и двойные кавычки для защиты от SQL-инъекций
                $"SELECT * FROM \"{resource}\" WHERE \"Id\"='{id}';";

            using (this.adapter)
                await Task.Factory.StartNew(() => this.adapter.Fill(this.table));            

            return this.table;
        }

        // POST: api/resource
        public async Task<object> InsertAsync(string resource, object item)
        {
            var dictionary = new RouteValueDictionary(item); // создаём словарь, где keys - поля, values - значения полей

            int rowAffected;
            using (this.connection)
            {
                this.connection.Open();
                this.command.CommandText = String.Format("INSERT INTO \"{0}\" (\"{1}\") VALUES ('{2}');",
                                                        resource,
                                                        String.Join("\", \"", dictionary.Keys),
                                                        String.Join("', '", dictionary.Values)
                                                        );

                rowAffected = await this.command.ExecuteNonQueryAsync();
            }

            return rowAffected == 0 ? null : item;
        }

        // PUT: api/resource/id
        public async Task<object> UpdateAsync(string resource, object item, int id)
        {
            var dictionary = new RouteValueDictionary(item);

            int rowAffected;
            using (this.connection)
            {
                this.connection.Open();
                this.command.CommandText = $"UPDATE \"{resource}\" SET ";

                string temp = null;
                foreach (KeyValuePair<string, object> pair in dictionary) // генерирация update-запроса
                {
                    temp += (!pair.Equals(dictionary.Last())) ?
                        $"\"{pair.Key}\"='{pair.Value}', " :
                        $"\"{pair.Key}\"='{pair.Value}'"; // встретив последнюю пару, заканчиваем создание запроса
                }

                this.command.CommandText += $"{temp} WHERE \"Id\"='{id}'";

                rowAffected = await this.command.ExecuteNonQueryAsync();
            }

            return rowAffected == 0 ? null : item;
        }

        // DELETE: api/resource/id
        public async Task<object> DeleteAsync(string resource, int id)
        {
            int rowAffected;
            using (this.connection)
            {
                this.connection.Open();
                this.table = await SelectAsync(resource, id); // получаем удаляемый элемент для последующего возвращения

                this.command.CommandText = $"DELETE FROM \"{resource}\" WHERE \"Id\"='{id}';";
                rowAffected = await this.command.ExecuteNonQueryAsync();
            }

            return rowAffected == 0 ? null : this.table.ToItem(resource); // преобразование DataTable в объект
        }
    }
}