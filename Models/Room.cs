using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Room
{
    [BsonId]
    public ObjectId Id { get; set; }

    // Use default initialization to ensure non-nullable properties are initialized
    public string Pictures { get; set; } = string.Empty; // or string? Username { get; set; }
    public string Description { get; set; } = string.Empty; // or string? Name { get; set; }
    public string Location { get; set; } = string.Empty; // or string? Number { get; set; }
    public string Username { get; set; } = string.Empty; // or string? Email { get; set; }
    public string ProfilePicture { get; set; } = string.Empty; // or string? ProfilePicture { get; set; }
}
