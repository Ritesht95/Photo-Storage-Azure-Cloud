<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhoto.aspx.cs" Inherits="CCPhotoUpload.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Photo</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center mt-5">
            <h2>Add Photos</h2>
            <div class="form-group mt-5 row">
                <asp:Label CssClass="col-form-label col-md-2 offset-1" runat="server" ID="lblFileUpload">Photo Title</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control col-md-6" ID="txtFileName"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label CssClass="col-form-label col-md-2 offset-1" runat="server" ID="lblDescription">Photo Description</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control col-md-6" ID="txtDecription" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label CssClass="col-form-label col-md-2 offset-1" runat="server" ID="lblKeywords">Keywords</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control col-md-6" ID="txtKeywords" TextMode="MultiLine"></asp:TextBox><br />
            </div>
            <div class="form-group row">
                <asp:Label CssClass="col-form-label col-md-2 offset-1" runat="server" ID="lblFile">File</asp:Label>
                <asp:FileUpload runat="server" CssClass="form-control-file col-md-6" ID="fileInput" />
            </div>
            <br />
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Upload" ID="btnUpload" OnClick="btnUpload_Click" />
        </div>
    </form>
</body>
</html>
