using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice
{
    public class DapperRepository : IRepository
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DbFourDapper;Trusted_Connection=True;";
        public async Task DeleteRowAsync<TEntity>(Guid id)
        {
            var type = typeof(TEntity);
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync($"DELETE FROM {type.Name}s WHERE Id=@Id", new { Id = id });
            }
        }
        public async Task<TEntity> GetAsync<TEntity>(Guid id)
        {
            var type = typeof(TEntity);
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {type.Name}s WHERE Id=@Id", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{type.Name} with id [{id}] could not be found.");
                return result;
            }
        }
        public async Task InsertAsync<TEntity>(TEntity t)
        {
            var insertQuery = GenerateInsertQuery<TEntity>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(insertQuery, t);
            }
        }

        public async Task<int> SaveRangeAsync<TEntity>(IEnumerable<TEntity> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery<TEntity>();
            using (var connection = new SqlConnection(connectionString))
            {
                inserted += await connection.ExecuteAsync(query, list);
            }
            return inserted;
        }
        private string GenerateInsertQuery<TEntity>()
        {
            var type = typeof(TEntity);
            var insertQuery = new StringBuilder($"INSERT INTO {type.Name}s ");
            var getProperties = typeof(TEntity).GetProperties();
            insertQuery.Append("(");
            var properties = GenerateListOfProperties(getProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");
            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");
            return insertQuery.ToString();
        }
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        public async Task UpdateAsync<TEntity>(TEntity t)
        {
            var updateQuery = GenerateUpdateQuery<TEntity>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(updateQuery, t);
            }
        }

        private string GenerateUpdateQuery<TEntity>()
        {
            var type = typeof(TEntity);
            var updateQuery = new StringBuilder($"UPDATE {type.Name}s SET ");
            var getProperties = typeof(TEntity).GetProperties();
            var properties = GenerateListOfProperties(getProperties);
            properties.ForEach(property =>
            {
                if (!property.Equals("Id") && !property.Equals("UserMails"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(" WHERE Id=@Id");
            return updateQuery.ToString();
        }

        //async Task<IEnumerable<TEntity>> IRepository.GetAllAsync<TEntity>()
        //{
        //    var type = typeof(TEntity);
        //    using(var connection = new SqlConnection(connectionString))
        //    {
        //        return await connection.QueryAsync<TEntity>($"SELECT * FROM {type.Name}s");
        //    }
        //}
        async Task<IEnumerable<TEntity>> IRepository.GetAllAsync<TEntity>()
        {
            var type = typeof(TEntity);
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<TEntity>($"SELECT * FROM {type.Name}s");
            }
        }

    }
}
