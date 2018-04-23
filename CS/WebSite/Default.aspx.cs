using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Data;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    public const string UnitsSortOrderSessionKey = "SortOrder";

    protected ColumnSortOrder SavedUnitsSortOrder {
        get {
            if (Session[UnitsSortOrderSessionKey] == null)
                Session[UnitsSortOrderSessionKey] = ColumnSortOrder.None;
            return (ColumnSortOrder)Session[UnitsSortOrderSessionKey];
        }
        set { Session[UnitsSortOrderSessionKey] = value; }
    }
    protected void ASPxGridView1_Init(object sender, EventArgs e) {
        var grid = sender as ASPxGridView;
        grid.DataSource = Enumerable.Range(0, 5).Select(i => new {
            ProductName = i % 2 == 0 ? "Product One" : "Product Two",
            OrderID = i,
            Units = i * 100
        });
        grid.DataBind();

        var sortInfo = new ASPxGroupSummarySortInfo();
        sortInfo.SortOrder = GetStateSortOrder();
        sortInfo.SummaryItem = ASPxGridView1.GroupSummary["Units", SummaryItemType.Sum];
        sortInfo.GroupColumn = "ProductName";
        grid.GroupSummarySortInfo.AddRange(sortInfo);
    }
    protected void ASPxGridView1_BeforeGetCallbackResult(object sender, EventArgs e) {
        ASPxGridView1.GroupSummarySortInfo[0].SortOrder = SavedUnitsSortOrder = GetStateSortOrder();
    }

    protected ColumnSortOrder GetStateSortOrder() {
        if (ASPxGridView1.DataColumns["Units"].SortOrder == ColumnSortOrder.None)
            return SavedUnitsSortOrder != ColumnSortOrder.None ? SavedUnitsSortOrder : ColumnSortOrder.Ascending;
        return ASPxGridView1.DataColumns["Units"].SortOrder;
    }
}