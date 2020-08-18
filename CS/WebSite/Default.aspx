<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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
