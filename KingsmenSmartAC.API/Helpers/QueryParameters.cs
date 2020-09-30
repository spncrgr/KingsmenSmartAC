namespace KingsmenSmartAC.API.Helpers
{
    public class QueryParameters
    {
        private const int MaxPageSize = 500;
        private int _pageSize = 50;
        private string _orderBy = "";
        private string _searchTerms = "";
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public string SearchTerms
        {
            get => _searchTerms;
            set
            {
                _searchTerms = (value == null) ? "" : value;
            }
        }

        public string OrderBy
        {
            get { return _orderBy; }
            set
            {
                _orderBy = (value == null) ? "" : value;
            }
        }
    }
}