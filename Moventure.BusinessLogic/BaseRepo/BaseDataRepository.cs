using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moventure.DataLayer.Context;
using Moventure.DataLayer.Models;

namespace UpWorky.DataLayer.Repositories
{
    public abstract class BaseDataRepository : IDisposable
    {
        #region private fields

        private const string CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE = "Tried to use repository with null context";
        private Entities mContext;

        #endregion
        
        public static IServiceProvider serviceProvider;

        public abstract bool IsEntityTrackingOn { get; set; }

        public virtual Entities Context
        {
            get { return mContext; }
            set
            {
                if (value == null)
                {
                    //TODO: FIX
                    //LogHelper.LogException<BaseDataRepository>(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                    throw new NullReferenceException(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                }

                mContext = value;
            }
        }


        //public IEnumerable<T> ExecuteStoredProcedureList<T>(object storedProcedure)
        //{
        //    return mContext.Query.ExecuteStoredProcedureList(storedProcedure);
        //}

        //public void ExecuteStoredProcedure(object storedProcedure)
        //{
        //    mContext.Query.ExecuteStoredProcedure(storedProcedure);
        //}

        #region Raw SQL
        //public int ExecuteSqlCommand(string sql, params object[] p)
        //{
        //    return mContext.Query<object>.ExecuteSqlCommand(sql, p);
        //}

        //public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] p)
        //{
        //    //return await mContext.Database.ExecuteSqlCommandAsync(sql, p).ConfigureAwait(false);
        //    return await mContext.Database.ExecuteSqlCommandAsync(sql, p).ConfigureAwait(false);
        //}


        #endregion

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}