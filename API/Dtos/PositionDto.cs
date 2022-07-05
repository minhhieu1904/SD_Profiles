namespace API.Dtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public string Create_By { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Update_By { get; set; }
        public DateTime? Update_Time { get; set; }
    }
}