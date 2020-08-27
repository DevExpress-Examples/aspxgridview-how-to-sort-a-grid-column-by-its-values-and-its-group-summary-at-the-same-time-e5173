<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="ASPxGridView1" runat="server" OnInit="ASPxGridView1_Init" OnBeforeGetCallbackResult="ASPxGridView1_BeforeGetCallbackResult">
			<SettingsBehavior AutoExpandAllGroups="true" />
			<Columns>
				<dx:GridViewDataTextColumn FieldName="ProductName" GroupIndex="0"></dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="OrderID"></dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Units"></dx:GridViewDataTextColumn>
			</Columns>
			<GroupSummary>
				<dx:ASPxSummaryItem FieldName="Units" ShowInColumn="ProductName" SummaryType="Sum" />
			</GroupSummary>
		</dx:ASPxGridView>
	</div>
	</form>
</body>
</html>