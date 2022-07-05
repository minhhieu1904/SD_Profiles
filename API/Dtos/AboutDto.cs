namespace API.Dtos
{
    public class AboutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? IsDefault { get; set; }
        public bool? Status { get; set; }
        public string Create_By { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Update_By { get; set; }
        public DateTime? Update_Time { get; set; }
    }
}