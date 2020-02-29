using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.ClassLibrary
{
    public static class ConfigurationModel
    {
        public static string SelectData = " Id , Title , Spot , Image ,Link ,CreatingDate,OrderOfAdding, Category from Entities ";

        public static string TruncateEntities = "Truncate Table Entities";

        public static string InsertEntites = "INSERT INTO Entities (Title,Spot,Image,Category,Link,CreatingDate,OrderOfAdding) VALUES (@Title, @Spot,@Image,@Category,@Link,@CreatingDate,@OrderOfAdding)";

    }
}
