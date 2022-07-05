namespace API.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public string Skill { get; set; }
        public int? Position_Id { get; set; }
        public bool? Status { get; set; }
        public string Create_By { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Update_By { get; set; }
        public DateTime? Update_Time { get; set; }

        public string Position_Name { get; set; }
    }
}