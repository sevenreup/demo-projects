namespace UniqueIdentifier.Entities
{
    public class Identity
    {
        public long Id { get; protected set; }
        public string Identifier { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
