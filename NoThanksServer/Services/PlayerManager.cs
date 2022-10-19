using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using Logic;

namespace Services
{
    public class PlayerManager : IPlayerManager
    {
        public bool Login(String nickname, String password)
        {
            var status = false;
            try
            {
                Authentication client = new Authentication();
                status = client.Login(nickname, password);
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.Message);
            }
            return status;
        }

        public bool Register(Player player)
        {
            return false;
        }
    }
}
