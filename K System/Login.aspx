<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="K_System.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0,minimal-ui">
    <title>Veltrix - Responsive Bootstrap 4 Admin Dashboard</title>
    <meta content="Admin Dashboard" name="description">
    <meta content="Themesbrand" name="author">
    <link rel="shortcut icon" href="BS\veltrix\layouts\vertical\assets\images\favicon.ico">
    <link href="BS\veltrix\layouts\vertical\assets\css\bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="BS\veltrix\layouts\vertical\assets\css\metismenu.min.css" rel="stylesheet" type="text/css">
    <link href="BS\veltrix\layouts\vertical\assets\css\icons.css" rel="stylesheet" type="text/css">
    <link href="BS\veltrix\layouts\vertical\assets\css\style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div class="home-btn d-none d-sm-block"><a href="index.html" class="text-white"><i class="fas fa-home h2"></i></a></div>
    <!-- Begin page -->
    <div class="accountbg"></div>
    <div class="wrapper-page account-page-full">
        <div class="card">
            <div class="card-body">
                <div class="text-center">
                    <a href="index.html" class="logo">
                        <img src="BS\veltrix\layouts\vertical\assets\images\logo-dark.png" height="22" alt="logo"></a>
                </div>
                <div class="p-3">
                    <h4 class="font-18 m-b-5 text-center">Welcome Back !</h4>
                    <p class="text-muted text-center">Sign in to continue to Veltrix.</p>
                    <form class="form-horizontal m-t-30" id="login" runat="server">
                        <div class="form-group">
                            <label for="username">Username</label>
                            <asp:TextBox ID="ID" runat="server" type="text" CssClass="form-control" name="ID" placeholder="Id akses" required="autofocus" />
                        </div>
                        <div class="form-group">
                            <label for="userpassword">Password</label>
                            <asp:TextBox ID="pass" runat="server" type="password" CssClass="form-control" name="password" placeholder="Password" required=""></asp:TextBox>
                        </div>
                         <div class="input-group">
                                 <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                     <asp:ListItem>Karyawan</asp:ListItem>
                                     <asp:ListItem>Admin</asp:ListItem>
                                     <asp:ListItem>Owner</asp:ListItem>
                                 </asp:RadioButtonList>
                            </div>
                        <div class="form-group row m-t-20">
                            <div class="col-sm-6">
                                <div class="custom-control custom-checkbox">
                                    <input type="checkbox" class="custom-control-input" id="customControlInline">
                                    <label class="custom-control-label" for="customControlInline">Remember me</label>
                                </div>
                            </div>
                            <div class="col-sm-6 text-right">
                                <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button_karyawan"  CssClass="btn btn-primary w-md waves-effect waves-light"/>

                            </div>
                        </div>
                        <div class="form-group m-t-10 mb-0 row">
                            <div class="col-12 m-t-20"><a href="pages-recoverpw-2.html"><i class="mdi mdi-lock"></i>Forgot your password?</a></div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="m-t-40 text-center">
            <p>Don't have an account ? <a href="pages-register-2.html" class="font-500 text-primary">Signup now</a></p>
            <p>© 2019 Veltrix. Crafted with <i class="mdi mdi-heart text-danger"></i>by Themesbrand</p>
        </div>
    </div>
    <!-- end wrapper-page -->
    <!-- jQuery  -->
    <script src="BS\veltrix\layouts\vertical\assets\js\jquery.min.js"></script>
    <script src="BS\veltrix\layouts\vertical\assets\js\bootstrap.bundle.min.js"></script>
    <script src="BS\veltrix\layouts\vertical\assets\js\metisMenu.min.js"></script>
    <script src="BS\veltrix\layouts\vertical\assets\js\jquery.slimscroll.js"></script>
    <script src="BS\veltrix\layouts\vertical\assets\js\waves.min.js"></script>
    <!-- App js -->
    <script src="BS\veltrix\layouts\vertical\assets\js\app.js"></script>
</body>
</html>
