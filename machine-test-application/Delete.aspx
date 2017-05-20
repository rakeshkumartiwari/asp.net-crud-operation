<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="machine_test_application.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 24%;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 400px;margin-top: 30px">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2">Delete User</td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:Label ID="lblState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnUpdate_Click" Text="Delete" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
