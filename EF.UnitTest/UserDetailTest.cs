using EntityDataAccess.Core;
using EntityObjects.Objects;
using System;
using System.Data.Entity;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EF.UnitTest
{
    class UserDetailTest
    {
        [TestMethod]
        public void UserInfoTest()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EFDbContext>());

            using (var context = new EFDbContext())
            {
                context.Database.Create();
                UserDetail userdetail = new UserDetail
                {
                    user_name = "Indr@ni",
                    first_name = "Indrani",
                    last_name = "Mukherjee",
                    password = "Test",
                    UpdatedOn = DateTime.Now

                };
                //context.Entry(userdetail).State = System.Data.EntityState.Added;
                context.Entry(userdetail).State = EntityState.Added;

                context.SaveChanges();

            }
        }
    }
}