namespace API.Dtos
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public string BadgeType { get; set; }
        public string BadgeValue { get; set; }
        public bool? Active { get; set; }
        public int? Sequent { get; set; }
        public bool? Bookmark { get; set; }
        public Guid? Role_Id { get; set; }
        public string Role_Name { get; set; }
        public int? Parent_Id { get; set; }
    }
}