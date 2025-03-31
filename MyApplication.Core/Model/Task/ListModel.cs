namespace MyApplication.Core
{
    public class ListInputModel
    {
        public string Echo { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        //public int PageSize { get; set; }
        //public int Skip { get; set; }
        public int SortColumnIndex { get; set; }
    }

    public class ListOutputModel
    {
        public int RecordsTotal { get; set; }
    }

    public class JqueryDatatableParam
    {
        public string sEcho { get; set; }
        public string sSearch { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
        public string sFromDate { get; set; }
        public string sToDate { get; set; }
    }

    public class ListPaginationInputModel
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int pageRange { get; set; }
    }

    public class ListPaginationOutputModel
    {
        public object Items { get; set; }
        public int RecordsTotal { get; set; }
    }
}