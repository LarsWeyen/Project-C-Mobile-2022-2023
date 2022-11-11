using System.Data;

namespace Mobile_Project_Api.Data.Framework
{
    public abstract class BaseResult
    {
        public int Rows { get; set; }
        public DataTable DataTable { get; set; }
        private List<string> errors = new List<string>();
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors => errors;

        public void AddErrors(string error)
        {
            errors.Add(error);
        }
    }
}
