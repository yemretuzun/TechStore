using MongoDB.Bson.Serialization.Attributes;


namespace SharedModels
{
  public class CredentialType : BaseModel
  {
        [BsonRequired]public string Code { get; set; }
        [BsonRequired] public string Name { get; set; }
  }
}