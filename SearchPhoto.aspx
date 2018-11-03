<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPhoto.aspx.cs" Inherits="CCPhotoUpload.SearchPhoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group">
                <h3 class="text-center">Search photos here</h3>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtSearch"></asp:TextBox>
            </div>
            <div class="form-group text-center">
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Search" ID="btnSearch" OnClick="btnSearch_Click" />
            </div>
            <asp:Repeater runat="server" ID="rptImages">
                <ItemTemplate>
                    <div class="card">
                        <div class="card-body">
                            <h3 class="card-title"><%# Eval("Title") %></h3>
                            <div class="card-columns">
                                <asp:Image runat="server" CssClass="card-img-top img-thumbnail" ImageUrl='<%# Eval("Filepath") %>' />
                                <p class="card-text"><strong>Description:</strong> <%# Eval("Description") %></p>
                                <p>&nbsp;</p>
                                <p><strong>Size: </strong><%# (Math.Round(Convert.ToDecimal(Convert.ToInt32(Eval("Size"))/1024),2)).ToString()+"Kb" %></p>
                                <p><strong>Type: </strong><%# Eval("Type") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
