<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchViewUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.SearchViewUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
     <meta charset="utf-8">
      
       
        
         <!-- Google Fonts -->
        <link href='https://fonts.googleapis.com/css?family=Raleway:500italic,600italic,600,700,700italic,300italic,300,400,400italic,800,900' rel='stylesheet' type='text/css'>
        
        <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,300,300italic,400italic,600italic,700,900' rel='stylesheet' type='text/css'>
        
        <!-- CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
        
        <!-- Fontawesome  -->
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
        
        <!-- Animate CSS -->
    <link href="../css/animate.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
        <!-- BX slider CSS -->
    <link href="../css/jquery.bxslider.css" rel="stylesheet" />
        
        <!-- responsive css -->
    <link href="../css/responsive.css" rel="stylesheet" />
        
 
      <!-- Bootstrap CSS CDN -->
   <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css">
    <!-- Our Custom CSS -->
    <link rel="stylesheet" href="../css/style1.css">

    <!-- Font Awesome JS -->
    <script defer src="https://use.fontawesome.com/releases/v5.0.13/js/solid.js" integrity="sha384-tzzSw1/Vo+0N5UhStP3bvwWPq+uvzCMfrN1fEFe+xBmv1C/AtVX5K0uZtmcHitFZ" crossorigin="anonymous"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.0.13/js/fontawesome.js" integrity="sha384-6OIrr52G08NpOFSZdxxz1xdNSndlD4vdcf/q2myIUVO0VsqaGHJsB0RaBE01VTOY" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="wrapper">
        <!-- Sidebar  -->
       <nav id="sidebar">
            <div class="sidebar-header">
                <h3>Stock Management System</h3>
            </div>

            <ul class="list-unstyled components">
                <p>Feature's</p>
                <li class="active">
                    <a href="IndexUI.aspx" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">HOME</a>
                </li>
                <li>
                    <a href="CategoryUI.aspx">Category_Setup</a>
                </li>

                <li>
                    <a href="CompanyUI.aspx">Company_Setup</a>
                </li>
                <li>
                    <a href="ItemUI.aspx">Item_setup</a>
                </li>
                <li>
                    <a href="StockInUI.aspx">Stock_In</a>
                </li>
                <li>
                    <a href="StockOutUI.aspx">Stock_Out</a>
                </li>
                <li>
                    <a href="SearchViewUI.aspx">Search&ViewItemsSummary</a>
                </li>
                <li>
                    <a href="SearchByDateUI.aspx">ViewSalesBetweenTowDates</a>
                </li>
            </ul>
        </nav>

        <!-- Page Content  -->
        <div id="content">
              <fieldset>
         <legend>Search & View Item's Summary</legend>
               <table>
          <tr>
              <td>
                  <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
              </td>
              <td class="auto-style1">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:DropDownList ID="companySearchDropDownList" AutoPostBack = "True" runat="server"></asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>                  
              </td>
                <td class="auto-style1">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:DropDownList ID="categorySearchDropDownList" runat="server"></asp:DropDownList>
              </td>
          </tr>
                   <tr>
                       <td>
                           <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="outputLabel" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>

      </table>
            <asp:GridView ID="searchGridViewList" runat="server" AutoGenerateColumns="False" >
            <Columns>  <%--Auto SL no generate code in GridView--%>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
           
                <asp:TemplateField HeaderText="Item Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
               <%-- <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
                <asp:TemplateField HeaderText="Available Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("AvailableQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Reorder Level">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("ReorderLevel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 
            </Columns>    
        </asp:GridView>

     </fieldset>
        </div>
    </div>
          <!-- Footer -->
        <footer class="footer">
        
            <div class="container">
            
                <div class="row">
                
                    <div class="col-md-6">
                    
                        <div id="copyright">
                            <p>Copyright &copy; 2018 <a href="#"> - Team Nautic</a></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                    
                            <div class="scroll-top">
                                <a href="#HOME" id="scroll-to-top"><i class="fa fa-angle-up"></i></a>
                            </div>
                    </div>
                
                
                </div>
            
            </div>
        </footer>
   
    </form>
    
            <!-- Bootstrap JavaScript -->
        <script src="../js/jquery.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <!-- Bx Slider JS -->
        <script src="../js/jquery.bxslider.min.js"></script>
        <!-- Add JS counter lib -->
        <script src="../js/jquery.waypoints.min.js"></script>
        <script src="../js/jquery.counterup.min.js"></script>
        <!-- Add wow js lib -->
        <script src="../js/wow.min.js"></script>
      
        <!-- Custom Js -->
    
        <script src="../js/custom.js"></script>
</body>
</html>