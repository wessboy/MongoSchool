using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Persistance.DataBaseConfig;
     public class ObjectIdStringSerializer : SerializerBase<string>
    {

    public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var bsonType = context.Reader.GetCurrentBsonType();

        if(bsonType == BsonType.ObjectId)
        {
            var objectId = context.Reader.ReadObjectId();

            return objectId.ToString(); 
        }

        return bsonType == BsonType.String ? context.Reader.ReadString() : string.Empty;
    }


    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
    {
        if(ObjectId.TryParse(value, out var objectId))
        {
            context.Writer.WriteObjectId(objectId); 
        }
    }
}
