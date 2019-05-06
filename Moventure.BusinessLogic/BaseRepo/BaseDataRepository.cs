using System;
using Moventure.DataLayer.Models;

namespace UpWorky.DataLayer.Repositories
{
    public abstract class BaseDataRepository : IDisposable
    {
        private const string CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE = "Tried to use repository with null context";
        private Entities mContext;

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

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}