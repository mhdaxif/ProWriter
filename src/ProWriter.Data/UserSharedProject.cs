namespace ProWriter.Data
{
    public class UserSharedProject 
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        // Todo: create PK/Uniqe index on UserId & ProjectId 
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
