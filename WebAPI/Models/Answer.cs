namespace WebAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string user_name { get; set; }
        public int question_id { get; set; }
        public int option_id { get; set; }
    }
}
