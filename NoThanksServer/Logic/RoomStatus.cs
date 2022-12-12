using System.Runtime.Serialization;

namespace Logic
{
    public enum RoomStatus
    {
        [EnumMember]
        Waitting,
        [EnumMember]
        Started,
        [EnumMember]
        Finished
    }
}