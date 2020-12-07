using MongoDB.Bson.Serialization.Attributes;


namespace SharedModels
{
    /// <summary>
    /// Kullanıcının rolü; Admin, AuthenticetedUser, CommunityAdmin, Editor, ... gibi roller
    /// <para></para>
    /// Şimdilik sadece BasicUser ve Administrator var
    /// </summary>
    public class Role : BaseModel
    {
        [BsonRequired] public string Code { get; set; }
        [BsonRequired] public string Name { get; set; }
    }
}