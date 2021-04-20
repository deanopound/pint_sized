namespace PintSized.Api.Models.Response
{
    public class ShortURLResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public ShortURLModel Model { get; set; }
    }
}