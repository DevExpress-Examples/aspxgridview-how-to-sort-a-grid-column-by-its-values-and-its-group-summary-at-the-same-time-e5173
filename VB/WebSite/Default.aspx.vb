Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Data
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Public Const UnitsSortOrderSessionKey As String = "SortOrder"

	Protected Property SavedUnitsSortOrder() As ColumnSortOrder
		Get
			If Session(UnitsSortOrderSessionKey) Is Nothing Then
				Session(UnitsSortOrderSessionKey) = ColumnSortOrder.None
			End If
			Return CType(Session(UnitsSortOrderSessionKey), ColumnSortOrder)
		End Get
		Set(ByVal value As ColumnSortOrder)
			Session(UnitsSortOrderSessionKey) = value
		End Set
	End Property
	Protected Sub ASPxGridView1_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim grid = TryCast(sender, ASPxGridView)
		grid.DataSource = Enumerable.Range(0, 5).Select(Function(i) New With {Key .ProductName = If(i Mod 2 = 0, "Product One", "Product Two"), Key .OrderID = i, Key .Units = i * 100})
		grid.DataBind()

		Dim sortInfo = New ASPxGroupSummarySortInfo()
		sortInfo.SortOrder = GetStateSortOrder()
		sortInfo.SummaryItem = ASPxGridView1.GroupSummary("Units", SummaryItemType.Sum)
		sortInfo.GroupColumn = "ProductName"
		grid.GroupSummarySortInfo.AddRange(sortInfo)
	End Sub
	Protected Sub ASPxGridView1_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
		SavedUnitsSortOrder = GetStateSortOrder()
		ASPxGridView1.GroupSummarySortInfo(0).SortOrder = SavedUnitsSortOrder
	End Sub

	Protected Function GetStateSortOrder() As ColumnSortOrder
		If ASPxGridView1.DataColumns("Units").SortOrder = ColumnSortOrder.None Then
            Return If(SavedUnitsSortOrder <> ColumnSortOrder.None, SavedUnitsSortOrder, ColumnSortOrder.Ascending)
		End If
		Return ASPxGridView1.DataColumns("Units").SortOrder
	End Function
End Class