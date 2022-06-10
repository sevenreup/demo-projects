namespace UniqueIdentifier.Serivices
{
    public class UniqueIDService : IUniqueIDService
    {
        private readonly Random _random;

        public UniqueIDService()
        {
            _random = new Random();
        } 
        public string GenerateUniqueId()
        {
            return RandomString(9);
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
