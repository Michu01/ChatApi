using System.Text.Json.Serialization;

namespace ChatApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageContentType
    {
        Text, Image, Video, Audio, File
    }
}
