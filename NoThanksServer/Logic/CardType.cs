using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

    public enum CardType : int
    {
        [EnumMember] Three = 3, [EnumMember] Four, [EnumMember] Five,
        [EnumMember] Six, [EnumMember] Seven, [EnumMember] Eight,
        [EnumMember] Nine, [EnumMember] Ten, [EnumMember] Eleven,
        [EnumMember] Twelve, [EnumMember] Thirteen, [EnumMember] Fourteen,
        [EnumMember] Fifteen, [EnumMember] Sixteen, [EnumMember] Seventeen,
        [EnumMember] Eightteen, [EnumMember] Nineteen, [EnumMember] Twenty,
        [EnumMember] TwentyOne, [EnumMember] TwentyTwo, [EnumMember] TwentyThree,
        [EnumMember] TwentyFour, [EnumMember] TwentyFive, [EnumMember] TwentySix,
        [EnumMember] TwentySeven, [EnumMember] TwentyEight, [EnumMember] TwentyNine,
        [EnumMember] Thirty, [EnumMember] ThirtyOne, [EnumMember] ThirtyTwo,
        [EnumMember] ThirtyThree, [EnumMember] ThirtyFour, [EnumMember] ThirtyFive
    }
}
