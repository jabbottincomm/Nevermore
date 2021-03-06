using System;
using System.Data;
using Nevermore.Mapping;

namespace Nevermore
{
    public interface ISqlCommandFactory
    {
        IDbCommand CreateCommand(IDbConnection connection, IDbTransaction transaction, string statement, CommandParameterValues args, DocumentMap mapping = null, int? commandTimeoutSeconds = null);
    }
}