using System.Diagnostics;

namespace IDezApi.Storage.MongoDb.Models
{
    public class LogEntity : BaseEntityMDB
    {
        public string Source { get; set; } = String.Empty;
        public required string Level { get; set; }
        public required string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? Exception { get; set; } = String.Empty;

        public LogEntity()
        {
            Source = GetClasseChamadora();
        }

        public LogEntity(String mensage, Exception ex)
        {
            Source = GetClasseChamadora();
            Message = mensage;
            Exception = ex.Message;
        }

        public String GetClasseChamadora()
        {
            var stack = new StackTrace();
            return stack.GetFrame(1)?.GetMethod()?.DeclaringType?.Name!;
        }


    }
}
