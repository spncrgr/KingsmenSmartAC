﻿namespace KingsmenSmartAC.API.Helpers
{
    public class PagingParameters
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 50;
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
    }
}