using Sample.Domain.Model.User.Entity;
using Sample.Infra.Interface.Data.Transaction;
using Sample.Infra.Interface.Repository;

namespace Sample.Domain.Model.Tutorial.Service
{
    public static class TutorialInitializer
    {
        public static UserBase Initialize(IRepositories repositories, int uid)
        {
            return InitializeUser(repositories, uid);
        }

        private static UserBase InitializeUser(IRepositories repositories, int uid)
        {
            var tran = new UserTranBase()
            {
                Uid = uid,
                Name = "Hoge",
            };

            repositories.UserTranBase.Add(tran);

            return new UserBase(tran);
        }
    }
}
