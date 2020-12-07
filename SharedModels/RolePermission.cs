using MongoDB.Bson.Serialization.Attributes;


namespace SharedModels
{
    public class RolePermission : BaseModel
    {
        [BsonRequired] public string RoleId { get; set; }
        [BsonRequired] public string PermissionId { get; set; }
    }
}