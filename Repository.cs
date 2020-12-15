using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// Dapper.SimpleRepository was created by Casey Crookston. You are free to use it however you would like.
// I hope it makes your developent faster and easier.

namespace Dapper.SimpleRepository
{
    /// <summary>
    /// Main class for Dapper.SimpleRepository extensions. This option is not strongly typed.
    /// </summary>
    public class Repository : IRepositoryGeneric
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inject the connection string (as a string) when creating an instance of this class.
        /// </summary>
        /// <param name="connectionString"></param>
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection OpenConnection(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        // ----------- GET Single Item Methods ----------- //

        /// <summary>
        /// <para>Get a specific record by the primary key (id).</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the primary key matches the supplied id.</returns>
        public T Get<T>(int id, int? commandTimeout = null)
        {
            T entity;
            using (var connection = OpenConnection(_connectionString))
            {
                entity = connection.Get<T>(id, commandTimeout: commandTimeout);
            }
            return entity;
        }

        /// <summary>
        /// <para>Get a specific record by the primary key (id).</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the primary key matches the supplied id.</returns>
        public async Task<T> GetAsync<T>(int id, int? commandTimeout = null)
        {
            T entity;
            using (var connection = OpenConnection(_connectionString))
            {
                entity = await connection.GetAsync<T>(id, commandTimeout: commandTimeout);
            }
            return entity;
        }

        /// <summary>
        /// <para>Get a specific record that matches the specified filter.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        public T Get<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = connection.GetList<T>(where, new DynamicParameters(parms), commandTimeout: commandTimeout);
                else
                    entities = connection.GetList<T>(where, commandTimeout: commandTimeout);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// <para>Get a specific record that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        public async Task<T> GetAsync<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = await connection.GetListAsync<T>(where, new DynamicParameters(parms), commandTimeout: commandTimeout);
                else
                    entities = await connection.GetListAsync<T>(where, commandTimeout: commandTimeout);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// <para>Get a specific type from a query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public T GetFromQuery<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            T entity;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entity = connection.Query<T>(query, new DynamicParameters(parms), commandTimeout: commandTimeout).FirstOrDefault();
                else
                    entity = connection.Query<T>(query, commandTimeout: commandTimeout).FirstOrDefault();
            }
            return entity;
        }

        /// <summary>
        /// <para>Get a specific type from a query.  This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public async Task<T> GetFromQueryAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entity;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                {
                    entity = await connection.QueryAsync<T>(query, new DynamicParameters(parms), commandTimeout: commandTimeout);
                }
                else
                {
                    entity = await connection.QueryAsync<T>(query, commandTimeout: commandTimeout);
                }
            }
            return entity.FirstOrDefault();
        }

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// <para>Get an IEnumerable of all records.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        public IEnumerable<T> GetAll<T>()
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = connection.GetList<T>();
            }
            return entities;
        }

        /// <summary>
        /// <para>Get an IEnumerable of all records.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <returns>An IEnumerable of type T.</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = await connection.GetListAsync<T>();
            }
            return entities;
        }

        /// <summary>
        /// <para>Get an IEnumerable that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        public IEnumerable<T> GetList<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = connection.GetList<T>(where, new DynamicParameters(parms), commandTimeout: commandTimeout);
                else
                    entities = connection.GetList<T>(where, commandTimeout: commandTimeout);
            }
            return entities;
        }

        /// <summary>
        /// <para>Get an IEnumerable that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        public async Task<IEnumerable<T>> GetListAsync<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = await connection.GetListAsync<T>(where, new DynamicParameters(parms), commandTimeout: commandTimeout);
                else
                    entities = await connection.GetListAsync<T>(where, commandTimeout: commandTimeout);
            }
            return entities;
        }

        /// <summary>
        /// <para>Get an IEnumerable based on a custom query and any (optional) parameters</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        public IEnumerable<T> GetListFromQuery<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = connection.Query<T>(query, new DynamicParameters(parms), commandTimeout: commandTimeout);
                else
                    entities = connection.Query<T>(query, commandTimeout: commandTimeout);
            }
            return entities;
        }

        /// <summary>
        /// <para>Get an IEnumerable based on a custom query and any (optional) parameters</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        public async Task<IEnumerable<T>> GetListFromQueryAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = await connection.QueryAsync<T>(query, new DynamicParameters(parms), commandTimeout: commandTimeout);
                else
                    entities = await connection.QueryAsync<T>(query, commandTimeout: commandTimeout);
            }
            return entities;
        }

        /// <summary>
        /// <para>Get a paged IEnumerable of all records.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        public IEnumerable<T> GetListPaged<T>(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = connection.GetListPaged<T>(pageNumber, rowsPerPage, where, orderBy, parms, commandTimeout: commandTimeout);
            }
            return entities;
        }

        /// <summary>
        /// <para>Get a paged IEnumerable of all records.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        public async Task<IEnumerable<T>> GetListPagedAsync<T>(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = await connection.GetListPagedAsync<T>(pageNumber, rowsPerPage, where, orderBy, parms, commandTimeout: commandTimeout);
            }
            return entities;
        }

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// <para>Update an existing record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public int Update<T>(T entity, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.Update(entity, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Update an existing record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout"></param>
        /// <returns>Number of rows affected.</returns>
        public async Task<int> UpdateAsync<T>(T entity, int? commandTimeout = null)
        {
            int records;
            using (var connection = OpenConnection(_connectionString))
            {
                records = await connection.UpdateAsync(entity, commandTimeout: commandTimeout);
            }
            return records;
        }

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// <para>Insert a new record.</para>
        /// <para>Inserts into the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        public int? Insert<T>(T entity, int? commandTimeout = null)
        {
            int? newId;
            using (var connection = OpenConnection(_connectionString))
            {
                newId = connection.Insert<T>(entity, commandTimeout: commandTimeout);
            }
            return newId;
        }

        /// <summary>
        /// <para>Insert a new record.</para>
        /// <para>Inserts into the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        public async Task<int?> InsertAsync<T>(T entity, int? commandTimeout = null)
        {
            int? newId;
            using (var connection = OpenConnection(_connectionString))
            {
                newId = await connection.InsertAsync<T>(entity, commandTimeout: commandTimeout);
            }
            return newId;
        }

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// <para>Delete a record by primary key (id).</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public int Delete<T>(int id, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.Delete<T>(id, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Delete a record by primary key (id).</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public async Task<int> DeleteAsync<T>(int id, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return await connection.DeleteAsync<T>(id, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Delete all records that match the specified filter.</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the WHERE clause.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public int Delete<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.DeleteList<T>(where, new DynamicParameters(parms), commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Delete all records that match the specified filter.</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the WHERE clause.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public async Task<int> DeleteAsync<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return await connection.DeleteListAsync<T>(where, new DynamicParameters(parms), commandTimeout: commandTimeout);
            }
        }

        // ----------- EXECUTE QUERY Method ----------- //

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public void ExecuteQuery<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                connection.Query<T>(query, param: parms, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public async Task ExecuteQueryAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, param: parms, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public T ExecuteScalar<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.ExecuteScalar<T>(query, param: parms, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public async Task<T> ExecuteScalarAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return await connection.ExecuteScalarAsync<T>(query, param: parms, commandTimeout: commandTimeout);
            }
        }

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public void ExecuteSP(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                connection.Execute(storedProcedureName, parms, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public async Task ExecuteSPAsync(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                await connection.ExecuteAsync(storedProcedureName, parms, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            }
        }

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T.</returns>
        public T ExecuteSPSingle<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = connection.Query<T>(storedProcedureName, parms, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T.</returns>
        public async Task<T> ExecuteSPSingleAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = await connection.QueryAsync<T>(storedProcedureName, parms, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T.</returns>
        public IEnumerable<T> ExecuteSPList<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                if (commandTimeout == null) commandTimeout = 60;
                IEnumerable<T> output = connection.Query<T>(storedProcedureName, param: parms, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
                return output;
            }
        }

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T.</returns>
        public async Task<IEnumerable<T>> ExecuteSPListAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                if (commandTimeout == null) commandTimeout = 60;
                var output = await connection.QueryAsync<T>(storedProcedureName, param: parms, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
                return output;
            }
        }
    }

    /// <summary>
    /// Main class for Dapper.SimpleRepository extensions. This option is strongly typed.
    /// </summary>
    /// <typeparam name="T">The type that matches the database table.</typeparam>
    public class Repository<T> : IRepositoryStrong<T>
    {
        private readonly Repository _base;

        /// <summary>
        /// Inject the connection string (as a string) when creating an instance of this class.
        /// </summary>
        /// <param name="connectionString"></param>
        public Repository(string connectionString)
        {
            _base = new Repository(connectionString);
        }

        // ----------- GET Single Item Methods ----------- //


        /// <summary>
        /// <para>Get a specific record by the primary key (id).</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the primary key matches the supplied id.</returns>
        public T Get(int id, int? commandTimeout = null) => _base.Get<T>(id, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a specific record by the primary key (id).</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the primary key matches the supplied id.</returns>
        public async Task<T> GetAsync(int id, int? commandTimeout = null) => await _base.GetAsync<T>(id, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a specific record that matches the specified filter.</para>
        /// </summary>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        public T Get(string where, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.Get<T>(where, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a specific record that matches the specified filter.</para>
        /// </summary>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        public async Task<T> GetAsync(string where, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.GetAsync<T>(where, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a specific type from a query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public T GetFromQuery(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.GetFromQuery<T>(query, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a specific type from a query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public async Task<T> GetFromQueryAsync(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.GetFromQueryAsync<T>(query, parms, commandTimeout: commandTimeout);

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// <para>Get an IEnumerable of all records.</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        public IEnumerable<T> GetAll() => _base.GetAll<T>();

        /// <summary>
        /// <para>Get an IEnumerable of all records.</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        public async Task<IEnumerable<T>> GetAllAsync() => await _base.GetAllAsync<T>();

        /// <summary>
        /// <para>Get an IEnumerable that matches the specified filter</para>
        /// </summary>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        public IEnumerable<T> GetList(string where, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.GetList<T>(where, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get an IEnumerable that matches the specified filter</para>
        /// </summary>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        public async Task<IEnumerable<T>> GetListAsync(string where, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.GetListAsync<T>(where, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get an IEnumerable based on a custom query and any (optional) parameters</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        public IEnumerable<T> GetListFromQuery(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.GetListFromQuery<T>(query, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get an IEnumerable based on a custom query and any (optional) parameters</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        public async Task<IEnumerable<T>> GetListFromQueryAsync(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.GetListFromQueryAsync<T>(query, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a paged IEnumerable of all records.</para>
        /// </summary>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        public IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.GetListPaged<T>(pageNumber, rowsPerPage, where, orderBy, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Get a paged IEnumerable of all records.</para>
        /// </summary>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        public async Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.GetListPagedAsync<T>(pageNumber, rowsPerPage, where, orderBy, parms, commandTimeout: commandTimeout);

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// <para>Update an existing record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public int Update(T entity, int? commandTimeout = null) => _base.Update<T>(entity, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Update an existing record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public async Task<int> UpdateAsync(T entity, int? commandTimeout = null) => await _base.UpdateAsync<T>(entity, commandTimeout: commandTimeout);

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// <para>Insert a new record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        public int? Insert(T entity, int? commandTimeout = null) => _base.Insert<T>(entity, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Insert a new record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        public async Task<int?> InsertAsync(T entity, int? commandTimeout = null) => await _base.InsertAsync<T>(entity, commandTimeout: commandTimeout);

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// <para>Delete a record by primary key (id)..</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public int Delete(int id, int? commandTimeout = null) => _base.Delete<T>(id, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Delete a record by primary key (id)..</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public async Task<int> DeleteAsync(int id, int? commandTimeout = null) => await _base.DeleteAsync<T>(id, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Delete all records that match the specified filter.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the WHERE clause.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public int Delete(string where, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.Delete<T>(where, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Delete all records that match the specified filter.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the WHERE clause.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        public async Task<int> DeleteAsync(string where, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.DeleteAsync<T>(where, parms, commandTimeout: commandTimeout);

        // ----------- EXECUTE QUERY Methods ----------- //

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public void ExecuteQuery(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.ExecuteQuery<T>(query, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public async Task ExecuteQueryAsync(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.ExecuteQueryAsync<T>(query, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public T ExecuteScalar(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.ExecuteScalar<T>(query, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        public async Task<T> ExecuteScalarAsync(string query, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.ExecuteScalarAsync<T>(query, parms, commandTimeout: commandTimeout);

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public void ExecuteSP(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.ExecuteSP(storedProcedureName, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        public async Task ExecuteSPAsync(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.ExecuteSPAsync(storedProcedureName, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T.</returns>
        public T ExecuteSPSingle(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.ExecuteSPSingle<T>(storedProcedureName, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T.</returns>
        public async Task<T> ExecuteSPSingleAsync(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.ExecuteSPSingleAsync<T>(storedProcedureName, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T.</returns>
        public IEnumerable<T> ExecuteSPList(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null) => _base.ExecuteSPList<T>(storedProcedureName, parms, commandTimeout: commandTimeout);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T.</returns>
        public async Task<IEnumerable<T>> ExecuteSPListAsync(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null) => await _base.ExecuteSPListAsync<T>(storedProcedureName, parms, commandTimeout: commandTimeout);
    }
}
