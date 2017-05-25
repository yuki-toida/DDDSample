using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sample.Infra.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// PK取得
        /// </summary>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// Where取得
        /// </summary>
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// All取得
        /// </summary>
        IEnumerable<TEntity> FindAll();

        /// <summary>
        /// 追加
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// 削除
        /// </summary>
        void Remove(TEntity entity);
    }
}
