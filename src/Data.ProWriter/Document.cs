namespace Data.ProWriter
{
    public class Document : Entity
    {
        public string Name { get; set; }
        
        // TODO: Rename Description to Payload/
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
