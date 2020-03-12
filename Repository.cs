using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.SimpleRepository
{
    public class Repository<T>
    {
        private readonly Repository _base;

        public Repository(string connectionString)
        {
            _base = new Repository(connectionString);
        }

        // ----------- GET Single Item Methods ----------- //

        /// <summary>
        /// Get a specific record from any table by the primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id) => _base.Get<T>(id);

        /// <summary>
        /// Get a specific record from any table by the primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(int id) => await _base.GetAsync<T>(id);

        /// <summary>
        /// Get a specific record from any table that matches the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T Get(string where, Dictionary<string, object> parms = null) => _base.Get<T>(where, parms);

        /// <summary>
        /// Get a specific record from any table that matches the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(string where, Dictionary<string, object> parms = null) => await _base.GetAsync<T>(where, parms);

        /// <summary>
        /// Get a specific type from any query.  This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T GetFromQuery(string query, Dictionary<string, object> parms = null) => _base.GetFromQuery<T>(query, parms);

        /// <summary>
        /// Get a specific type from any query.  This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> GetFromQueryAsync(string query, Dictionary<string, object> parms = null) => await _base.GetFromQueryAsync<T>(query, parms);

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// Get an IEnumerable of all records of any database table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll() => _base.GetAll<T>();

        /// <summary>
        /// Get an IEnumerable of all records of any database table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync() => await _base.GetAllAsync<T>();

        /// <summary>
        /// Get an IEnumerable from any table that matches the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(string where, Dictionary<string, object> parms = null) => _base.GetList<T>(where, parms);

        /// <summary>
        /// Get an IEnumerable from any table that matches the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync(string where, Dictionary<string, object> parms = null) => await _base.GetListAsync<T>(where, parms);

        /// <summary>
        /// Get an IEnumerable from any table based on a custom query and any (optional) parms
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IEnumerable<T> GetListFromQuery(string query, Dictionary<string, object> parms = null) => _base.GetListFromQuery<T>(query, parms);

        /// <summary>
        /// Get an IEnumerable from any table based on a custom query and any (optional) parms
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListFromQueryAsync(string query, Dictionary<string, object> parms = null) => await _base.GetListFromQueryAsync<T>(query, parms);

        /// <summary>
        /// Get a paged IEnumerable of all records of any database table
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderBy, Dictionary<string, object> parms = null) => _base.GetListPaged<T>(pageNumber, rowsPerPage, conditions, orderBy, parms);

        /// <summary>
        /// Get a paged IEnumerable of all records of any database table
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowsPerPage, string conditions, string orderBy, Dictionary<string, object> parms = null) => await _base.GetListPagedAsync<T>(pageNumber, rowsPerPage, conditions, orderBy, parms);

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// Update as existing record in any database table, matching by Id of the record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity) => _base.Update<T>(entity);

        /// <summary>
        /// Update as existing record in any database table, matching by Id of the record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(T entity) => await _base.UpdateAsync<T>(entity);

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// Insert a new record into any database table. Retuns the Id of the newly created record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int? Insert(T entity) => _base.Insert<T>(entity);

        /// <summary>
        /// Insert a new record into any database table. Retuns the Id of the newly created record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(T entity) => await _base.InsertAsync<T>(entity);

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// Delete a record by primary key from any database table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id) => _base.Delete<T>(id);

        /// <summary>
        /// Delete a record by primary key from any database table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int id) => await _base.DeleteAsync<T>(id);

        /// <summary>
        /// Delete all records from any table that match the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int Delete(string where, Dictionary<string, object> parms = null) => _base.Delete<T>(where, parms);

        /// <summary>
        /// Delete all records from any table that match the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string where, Dictionary<string, object> parms = null) => await _base.DeleteAsync<T>(where, parms);

        // ----------- EXECUTE QUERY Methods ----------- //

        /// <summary>
        /// Execute any custom query where a return data set it not expected.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        public void ExecuteQuery(string query, Dictionary<string, object> parms = null) => _base.ExecuteQuery<T>(query, parms);

        /// <summary>
        /// Execute any custom query where a return data set it not expected.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task ExecuteQueryAsync(string query, Dictionary<string, object> parms = null) => await _base.ExecuteQueryAsync<T>(query, parms);

        /// <summary>
        /// Execute any custom query where a single return item is expected. This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T ExecuteScalar(string query, Dictionary<string, object> parms = null) => _base.ExecuteScalar<T>(query, parms);

        /// <summary>
        /// Execute any custom query where a single return item is expected. This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> ExecuteScalarAsync(string query, Dictionary<string, object> parms = null) => await _base.ExecuteScalarAsync<T>(query, parms);

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// Execute any Stored Procedure where a return data set it not expected.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        public void ExecuteSP(string storedProcedureName, Dictionary<string, object> parms = null) => _base.ExecuteSP<T>(storedProcedureName, parms);

        /// <summary>
        /// Execute any Stored Procedure where a return data set it not expected.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task ExecuteSPAsync(string storedProcedureName, Dictionary<string, object> parms = null) => await _base.ExecuteSPAsync<T>(storedProcedureName, parms);

        /// <summary>
        /// Execute any Stored Procedure where a single item is expected as a return.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T ExecuteSPSingle(string storedProcedureName, Dictionary<string, object> parms = null) => _base.ExecuteSPSingle<T>(storedProcedureName, parms);

        /// <summary>
        /// Execute any Stored Procedure where a single item is expected as a return.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> ExecuteSPSingleAsync(string storedProcedureName, Dictionary<string, object> parms = null) => await _base.ExecuteSPSingleAsync<T>(storedProcedureName, parms);

        /// <summary>
        /// Execute a Store Procedure when a List of T is expected in return.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IEnumerable<T> ExecuteSPList(string storedProcedureName, Dictionary<string, object> parms = null) => _base.ExecuteSPList<T>(storedProcedureName, parms);

        /// <summary>
        /// Execute a Store Procedure when a List of T is expected in return.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ExecuteSPListAsync(string storedProcedureName, Dictionary<string, object> parms = null) => await _base.ExecuteSPListAsync<T>(storedProcedureName, parms);
    }


    public class Repository
    {
        private readonly string _connectionString;

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
        /// Get a specific record from any table by the primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get<T>(int id)
        {
            T entity;
            using (var connection = OpenConnection(_connectionString))
            {
                entity = connection.Get<T>(id);
            }
            return entity;
        }

        /// <summary>
        /// Get a specific record from any table by the primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(int id)
        {
            T entity;
            using (var connection = OpenConnection(_connectionString))
            {
                entity = await connection.GetAsync<T>(id);
            }
            return entity;
        }

        /// <summary>
        /// Get a specific record from any table that matches the specified filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T Get<T>(string where, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = connection.GetList<T>(where, new DynamicParameters(parms));
                else
                    entities = connection.GetList<T>(where);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// Get a specific record from any table that matches the specified filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string where, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = await connection.GetListAsync<T>(where, new DynamicParameters(parms));
                else
                    entities = await connection.GetListAsync<T>(where);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// Get a specific type from any query.  This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetFromQuery<T>(string query, Dictionary<string, object> parms = null)
        {
            T entity;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entity = connection.Query<T>(query, new DynamicParameters(parms)).FirstOrDefault();
                else
                    entity = connection.Query<T>(query).FirstOrDefault();
            }
            return entity;
        }

        /// <summary>
        /// Get a specific type from any query.  This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetFromQueryAsync<T>(string query, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entity;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                {
                    entity = await connection.QueryAsync<T>(query, new DynamicParameters(parms));
                }
                else
                {
                    entity = await connection.QueryAsync<T>(query);
                }
            }
            return entity.FirstOrDefault();
        }

        // ----------- GET List Methods ----------- //

        /// <summary>
        /// Get an IEnumerable of all records of any database table
        /// </summary>
        /// <returns></returns>
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
        /// Get an IEnumerable of all records of any database table
        /// </summary>
        /// <returns></returns>
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
        /// Get an IEnumerable from any table that matches the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(string where, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = connection.GetList<T>(where, new DynamicParameters(parms));
                else
                    entities = connection.GetList<T>(where);
            }
            return entities;
        }

        /// <summary>
        /// Get an IEnumerable from any table that matches the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync<T>(string where, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = await connection.GetListAsync<T>(where, new DynamicParameters(parms));
                else
                    entities = await connection.GetListAsync<T>(where);
            }
            return entities;
        }

        /// <summary>
        /// Get an IEnumerable from any table based on a custom query and any (optional) parms
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public IEnumerable<T> GetListFromQuery<T>(string query, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = connection.Query<T>(query, new DynamicParameters(parms));
                else
                    entities = connection.Query<T>(query);
            }
            return entities;
        }

        /// <summary>
        /// Get an IEnumerable from any table based on a custom query and any (optional) parms
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListFromQueryAsync<T>(string query, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                if (parms != null)
                    entities = await connection.QueryAsync<T>(query, new DynamicParameters(parms));
                else
                    entities = await connection.QueryAsync<T>(query);
            }
            return entities;
        }

        /// <summary>
        /// Get a paged IEnumerable of all records of any database table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IEnumerable<T> GetListPaged<T>(int pageNumber, int rowsPerPage, string conditions, string orderBy, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = connection.GetListPaged<T>(pageNumber, rowsPerPage, conditions, orderBy, parms);
            }
            return entities;
        }

        /// <summary>
        /// Get a paged IEnumerable of all records of any database table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListPagedAsync<T>(int pageNumber, int rowsPerPage, string conditions, string orderBy, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = await connection.GetListPagedAsync<T>(pageNumber, rowsPerPage, conditions, orderBy, parms);
            }
            return entities;
        }

        // ----------- UPDATE Methods ----------- //

        /// <summary>
        /// Update as existing record in any database table, matching by Id of the record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<T>(T entity)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }

        /// <summary>
        /// Update any existing record in any database table. Returns number of rows affected.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync<T>(T entity)
        {
            int records;
            using (var connection = OpenConnection(_connectionString))
            {
                records = await connection.UpdateAsync(entity);
            }
            return records;
        }

        // ----------- INSERT Methods ----------- //

        /// <summary>
        /// Insert a new record into any database table. Retuns the Id of the newly created record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int? Insert<T>(T entity)
        {
            int? newId;
            using (var connection = OpenConnection(_connectionString))
            {
                newId = connection.Insert<T>(entity);
            }
            return newId;
        }

        /// <summary>
        /// Insert a new record into any database table. Retuns the Id of the newly created record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync<T>(T entity)
        {
            int? newId;
            using (var connection = OpenConnection(_connectionString))
            {
                newId = await connection.InsertAsync<T>(entity);
            }
            return newId;
        }

        // ----------- DELETE Methods ----------- //

        /// <summary>
        /// Delete a record by primary key from any database table
        /// </summary>
        /// <param name="id"></param>
        public int Delete<T>(int id)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.Delete<T>(id);
            }
        }

        /// <summary>
        /// Delete a record by primary key from any database table
        /// </summary>
        /// <param name="id"></param>
        public async Task<int> DeleteAsync<T>(int id)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return await connection.DeleteAsync<T>(id);
            }
        }

        /// <summary>
        /// Delete all records from any table that match the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        public int Delete<T>(string where, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.DeleteList<T>(where, new DynamicParameters(parms));
            }
        }

        /// <summary>
        /// Delete all records from any table that match the specified filter
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parms"></param>
        public async Task<int> DeleteAsync<T>(string where, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return await connection.DeleteListAsync<T>(where, new DynamicParameters(parms));
            }
        }

        // ----------- EXECUTE QUERY Method ----------- //

        /// <summary>
        /// Execute any custom query where a return data set it not expected.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        public void ExecuteQuery<T>(string query, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                connection.Execute(query, param: parms, commandType: CommandType.Text);
            }
        }

        /// <summary>
        /// Execute any custom query where a return data set it not expected.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        public async Task ExecuteQueryAsync<T>(string query, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, param: parms, commandType: CommandType.Text);
            }
        }

        /// <summary>
        /// Execute any custom query where a single return item is expected. This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(string query, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return connection.ExecuteScalar<T>(query, param: parms, commandType: CommandType.Text);
            }
        }

        /// <summary>
        /// Execute any custom query where a single return item is expected. This type could be a database model (list<T>), or it could be a single string, or it could be an INT if the query is a SELECT COUNT().
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> ExecuteScalarAsync<T>(string query, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                return await connection.ExecuteScalarAsync<T>(query, param: parms, commandType: CommandType.Text);
            }
        }

        // ----------- STORED PROCEDURE Methods ----------- //

        /// <summary>
        /// Execute any Stored Procedure where a return data set it not expected.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        public void ExecuteSP<T>(string storedProcedureName, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                connection.Execute(storedProcedureName, parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Execute any Stored Procedure where a return data set it not expected.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        public async Task ExecuteSPAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                await connection.ExecuteAsync(storedProcedureName, parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Execute any Stored Procedure where a single item is expected as a return.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T ExecuteSPSingle<T>(string storedProcedureName, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = connection.Query<T>(storedProcedureName, parms, commandType: CommandType.StoredProcedure);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// Execute any Stored Procedure where a single item is expected as a return.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public async Task<T> ExecuteSPSingleAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null)
        {
            IEnumerable<T> entities;
            using (var connection = OpenConnection(_connectionString))
            {
                entities = await connection.QueryAsync<T>(storedProcedureName, parms, commandType: CommandType.StoredProcedure);
            }
            if (entities != null && entities.Any())
                return entities.FirstOrDefault();
            else
                return default;
        }

        /// <summary>
        /// Execute a Store Procedure when a List of T is expected in return.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="param"></param>
        /// <returns>Returns a List of T</returns>
        public IEnumerable<T> ExecuteSPList<T>(string storedProcedureName, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                IEnumerable<T> output = connection.Query<T>(storedProcedureName, param: parms, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                return output;
            }
        }

        /// <summary>
        /// Execute a Store Procedure when a List of T is expected in return.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="param"></param>
        /// <returns>Returns a List of T</returns>
        public async Task<IEnumerable<T>> ExecuteSPListAsync<T>(string storedProcedureName, Dictionary<string, object> parms = null)
        {
            using (var connection = OpenConnection(_connectionString))
            {
                var output = await connection.QueryAsync<T>(storedProcedureName, param: parms, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                return output;
            }
        }
    }


}
