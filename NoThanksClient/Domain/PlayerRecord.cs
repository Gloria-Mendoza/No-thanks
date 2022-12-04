using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlayerRecord
    {
        private string nickname;
        private string score;

        public string Nickname { get { return nickname; } set { nickname = value; } }

        public string Score { get { return score; } set { score = value; } }
    }
}
