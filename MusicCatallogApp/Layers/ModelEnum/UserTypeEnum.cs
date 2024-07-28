using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MusicCatallogApp.Layers.ModelEnum
{
    public class UserTypeEnum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserType
        {
            [EnumMember(Value = "user")]
            user = 0,
            [EnumMember(Value = "admin")]
            admin = 1,
            [EnumMember(Value="musicEditor")]
            musicEditor=2
        }
    }
}
