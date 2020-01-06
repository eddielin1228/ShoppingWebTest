﻿using BusinessLogic.Infrastructure;
using BusinessLogic.Interface;
using DataAccess.SampleDataBase;
using DataAccess.ShoppingWebDataBase;
using Repository;
using System;

namespace BusinessLogic.Base
{
    /// <summary>
    /// 該資料庫所有資料表存取位置(範例)
    /// </summary>
    public class SampleDataBase : IDisposable
    {
        /// <summary>
        /// log
        /// </summary>
        protected ILog Log = new Log();

        /// <summary>
        /// Repository SampleAccountViewModel Sample
        /// </summary>
        protected IRepository<AspNetUsers> SampleAccountRepository { get; set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only                
            }

            // release any unmanaged objects
            // set the object references to null
            _disposed = true;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;
    }
}
