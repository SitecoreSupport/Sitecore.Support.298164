using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.EDS.Providers.SparkPost.Data;
using Sitecore.EDS.Providers.SparkPost.Exceptions;

namespace Sitecore.Support.EDS.Providers.SparkPost.Data
{
    public sealed class DataContextFactory: Sitecore.EDS.Providers.SparkPost.Data.IDataContextFactory
    {
        public IDataContext<TEntity> CreateDataContext<TEntity>(string connectionString) where TEntity : class
        {
            Assert.ArgumentNotNullOrEmpty(connectionString, "connectionString");
            try
            {
                return CreateLinqDataContext<TEntity>(connectionString);
            }
            catch (Exception innerException)
            {
                throw new DataException("Unable to perform data operation.", innerException);
            }
        }

        internal  LinqDataContext<TEntity> CreateLinqDataContext<TEntity>(string connectionString) where TEntity : class
        {
            return new Sitecore.Support.EDS.Providers.SparkPost.Data.LinqDataContext<TEntity>(connectionString);
        }
    }
}