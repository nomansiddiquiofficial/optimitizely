namespace OptimizelyDemo.Common.Models.Api.Request
{
    public class SearchBody
    {
        private int? pageSize;
        private int? pageNo;
		public string? SearchQuery { get; set; }
        public int? PageNo { get { return pageNo ?? 1; } set { pageNo = value; } }
        public int Skip => (PageSize.HasValue) ? (PageSize.Value) * ((PageNo.HasValue) ? (PageNo.Value - 1) : 0) : 0;
        public int? PageSize { get { return pageSize ?? 10; } set { pageSize = value; } }
        public bool? IsActive { get; set; }
        public string? Culture { get; set; }
		public bool SkipPagination { get; set; }
        public string? ContentType { get; set; }
        public string? CurrentItem { get; set; }
        public List<Filter>? Filters { get; set; }
    }

    public class Filter
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
