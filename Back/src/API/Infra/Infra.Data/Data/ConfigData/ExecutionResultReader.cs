using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Infra.Data.ConfigData
{
    public class ExecutionResultReader
    {
        public DbParameter[] Parameters { get; protected set; }
        public DbDataReader Reader { get; protected set; }

        internal ExecutionResultReader(DbDataReader reader)
            : this(reader, null)
        { }

        internal ExecutionResultReader(DbDataReader reader, params DbParameter[] parameters)
        {
            Reader = reader;
            Parameters = parameters;
        }
    }
}