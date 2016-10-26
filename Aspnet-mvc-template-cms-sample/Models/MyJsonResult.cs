namespace Aspnet_mvc_template_cms_sample.Models
{
    public partial class MyJsonResult<T>
    {
        public bool HasError { get; set; }
        public T Message { get; set; }

        public MyJsonResult()
        {

        }

        public MyJsonResult(bool hasError, T message)
        {
            HasError = hasError;
            Message = message;
        }
    }
}