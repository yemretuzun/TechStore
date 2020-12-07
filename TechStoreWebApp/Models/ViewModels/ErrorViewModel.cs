namespace TechStoreWebApp.Models.ViewModels
{
    public class ErrorViewModel
    {
      
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Message { get; set; }

        public ErrorViewModel()
        {
            Message = "";
        }

        public ErrorViewModel(string msg)
        {
            Message = msg;
        }
    }
}
