namespace XCore.Entities.Extensions
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
    public class EmployeeParameters : RequestParameters
    {

    }
}
