namespace TechnoAcademyApi.Models.Dto.Res
{
    public class Response
    {
        public string? Message { get; set; }
        public object? Data { get; set; }

        public Response(string message, object data)
        {
            this.Message = message == string.Empty ? "Success" : message;
            this.Data = data;

        }

        public Response(string message)
        {
            this.Message = message == string.Empty ? "Success" : message;
        }

        public Response(object data)
        {
            this.Data = data;
        }
    }
}
