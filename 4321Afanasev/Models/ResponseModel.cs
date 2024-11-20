namespace _4321Afanasev.Models
{

    public class ResponseModel<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty; // Значение по умолчанию
        public List<string> Errors { get; set; } = new List<string>(); // Инициализация пустого списка
        public T? Data { get; set; } // Допустимость null

        public ResponseModel() { }

        public ResponseModel(T data, string message = "")
        {
            Succeeded = true;
            Message = message ?? string.Empty;
            Data = data;
        }

        public ResponseModel(string message)
        {
            Succeeded = true;
            Message = message ?? string.Empty;
        }
    }

}
