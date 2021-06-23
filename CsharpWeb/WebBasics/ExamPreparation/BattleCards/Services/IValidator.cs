using BattleCards.Models.Cards;
using BattleCards.Models.Users;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateCard(AddCardFormModel model);

        //string ValidateIssue(string description); 
    }
}
