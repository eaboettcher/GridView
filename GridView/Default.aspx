<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridView.Default" %>

<!DOCTYPE html>
<%--navbar is just to get it looking ok to show kenworth since this is not connected to a db the edit/update is just for show DONT ACTUALLY TRY TO COMMIT CHANGES--%>
<nav class="navbar navbar-expand-lg navbar-dark bg-primary">
    <a class="navbar-brand" href="#">Kenworth CSA</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarColor01">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
                <a class="nav-link" href="#">View ASN <span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">UPS SCS</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Discrepancy</a>
            </li>
        </ul>
        <ul class="nav navbar-nav navbar-right">
            <li class="nav-item">
                <a class="nav-link" href="#">Login</a>
            </li>
        </ul>
    </div>
</nav>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>GridView</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://maxcdn.bootstrapcdn.com/bootswatch/4.0.0-beta.3/sandstone/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/StyleSheet.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">
        <br />
        <div id="mainContainer" class="container">
            <div class="shadowBox">
                <div class="page-container">
                    <div class="container">
                        <h1 style="margin: 5px 0 20px 0;">View ASN</h1>
                        <div class="row">
                            <div class="col-lg-12 ">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvPerson" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" OnPageIndexChanging="gvPerson_PageIndexChanging" OnRowCancelingEdit="gvPerson_RowCancelingEdit" OnRowEditing="gvPerson_RowEditing" OnRowUpdating="gvPerson_RowUpdating" OnSorting="gvPerson_Sorting" EmptyDataText="There are no data records to display.">
                                        <Columns>
                                            <asp:CommandField ShowEditButton="True" />
                                            <asp:BoundField DataField="PersonID" HeaderText="PersonID" ReadOnly="True" SortExpression="PersonID" />
                                            <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
