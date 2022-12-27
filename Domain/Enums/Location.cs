using System.Runtime.Serialization;

namespace Domain.Enums;

public enum Location
{
    [EnumMember(Value = "Заберу с собой")] WithMe,

    [EnumMember(Value = "В кафе")] InCafe
}