using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FormsService.DAL.Entities;

public enum Location
{
    [EnumMember(Value = "Заберу с собой")]
    WithMe, 

    [EnumMember(Value = "В кафе")]
    InCafe  
}