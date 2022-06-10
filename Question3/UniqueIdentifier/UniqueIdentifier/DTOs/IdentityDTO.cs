namespace UniqueIdentifier.DTOs
{
    public class IdentityDTO
    {
        public string Identifier { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
