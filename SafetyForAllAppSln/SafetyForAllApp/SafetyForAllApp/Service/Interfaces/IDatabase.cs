using SafetyForAllApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafetyForAllApp.Service.Interfaces
{
   public interface IDatabase
   {
        Task<List<SignUpDetails>> GetItemsAsync();
        Task<List<SignUpDetails>> GetItemsNotDoneAsync();
        Task<int> SaveItemAsync(SignUpDetails item);
        Task<int> DeleteItemAsync(SignUpDetails item);
        Task<SignUpDetails> GetUserByUserName(string userName);

    }
}
