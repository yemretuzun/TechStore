using MongoDB.Bson.Serialization.Attributes;


namespace SharedModels
{
  public class Credential : BaseModel
  {
        [BsonRequired] public string UserId { get; set; }
        [BsonRequired] public string CredentialTypeId { get; set; }
        [BsonRequired] public string Identifier { get; set; }
        [BsonRequired] public string Secret { get; set; }
        [BsonRequired] public string Extra { get; set; }
  }
}