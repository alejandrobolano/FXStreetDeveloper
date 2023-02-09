namespace Football.API
{
    public class Properties
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Contact Contact { get; set; }
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
}
