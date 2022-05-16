namespace dormitoryApps.Client.Enum
{
    public static class ServiceException<T>
    {
        public static string Insert()
        {
            Type entity = typeof(T);
            string message = $"{ExceptionMessage.INSERT} at {DateTime.Now}";
            return message.Replace("[Name]", entity.Name);
        }
        public static string Update()
        {
            Type entity = typeof(T);
            string message = $"{ExceptionMessage.UPDATE} at {DateTime.Now}";
            return message.Replace("[Name]", entity.Name);
        }
        public static string Delete()
        {
            Type entity = typeof(T);
            string message = $"{ExceptionMessage.DELETE} at {DateTime.Now}";
            return message.Replace("[Name]", entity.Name);
        }
        public static string Select()
        {
            Type entity = typeof(T);
            string message = $"{ExceptionMessage.SELECT} at {DateTime.Now}";
            return message.Replace("[Name]", entity.Name);
        }

    }
    public class ExceptionMessage
    {
        public const string INSERT = "Insert [Name] Incomplete ";
        public const string UPDATE = "Update [Name] Incomplete ";
        public const string DELETE = "Delete [Name] Incomplete ";
        public const string SELECT = "GET [Name] Incomplete ";

    }
}
