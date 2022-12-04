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
    public class ListFriends
    {
        public List<String> ListAllFriend(int idPlayer)
        {
            List<String> logicFriend = new List<String>();
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                               join friend in context.Friends on players.idPlayer equals friend.idPlayer1
                                               where friend.idPlayer1 == idPlayer
                                               select new
                                               {
                                                   nick = players.nickname,
                                                   id = players.idPlayer
                                               });
                if (accounts.Any())
                {
                    foreach (var account in accounts)
                    {
                        logicFriend.Add(account.nick);

                    }

                }
            }
            return logicFriend;
        }
    }
    public class ListRequest { 
    public List<String> ListAllRequest(int idPlayer)
    {
        List<String> logicFriend = new List<String>();
        using (var context = new NoThanksEntities())
        {
                var accounts = (from friends in context.Friends
                                join player in context.Players on friends.idPlayer2 equals player.idPlayer
                                where friends.idPlayer1 == idPlayer
                            select new
                            {
                                nick = player.nickname,
                                id = player.idPlayer
                            });
            if (accounts.Any())
            {
                foreach (var account in accounts)
                {
                    logicFriend.Add(account.nick);

                }

            }
        }
        return logicFriend;
        }
    }
}

