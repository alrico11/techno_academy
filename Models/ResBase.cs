namespace TechnoAcademyApi.Models
{
    public class ResBase<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
