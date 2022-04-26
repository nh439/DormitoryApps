namespace dormitoryApps.Shared.ObjectGenerate
{
    public static class ObjectRandom
    {
        const string RandomString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        
        public static string RandomText(int length)
        {
            var arr = RandomString.ToCharArray();
            string result = string.Empty;
            Random ra = new Random();
            for (var i = 0; i < length; i++)
            {
                result +=arr[ra.Next(0,arr.Length)];
            }
            return result;
        }
        public static int CreateRandomNumber(int Highest)
        {
            Random random = new Random();
            return random.Next(0, Highest);
        }
        public static int CreatePin(int length)
        {
            Random random = new Random();
            return random.Next(1 - ((1) * (10 ^ length)), ((1) * (10 ^ length + 1)));
        }
    }
}
