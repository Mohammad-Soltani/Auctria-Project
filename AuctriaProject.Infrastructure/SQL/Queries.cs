using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AuctriaProject.Infrastructure.SQL
{
    public static class Queries
    {
        public const string GetUserRole =
          @"SELECT [UserName],[Role] FROM [dbo].[Users]  
                    WHERE [UserName] = @userName and [Password]= @password";

        public const string GetAllItems = @"SELECT * FROM [dbo].[Items]";

        public const string GetItemById = @"SELECT * FROM [dbo].[Items] WHERE [Id] = @id";

        public const string AddNewItem = @"INSERT INTO [dbo].[Items] ([Title], [Price], [AvailableQuantity])
                                           VALUES (@title, @price, @availableQuantity);";

        public const string UpdateItem = @"UPDATE [dbo].[Items] SET [AvailableQuantity] = @availableQuantity
                                                    WHERE [Id] = @id;";

        public const string DeleteItem = @"DELETE FROM [dbo].[Items]
                                           WHERE [Id] = @id;";

        public const string GetAllShppingCardItems = @"SELECT sc.*, i.Title , i.Price, i.AvailableQuantity FROM [dbo].[ShoppingCard] sc
                                                       INNER JOIN [dbo].[Items] i on sc.ItemId = i.id
                                                       WHERE [UserId] = @userId;";

        public const string AddItemToShppingCard = @"INSERT INTO [dbo].[ShoppingCard] ([UserId], [ItemId], [Quantity])
                                                    VALUES (@userId, @itemId, @quantity);";

        public const string UpdateItemQuantity = @"UPDATE [dbo].[ShoppingCard] SET [Quantity] = @quantity
                                                    WHERE [Id] = @id;";

        public const string DeleteItemFromShppingCard = @"DELETE FROM [dbo].[ShoppingCard] WHERE [ItemId] = @itemId;";
    }
}
