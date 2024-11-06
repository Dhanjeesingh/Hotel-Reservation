<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem Text="Client" Value="Client">
                    <asp:MenuItem NavigateUrl="~/client.aspx" Text="Open" Value="Open"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="City" Value="City">
                    <asp:MenuItem NavigateUrl="~/city.aspx" Text="Open" Value="Open"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Hotelier" Value="Hotelier">
                    <asp:MenuItem NavigateUrl="~/Hotelier.aspx" Text="Open" Value="Open"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Date" Value="Date">
                    <asp:MenuItem NavigateUrl="~/Date.aspx" Text="Open" Value="Open"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Reservation" Value="Reservation">
                    <asp:MenuItem NavigateUrl="~/reservation.aspx" Text="Open" Value="Open"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
    </form>
</body>
</html>
