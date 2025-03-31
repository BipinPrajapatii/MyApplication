namespace MyApplication.Core.Model
{
    public class Common
    {
        public static ListInputModel CreateListInputModel(JqueryDatatableParam model)
        {
            return new ListInputModel
            {
                Echo = model.sEcho,
                Start = model.iDisplayStart,
                Length = model.iDisplayLength,
                SortColumnDir = model.sSortDir_0,
                SortColumnIndex = model.iSortCol_0,
                SortColumn = model.sColumns == null ? "" : model.sColumns.Split(',')[model.iSortCol_0],
                Search = model.sSearch == null ? "" : model.sSearch
            };
        }
    }
}