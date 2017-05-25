using System;
using System.Linq;
using Sample.Domain.Model.Item.Entity;
using Sample.Domain.Shared.Gift;
using Sample.Infra.Core.DateTime;
using Sample.Infra.Interface.Data.Transaction;
using Sample.Infra.Interface.Repository;

namespace Sample.Domain.Model.User.Entity
{
    public class UserBase
    {
        public UserBase(UserTranBase userTran)
        {
            _tran = userTran;
        }

        private readonly UserTranBase _tran;

        public int Uid => _tran.Uid;

        /// <summary>
        /// ギフトを受け取る
        /// </summary>
        public void ReceiveGift(
            IRepositories repositories
            , ItemContainer itemContainer
            , DateTimeOffset? limitDate
            , GiftEnum.AddReason reason
            , params object[] customWords
            )
        {
            var word = string.Empty;

            if (customWords.Any())
                word = string.Format(word, customWords);

            repositories.GiftTranUnopen.Add(new GiftTranUnopen()
            {
                Uid = Uid,
                AddDate = DateTimeManager.Now,
                AddReason = (int)reason,
                LimitDate = limitDate,
                ItemCategory = (int)itemContainer.Item.Category,
                ItemId = itemContainer.Item.Id,
                ItemNum = itemContainer.Num,
                Word = word,
            });
        }
    }
}
