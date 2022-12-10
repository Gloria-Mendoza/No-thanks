using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Register
    {
        public Register()
        {

        }
        public bool NewRegister(Logic.Player player)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                Data.Player newPlayer = new Data.Player()
                {
                    name = player.Name,
                    lastName = player.LastName,
                    nickname = player.Nickname,
                    email = player.Email,
                    password = player.Password
                };

                context.Players.Add(newPlayer);
                try
                {
                    status = context.SaveChanges() > 0;
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
            return status;
        }
    }
}
