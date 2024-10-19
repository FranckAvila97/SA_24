namespace SA_W4.Helpers
{
    public class Response
    {
        public Response() { }
        public Response(object data, int status, string message)
        {
            Data = data;
            Status = status;
            Message = message;
        }
        public object Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
