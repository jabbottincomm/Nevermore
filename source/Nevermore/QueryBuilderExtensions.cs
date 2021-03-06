using Nevermore.AST;

namespace Nevermore
{
    public static class QueryBuilderExtensions
    {
        /// <summary>
        /// Converts a normal query into a create stored procedure query.
        /// </summary>
        /// <typeparam name="TRecord">The record type of the query builder</typeparam>
        /// <param name="queryBuilder">The query builder</param>
        /// <param name="storedProcedureName">The name of the stored procedure</param>
        /// <returns>A plain SQL string representing a create stored procedure query</returns>
        public static string AsStoredProcedure<TRecord>(this IQueryBuilder<TRecord> queryBuilder, string storedProcedureName) where TRecord : class
        {
            return new StoredProcedure(queryBuilder.GetSelectBuilder().GenerateSelect(), queryBuilder.Parameters, queryBuilder.ParameterDefaults, storedProcedureName).GenerateSql();
        }

        /// <summary>
        /// Converts a normal query into a create view query.
        /// </summary>
        /// <typeparam name="TRecord">The record type of the query builder</typeparam>
        /// <param name="queryBuilder">The query builder</param>
        /// <param name="viewName">The name of the view</param>
        /// <returns>A plain SQL string representing a create view query</returns>
        public static string AsView<TRecord>(this IQueryBuilder<TRecord> queryBuilder, string viewName) where TRecord : class
        {
            return new View(queryBuilder.GetSelectBuilder().GenerateSelect(), viewName).GenerateSql();
        }

        /// <summary>
        /// Converts a normal query into a create function query.
        /// </summary>
        /// <typeparam name="TRecord">The record type of the query builder</typeparam>
        /// <param name="queryBuilder">The query builder</param>
        /// <param name="functionName">The name of the function</param>
        /// <returns>A plain SQL string representing a create function query</returns>
        public static string AsFunction<TRecord>(this IQueryBuilder<TRecord> queryBuilder, string functionName) where TRecord : class
        {
            return new Function(queryBuilder.GetSelectBuilder().GenerateSelect(), queryBuilder.Parameters, queryBuilder.ParameterDefaults, functionName).GenerateSql();
        }
    }
}