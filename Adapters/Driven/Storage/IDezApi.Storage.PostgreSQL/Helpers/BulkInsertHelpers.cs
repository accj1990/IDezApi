using System.Data;
using System.Reflection;

namespace IDezApi.Storage.PostgreSQL.Helpers
{
    public static class BulkInsertHelpers
    {
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var dataTable = new DataTable
            {
                TableName = type.FullName ?? type.Name
            };

            // Define colunas baseadas nas propriedades públicas da classe
            foreach (var prop in properties)
            {
                var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, columnType);
            }

            // Adiciona as linhas
            foreach (var entity in list)
            {
                var values = new object?[properties.Length];

                for (int i = 0; i < properties.Length; i++)
                {
                    try
                    {
                        values[i] = properties[i].GetValue(entity);
                    }
                    catch
                    {
                        values[i] = DBNull.Value; // defensivo: ignora erro de leitura
                    }
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }

}
