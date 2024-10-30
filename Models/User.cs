using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    public ObjectId Id { get; set; }

    // Use default initialization to ensure non-nullable properties are initialized
    public string Username { get; set; } = string.Empty; // or string? Username { get; set; }
    public string Name { get; set; } = string.Empty; // or string? Name { get; set; }
    public string PhoneNumber { get; set; } = string.Empty; // or string? Number { get; set; }
    public string Email { get; set; } = string.Empty; // or string? Email { get; set; }
    public string Password { get; set; } = string.Empty; // or string? Password { get; set; }
    
    public string ProfilePicture { get; set; } = string.Empty; // or string? ProfilePicture { get; set; }
}
