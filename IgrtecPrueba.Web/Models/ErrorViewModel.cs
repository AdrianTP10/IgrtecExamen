namespace IgrtecPrueba.Web.Models
{
    public class ErrorViewModel
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }

        public List<String> errors { get; set; }
    }
}
