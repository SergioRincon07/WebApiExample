﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Data
{
    public partial class TestDataBaseContext
    {
        private ITestDataBaseContextProcedures _procedures;

        public virtual ITestDataBaseContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new TestDataBaseContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ITestDataBaseContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpGetUsuariosResult>().HasNoKey().ToView(null);
        }
    }

    public partial class TestDataBaseContextProcedures : ITestDataBaseContextProcedures
    {
        private readonly TestDataBaseContext _context;

        public TestDataBaseContextProcedures(TestDataBaseContext context)
        {
            _context = context;
        }

        public virtual async Task<List<SpGetUsuariosResult>> SpGetUsuariosAsync(string IdUsuario, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "IdUsuario",
                    Size = 20,
                    Value = IdUsuario ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SpGetUsuariosResult>("EXEC @returnValue = [dbo].[SpGetUsuarios] @IdUsuario", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
