using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.EDS.Providers.SparkPost.Data
{
    public class LinqDataContext<TEntity>: Sitecore.EDS.Providers.SparkPost.Data.LinqDataContext<TEntity> where TEntity : class
    {
        public LinqDataContext(string connectionString) : base(connectionString)
        {
            DataContext.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
        }
    }
}