using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.SimpleRepository
{
    /// <summary>
    /// Create a strongly typed instance of Dapper.SimpleRepository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryStrong<T>
    {
        /// <summary>
        /// <para>Get a specific record from any table by the primary key.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single record of type T where the primary key matches the supplied Id.</returns>
        T Get(int id);

        /// <summary>
        /// <para>Get a specific record from any table by the primary key.</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single record of type T where the primary key matches the supplied Id.</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// <para>Get a specific record from any table that matches the specified filter.</para>
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        T Get(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a specific record from any table that matches the specified filter.</para>
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single record of type T where the data matches the supplied WHERE filter.</returns>
        Task<T> GetAsync(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a specific type from any query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        T GetFromQuery(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a specific type from any query. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        Task<T> GetFromQueryAsync(string query, Dictionary<string, object> parms = null);

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// <para>Get an IEnumerable of all records of any database table</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// <para>Get an IEnumerable of all records of any database table</para>
        /// </summary>
        /// <returns>an IEnumerable of type T.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// <para>Get an IEnumerable from any table that matches the specified filter</para>
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        IEnumerable<T> GetList(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get an IEnumerable from any table that matches the specified filter</para>
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T where the data matches the supplied WHERE filter.</returns>
        Task<IEnumerable<T>> GetListAsync(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get an IEnumerable from any table based on a custom query and any (optional) parms</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        IEnumerable<T> GetListFromQuery(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get an IEnumerable from any table based on a custom query and any (optional) parms</para>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T that matches the supplied query.</returns>
        Task<IEnumerable<T>> GetListFromQueryAsync(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a paged IEnumerable of all records of any database table.</para>
        /// </summary>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Get a paged IEnumerable of all records of any database table.</para>
        /// </summary>
        /// <param name="pageNumber">The offset (or page number) of the total set to select.</param>
        /// <param name="rowsPerPage">The number of total records to return per page.</param>
        /// <param name="where">Optional WHERE clause to filter the resutls.</param>
        /// <param name="orderBy">Optional ORDER BY clause to order the results.</param>
        /// <param name="parms">Optinal set of paramaters used in WHERE or ORDER BY clauses.</param>
        /// <returns>A paged IEnumerable of type T.</returns>
        Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowsPerPage, string where, string orderBy, Dictionary<string, object> parms = null);

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// <para>Update as existing record in any database table, matching by Id of the record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>Number of rows affected.</returns>
        int Update(T entity);

        /// <summary>
        /// <para>Update as existing record in any database table, matching by Id of the record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> UpdateAsync(T entity);

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// <para>Insert a new record into any database table. Retuns the Id of the newly created record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        int? Insert(T entity);

        /// <summary>
        /// <para>Insert a new record into any database table. Retuns the Id of the newly created record.</para>
        /// </summary>
        /// <param name="entity">An instance of type T to be updated.</param>
        /// <returns>The ID (primary key) of the newly inserted record.</returns>
        Task<int?> InsertAsync(T entity);

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// <para>Delete a record by primary key from any database table.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <returns>Number of rows affected.</returns>
        int Delete(int id);

        /// <summary>
        /// <para>Delete a record by primary key from any database table.</para>
        /// </summary>
        /// <param name="id">The ID (primary key) of the item to be deleted.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// <para>Delete all records from any table that match the specified filter.</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameteres that matches the WHERE clause.</param>
        /// <returns>Number of rows affected.</returns>
        int Delete(string where, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Delete all records from any table that match the specified filter</para>
        /// </summary>
        /// <param name="where">Optional WHERE clause.</param>
        /// <param name="parms">Optional set of parameteres that matches the WHERE clause.</param>
        /// <returns>Number of rows affected.</returns>
        Task<int> DeleteAsync(string where, Dictionary<string, object> parms = null);

        // ----------- EXECUTE QUERY Methods ----------- //

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        void ExecuteQuery(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any custom query where a return data set it not expected.</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        Task ExecuteQueryAsync(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        T ExecuteScalar(string query, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any custom query where a single return item is expected. This type could be a database model, or it could be a single string, or it could be an INT if the query is a SELECT COUNT().</para>
        /// </summary>
        /// <param name="query">Full SQL query.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T that matches the supplied query.</returns>
        Task<T> ExecuteScalarAsync(string query, Dictionary<string, object> parms = null);

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        void ExecuteSP(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a return data set it not expected.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        Task ExecuteSPAsync(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T.</returns>
        T ExecuteSPSingle(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute any Stored Procedure where a single item is expected as a return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>A single instance of type T.</returns>
        Task<T> ExecuteSPSingleAsync(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T.</returns>
        IEnumerable<T> ExecuteSPList(string storedProcedureName, Dictionary<string, object> parms = null);

        /// <summary>
        /// <para>Execute a Store Procedure when a List of T is expected in return.</para>
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed.</param>
        /// <param name="parms">Optional set of parameteres that matches the query.</param>
        /// <returns>An IEnumerable of type T.</returns>
        Task<IEnumerable<T>> ExecuteSPListAsync(string storedProcedureName, Dictionary<string, object> parms = null);
    }
}