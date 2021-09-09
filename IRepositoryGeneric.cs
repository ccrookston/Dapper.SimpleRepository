using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.SimpleRepository
{
    /// <summary>
    /// Create a generic (weakly) typed instance of Dapper.SimpleRepository.
    /// </summary>
    public interface IRepositoryGeneric
    {
        /// <summary>
        /// <para>Get a specific record by the primary key (id).</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the primary key matches the supplied id.</returns>
        T Get<T>(object id, int? commandTimeout = null);

        /// <summary>
        /// <para>Get a specific record by the primary key (id).</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the primary key matches the supplied id.</returns>
        Task<T> GetAsync<T>(object id, int? commandTimeout = null);

        /// <summary>
        /// <para>Get a specific record that matches the specified filter.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        T Get<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Get a specific record that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        Task<T> GetAsync<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Get a specific type from a query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        T GetFromQuery<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Get a specific type from a query.  This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        Task<T> GetFromQueryAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// <para>Get an IEnumerable of all records.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        IEnumerable<T> GetAll<T>();

        /// <summary>
        /// <para>Get an IEnumerable of all records.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <returns>An IEnumerable of type T.</returns>
        Task<IEnumerable<T>> GetAllAsync<T>();

        /// <summary>
        /// <para>Get an IEnumerable that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        IEnumerable<T> GetList<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Get an IEnumerable that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="where">The SQL WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        Task<IEnumerable<T>> GetListAsync<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Get an IEnumerable based on a custom query and any (optional) parameters</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        IEnumerable<T> GetListFromQuery<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Get an IEnumerable based on a custom query and any (optional) parameters</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        Task<IEnumerable<T>> GetListFromQueryAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

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
        IEnumerable<T> GetListPaged<T>(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null, int? commandTimeout = null);

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
        Task<IEnumerable<T>> GetListPagedAsync<T>(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null, int? commandTimeout = null);

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// <para>Update an existing record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        int Update<T>(T entity, int? commandTimeout = null);

        /// <summary>
        /// <para>Update an existing record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> UpdateAsync<T>(T entity, int? commandTimeout = null);

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// <para>Insert a new record.</para>
        /// <para>Inserts into the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        int? Insert<T>(T entity, int? commandTimeout = null);

        /// <summary>
        /// <para>Insert a new record.</para>
        /// <para>Inserts into the table matching the type T.</para>
        /// <para>Allows the PK Type to be defined.</para>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        TKey Insert<TKey, T>(T entity, int? commandTimeout = null);

        /// <summary>
        /// <para>Insert a new record.</para>
        /// <para>Inserts into the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        Task<int?> InsertAsync<T>(T entity, int? commandTimeout = null);

        /// <summary>
        /// <para>Insert a new record.</para>
        /// <para>Inserts into the table matching the type T.</para>
        /// <para>Allows the PK Type to be defined.</para>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<TKey> InsertAsync<TKey, T>(T entity, int? commandTimeout = null);

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// <para>Delete a record by primary key (id).</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        int Delete<T>(object id, int? commandTimeout = null);

        /// <summary>
        /// <para>Delete a record by primary key (id).</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> DeleteAsync<T>(object id, int? commandTimeout = null);

        /// <summary>
        /// <para>Delete all records that match the specified filter.</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the WHERE clause.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        int Delete<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Delete all records that match the specified filter.</para>
        /// <para>Deletes from the table matching the type T.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameters that matches the WHERE clause.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> DeleteAsync<T>(string where, Dictionary<string, object> parms = null, int? commandTimeout = null);

        // ----------- EXECUTE QUERY Method ----------- //

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        void ExecuteQuery<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        Task ExecuteQueryAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        T ExecuteScalar<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        Task<T> ExecuteScalarAsync<T>(string query, Dictionary<string, object> parms = null, int? commandTimeout = null);

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        void ExecuteSP(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        Task ExecuteSPAsync(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T.</returns>
        T ExecuteSPSingle<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>A single instance of type T.</returns>
        Task<T> ExecuteSPSingleAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T.</returns>
        IEnumerable<T> ExecuteSPList<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <typeparam name="T">The type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameters that matches the query.</param>
        /// <param name="commandTimeout">Optional command time out value.</param>
        /// <returns>An IEnumerable of type T.</returns>
        Task<IEnumerable<T>> ExecuteSPListAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null, int? commandTimeout = null);
    }
}