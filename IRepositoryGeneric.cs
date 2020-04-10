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
        /// <para>Get a specific record from any table by the primary key.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single record of type T where the primary key matches the supplied Id.</returns>
        T Get<T>(int id);

        /// <summary>
        /// <para>Get a specific record from any table by the primary key.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single record of type T where the primary key matches the supplied Id.</returns>
        Task<T> GetAsync<T>(int id);

        /// <summary>
        /// <para>Get a specific record from any table that matches the specified filter.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        T Get<T>(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a specific record from any table that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        Task<T> GetAsync<T>(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a specific type from any query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        T GetFromQuery<T>(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a specific type from any query.  This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        Task<T> GetFromQueryAsync<T>(string query, Dictionary<string, object> parms = null);

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// <para>Get an IEnumerable of all records of any database table</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        IEnumerable<T> GetAll<T>();

        /// <summary>
        /// <para>Get an IEnumerable of all records of any database table</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <returns>An IEnumerable of type T.</returns>
        Task<IEnumerable<T>> GetAllAsync<T>();

        /// <summary>
        /// <para>Get an IEnumerable from any table that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        IEnumerable<T> GetList<T>(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get an IEnumerable from any table that matches the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        Task<IEnumerable<T>> GetListAsync<T>(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get an IEnumerable from any table based on a custom query and any (optional) parms</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        IEnumerable<T> GetListFromQuery<T>(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get an IEnumerable from any table based on a custom query and any (optional) parms</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        Task<IEnumerable<T>> GetListFromQueryAsync<T>(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a paged IEnumerable of all records of any database table.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        IEnumerable<T> GetListPaged<T>(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a paged IEnumerable of all records of any database table.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        Task<IEnumerable<T>> GetListPagedAsync<T>(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null);

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// <para>Update as existing record in any database table, matching by Id of the record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>Number of rows affected.</returns>
        int Update<T>(T entity);

        /// <summary>
        /// <para>Update any existing record in any database table. Returns number of rows affected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> UpdateAsync<T>(T entity);

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// <para>Insert a new record into any database table. Retuns the Id of the newly created record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        int? Insert<T>(T entity);

        /// <summary>
        /// <para>Insert a new record into any database table. Retuns the Id of the newly created record.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        Task<int?> InsertAsync<T>(T entity);

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// <para>Delete a record by primary key from any database table</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <returns>Number of rows affected.</returns>
        int Delete<T>(int id);

        /// <summary>
        /// <para>Delete a record by primary key from any database table</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> DeleteAsync<T>(int id);

        /// <summary>
        /// <para>Delete all records from any table that match the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameteres that matches the WHERE clause.</param>
        /// <returns>Number of rows affected.</returns>
        int Delete<T>(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Delete all records from any table that match the specified filter</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameteres that matches the WHERE clause.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> DeleteAsync<T>(string where, Dictionary<string, object> parms = null);

        // ----------- EXECUTE QUERY Method ----------- //

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        void ExecuteQuery<T>(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        Task ExecuteQueryAsync<T>(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        T ExecuteScalar<T>(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        Task<T> ExecuteScalarAsync<T>(string query, Dictionary<string, object> parms = null);

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        void ExecuteSP<T>(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        Task ExecuteSPAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T.</returns>
        T ExecuteSPSingle<T>(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T.</returns>
        Task<T> ExecuteSPSingleAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T.</returns>
        IEnumerable<T> ExecuteSPList<T>(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// <para>Queries the table matching the type T.</para>
        /// </summary>
        /// <typeparam name="T">The Type that matches the database table.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T.</returns>
        Task<IEnumerable<T>> ExecuteSPListAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null);
    }
}