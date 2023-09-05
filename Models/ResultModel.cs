namespace wsSanMartin.Models
{
    public class ResultModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResultModel()
        {
            Status = true;
            Message = "Operacion exitosa";
            Data = new object();
        }
    }
}