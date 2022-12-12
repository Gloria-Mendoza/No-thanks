using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ListPlayers
    {
        public List<String> ListAllPlayer()
        {
            List<String> logicPlayers = new List<String>();
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                select players);
                if (accounts.Any())
                {
                    foreach (var account in accounts)
                    {
                        logicPlayers.Add(account.nickname);
                    }
                }
            }
            return logicPlayers;
        }
    }
}

