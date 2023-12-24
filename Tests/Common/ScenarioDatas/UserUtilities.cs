using userMicroservice.Data;
using userMicroservice.Model;

namespace userMicroservice.Tests.Common.ScenarioDatas
{
    public static class UserUtilities
    {
        public static void CreateUser(this DbContextClass dbContextClass)
        {
            var user = new User
            {
                UserId = 1,
                UserName = "Adeline",
                Address = "1 rue Général de Gaulle 01500 Ambérieu-en-Bugey"
            };

            dbContextClass.Users.Add(user);
            dbContextClass.SaveChanges();
        }

        public static void CreateUsers(this DbContextClass dbContextClass)
        {
            var user1 = new User
            {
                UserId = 1,
                UserName = "Carole",
                Address = "18 Rue de la République 69008 Lyon 8"
            };

            var user2 = new User
            {
                UserId = 2,
                UserName = "Camille",
                Address = " 20 rue d'Athènes 26000 Valence"
            };

            dbContextClass.Users.AddRange(user1, user2);
            dbContextClass.SaveChanges();
        }
    }
}
