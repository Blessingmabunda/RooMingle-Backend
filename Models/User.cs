using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

public class User
{
    [BsonId]
    [JsonIgnore]
    public ObjectId Id { get; set; }

    public string id => Id.ToString();

    // Use default initialization to ensure non-nullable properties are initialized
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ProfilePicture { get; set; } = string.Empty;
}