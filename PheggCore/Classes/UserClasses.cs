using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PheggCore.Staff;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PheggCore
{
    public class DiscordMember
    {
        public DiscordMember(ClaimsPrincipal user, JObject memObj)
        {  
            MemberObject = memObj;

            Username = user.Identity.Name;
            UserID = user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            AvatarHash = user.Claims.First(c => c.Type == "urn:discord:avatar:hash").Value;
        }

        public DiscordMember(ClaimsPrincipal user, JObject memObj, JObject rolesObject)
        {
            MemberObject = memObj;
            RolesObject = rolesObject;

            Username = user.Identity.Name;
            UserID = user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            AvatarHash = user.Claims.First(c => c.Type == "urn:discord:avatar:hash").Value;
        }

        [JsonConstructor]
        public DiscordMember()
        {

        }

        public string Username { get; set; }
        public string UserID { get; set; }
        public string AvatarHash { get; set; }


        public string AvatarUrl
        {
            get
            {
                return $"https://cdn.discordapp.com/avatars/{UserID}/{AvatarHash}.{(AvatarHash.StartsWith("a_") ? "gif" : "png")}?size=1024;";
            }
        }


        public bool IsBanned => BanData != null;
        public bool IsMember => MemberObject != null;
        public bool IsStaff => StaffData != null;

        public string Nickname => MemberObject["nick"]?.ToString();

        public ulong[] Roles => null;

        public DateTime JoinedAt => MemberObject["joined_at"].ToObject<DateTime>();

        public JObject MemberObject { get; private set; }
        public JObject RolesObject { get; private set; }
        public List<DynamicTag> DynamicTags { get; set; }

        public string SteamID { get; set; }

        public BanData BanData { get; set; }

        public StaffData StaffData { get; set; }
    }

    public class BanData
    {
        public BanData(JObject banObj)
        {
            BanObject = banObj;
        }

        public string Reason => BanObject["reason"].ToString();


        public JObject BanObject { get; set; }
    }
}
