<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.IndexUI" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Management System Application </title>
        
        <meta charset="utf-8">
      
       
        
         <!-- Google Fonts -->
        <link href='https://fonts.googleapis.com/css?family=Raleway:500italic,600italic,600,700,700italic,300italic,300,400,400italic,800,900' rel='stylesheet' type='text/css'>
        
        <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,300,300italic,400italic,600italic,700,900' rel='stylesheet' type='text/css'>
        
        <!-- favicon -->
        <link rel="icon" type="image/png" href="images/favicon.png">
        
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
        
             

</head>
<body>
    <form id="form1" runat="server">
     
    
         <!-- Header -->
        <header class="header" id="HOME">
            
            <!-- Navigation -->
            
            <nav class="navbar navbar-default navbar-fixed-top">
              
                
                <div class="container">
                  
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#loso-navbar-collapse-1" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                      </button>
                       <a class="navbar-brand" href="IndexUI.aspx"> 
               
                          StockManagementSystem						  

                        </a>
                    </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="loso-navbar-collapse-1">
                  <ul class="nav navbar-nav navbar-right">
                        <li><a href="#HOME" class="nav-item">Log In</a></li>
                
                  </ul>
                 
                 
                </div><!-- /.navbar-collapse -->
              </div><!-- /.container-fluid -->
</nav>
            
            
        
<div class="header-overlay">
            
            
              	<div class="container header-container">    
                    
                    <div class="row">
                        
                        <div class="col-md-8">
                        
                            <div class="header-text">
                            
                                <!-- Title & Description -->
                                <h1> Stock Management System</h1>
                                <p> An inventory System which gives u faster the people!</p>
                            
                            </div>
                            
                        </div>
                        
                        <div class="col-md-3 col-md-offset-1">
                        
                            
                        </div>
                        
                        
                    </div>
                    
                
                </div>
                
            
            </div>
            
        </header>

                <!-- Features -->
        <section class="features" id="FEATURES">
            
            <div class="container">
            
                <div class="row">
                
                
                    <div class="col-md-10 col-md-offset-1">
                    
                        <div class="section-title wow fadeIn" data-wow-duration="1s">
                        
                            <h2> Features </h2>
                            
                            <p>Stock Management is the function of understanding the stock mix of a company and the different demands on that stock.
                                The demands are influenced by both external and internal factors.
                            </p>
                        
                        </div>
                    
                    </div>
                    
                    
                
                
                </div>
            
            
            </div>
            
            <div class="features-inner-wrapper">
            
                <div class="container">
                
                    <div class="row">
                    
                    
                        <div class="col-md-4 wow fadeInLeft" data-wow-duration="1s">
                        
                            
                            <!-- left feature item 01 -->
                            <div class="left-feature-item">
                                <!-- Icon -->
                                <div class="left-feature-item-icon">
                                    <i class="fa fa-desktop"></i>
                                </div>
                            
                                <!-- feature item title & description -->
                                <a href="CategoryUI.aspx"><h3>Category Setup</h3></a>
                                <p>Here user can create category for his inventory</p>
                            
                            </div>
                            
                            
                             <!-- left feature item 02 -->
                            <div class="left-feature-item">
                                <!-- Icon -->
                                <div class="left-feature-item-icon">
                                    <i class="fa fa-mobile"></i>
                                </div>
                            
                                <!-- feature item title & description -->
                                <a href="CompanyUI.aspx"><h3>Company Setup</h3></a>
                                <p>Here user can create company for his inventory</p>
                            
                            </div>
                            
                             <!-- left feature item 03 -->
                            <div class="left-feature-item">
                                <!-- Icon -->
                                <div class="left-feature-item-icon">
                                    <i class="fa fa-eye"></i>
                                </div>
                            
                                <!-- feature item title & description -->
                                <a href="ItemUI.aspx"><h3>Item Setup</h3></a>
                                <p>Here user can store Item for his inventory</p>
                            </div>
                        
                        
                        
                        </div>
                        
                        
                        <div class="col-md-4">
                        
                                <div class="feature-iphone">
                            
                                    <img class="wow bounceIn img-responsive" data-wow-duration="1s" src="../images/mob.jpg" alt="feature iphone">
                            
                                </div>
                        
                        
                        </div>
                        
                        <div class="col-md-4 wow fadeInRight" data-wow-duration="1s">
                        
                            <!-- right feature item 01 -->
                            <div class="right-feature-item">
                            
                                <!-- Icon -->
                                <div class="right-feature-item-icon">
                                    <i class="fa fa-certificate"></i>
                                
                                </div>
                                
                                <!-- feature item title and description -->
                               <a href="StockInUI.aspx"><h3>Stock In</h3></a>
                                <p>Here user can stock item for his inventory</p>
                                
                            
                            </div>
                            
                            
                            
                             <!-- right feature item 02 -->
                            <div class="right-feature-item">
                            
                                <!-- Icon -->
                                <div class="right-feature-item-icon">
                                    <i class="fa fa-rss"></i>
                                
                                </div>
                                
                                <!-- feature item title and description -->
                               <a href="StockOutUI.aspx"><h3>Stock Out</h3></a>
                                <p>Here user can stock out  from his inventory</p>
                                
                            
                            </div>
                            
                            
                             <!-- right feature item 03 -->
                            <div class="right-feature-item">
                            
                                <!-- Icon -->
                                <div class="right-feature-item-icon">
                                    <i class="fa fa-database"></i>
                                
                                </div>
                                
                                <!-- feature item title and description -->
                                <a href="SearchViewUI.aspx"><h3>View & Search Summary</h3></a>
                                <p>show details of Inventory</p>
                                
                            
                            </div>
                              <div class="right-feature-item">
                            
                                <!-- Icon -->
                                <div class="right-feature-item-icon">
                                    <i class="fa fa-database"></i>
                                
                                </div>
                                
                                <!-- feature item title and description -->
                                <a href="SearchByDateUI.aspx"><h3>View Sales Between Two Dates</h3></a>
                                <p>Sales Information</p>
                                
                            
                            </div>
                        
                        </div>
                        
                    
                    
                    </div>
                
                
                </div>
            
            </div>
        
        
        <!-- Testimonials -->
        <section class="testimonial">
        
            <div class="testimonial-overlay">
            
                <div class="container">
                
                    <div class="row">
                    
                        <div class="col-md-12 wow bounceInDown">
                        
                        
                            <div id="carousel-testimonial" class="carousel slide" data-ride="carousel">
                            
                            
                                <!-- indicators -->
                                <ol class="carousel-indicators">
                                    <li data-target="#carousel-testimonial" data-slide-to="0" class="active"></li>
                                    
                                </ol>
                                
                                
                                <!-- wrapper for slides -->
                                <div class="carousel-inner">
                                
                                
                                    <!-- item 01 -->
                                    <div class="item active text-center">
                                    
                                    
                                        <img src="../images/himel.jpg" alt="testimonial" class="center-block">
                                        
                                        <div class="testimonial-caption">
                                        
                                            <h2>Tayeb Himel</h2>
                                            <h4><span> Instructor, </span>BITM</h4>
                                        </div>
                                        
                                    
                                    </div>
                   
                                </div>
                                      
                            </div>
                          
                        </div>
                        
                        
                    </div>
                
                
                </div>
            
            
            </div>
        
        
        
        </section>
        
                <!-- About Us -->
        <section id="ABOUT">
        
            <div class="container">
            
                <div class="row">
                
                    <div class="col-md-10 col-md-offset-1">
                    
                        <!-- About us Title & Description -->
                        <div class="section-title">
                        
                            <h2> About Us </h2>
            
                        </div>
                    
                    
                    
                    </div>
                
                </div>
            
            
            </div>
        
            <div class="choose-us-wraper">
            
                <div class="container">
                
                    <div class="row">
                    
                        <div class="col-md-6">
                        
                            <!-- About iphone -->
                            <div class="about-iphone wow fadeInLeft" data-wow-duration="1s" data-wow-delay=".5s">
                            
                                <img class="img-responsive" src="../images/TM-1.png" alt="iphone">
                            
                            </div>
                        
                        </div>
                        
                        <div class="col-md-6 wow fadeInRight" data-wow-duration="1s" data-wow-delay=".5s">
                        
                            <!-- Why choose us title -->
                            <div class="choose-us-title">
                            
                            
                                <h2> Team Nautic</h2>
                                <p>Here's the team member's of Nautic</p>
                            
                            </div>
                            
                            <!-- why choose us description -->
                            <div class="choose-us-des">
                            
                                <!-- choose us item 1 -->
                                <div class="choose-us-item wow fadeInUp" data-wow-duration=".5s" data-wow-delay="1s">
                                    
                                    <!-- choose us item icon -->
                                    <div><i class="fa fa-bolt"></i></div>
                                    
                                    <!-- choose us item title & des -->
                                    <h3>Khairul Islam Azam</h3>
                                    <p>Team Leader, Team Nautic</p>
                                
                                </div>
                                
                                
                                <!-- choose us item 2 -->
                                <div class="choose-us-item wow fadeInUp" data-wow-duration=".5s" data-wow-delay="1s">
                                    
                                    <!-- choose us item icon -->
                                    <div><i class="fa fa-bullhorn"></i></div>
                                    
                                    <!-- choose us item title & des -->
                                    <h3>Mahir Hasnat</h3>
                                    <p>Member, Team Nautic</p>
                                
                                </div>
                                
                                
                                 <!-- choose us item 3 -->
                                <div class="choose-us-item wow fadeInUp" data-wow-duration=".5s" data-wow-delay="1s">
                                    
                                    <!-- choose us item icon -->
                                    <div><i class="fa fa-flag-o"></i></div>
                                    
                                    <!-- choose us item title & des -->
                                      <h3>MH RIFAT</h3>
                                    <p>Member, Team Nautic</p>
                                
                                </div>
                                 <div class="choose-us-item wow fadeInUp" data-wow-duration=".5s" data-wow-delay="1s">
                                    
                                    <!-- choose us item icon -->
                                    <div><i class="fa fa-flag-o"></i></div>
                                    
                                    <!-- choose us item title & des -->
                                      <h3>YEASIN TANIM</h3>
                                    <p>Member, Team Nautic</p>
                                
                                </div>
                                
                                
                            
                            </div>
                            
                            
                            
                        
                        </div>
                    
                    </div>
                
                </div>
            
            </div>
        
        
        </section>

  
        
     
        
        <!-- Available On -->
        <section class="available-on">
        
            <div class="container wow bounceInRight" data-wow-duration="1s">
            
                <div class="row">
                
                    <div class="col-md-6">
                    
                        <div class="available-title">
                            <h2>Follow US </h2>
                        
                            <p>Vestibulum congue eros ac neque dignissim, vel imperdiet neque consectetur. Maecenas condimentum cursus maximus. Praesent eu diam efficitur</p>    
                        
                        </div>
                    
                    </div>
                    <div class="col-md-6">
                    
                        <div class="row">
                        
                            <a href="#">
                            
                                <div class="col-md-4 no-padding">
                                    <div class="available-on-item">
                                    
                                        <i class="fa fa-facebook"></i>
                                        <div class="available-on-inner">
                                        
                                            <h2> Facebook</h2>
                                        
                                        </div>
                                    
                                    </div>
                                
                                </div> 
                                
                            
                            </a>
                            
                            
                            
                             <a href="#">
                            
                                <div class="col-md-4 no-padding">
                                    <div class="available-on-item">
                                    
                                        <i class="fa fa-linkedin"></i>
                                        <div class="available-on-inner">
                                        
                                            <h2> LinkedIn</h2>
                                        
                                        </div>
                                    
                                    </div>
                                
                                </div> 
                                
                            
                            </a>
                            
                             <a href="#">
                            
                                <div class="col-md-4 no-padding">
                                    <div class="available-on-item">
                                    
                                        <i class="fa fa-twitter"></i>
                                        <div class="available-on-inner">
                                        
                                            <h2> Twitter</h2>
                                        
                                        </div>
                                    
                                    </div>
                                
                                </div> 
                                
                            
                            </a>
                        
                        
                        
                        </div>
                        
                    
                    </div>
                    
                
                
                </div>
            </div>
        
        </section>
        
        
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
