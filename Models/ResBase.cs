namespace TechnoAcademyApi.Models
{
    public class ResBase<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Success";
        public int Code { get; set; } = 200;
        public T? Data { get; set; }
    }
}