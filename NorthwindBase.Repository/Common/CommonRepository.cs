using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NorthwindBase.Utility;

namespace NorthwindBase.Repository.Common
{
    /// <summary>
    /// 共用存取
    /// </summary>
    public class CommonRepository<TEntity> : ICommonRepository<TEntity>
        where TEntity : class
    {
        private bool _disposed;
        private DbContext _dbContext { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 建構子 Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public CommonRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 新增一筆資料到資料庫。
        /// </summary>
        /// <param name="entity">要新增到資料的庫的Entity</param>
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的Entity。</param>
        public void Delete(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// 儲存異動
        /// </summary>
        public void SaveChanges()
        {
            _dbContext.Database.Log = (log) => logger.Info(log);
            _dbContext.SaveChanges();

            // 因為Update 單一model需要先關掉validation，因此重新打開
            if (_dbContext.Configuration.ValidateOnSaveEnabled == false)
            {
                _dbContext.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        /// <summary>
        /// 更新一筆Entity內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        public void Edit(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
