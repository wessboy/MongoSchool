using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Persistance.DataBaseConfig;
     public class ObjectIdStringSerializer : SerializerBase<string>
    {

    public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var bsonType = context.Reader.GetCurrentBsonType();
        Console.WriteLine($"Bson type: {bsonType}");

        if (bsonType == BsonType.ObjectId)
        {
            
            var objectId = context.Reader.ReadObjectId();
            Console.WriteLine($"seralized ObjectId type: {objectId}");
            Console.WriteLine($"seralized ObjectId: {objectId.ToString()}");

            return objectId.ToString(); 
        }

        return bsonType == BsonType.String ? context.Reader.ReadString() : string.Empty;
    }


    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
    {
          args.SerializeIdFirst = true;
        Console.WriteLine($"value to be seralized:{value}");

        if (ObjectId.TryParse(value.Trim(), out var objectId))
        {
            
            Console.WriteLine($"Deseralizer ObjectId: {objectId}");
            context.Writer.WriteObjectId(objectId);
            
        }

          
    }
}
