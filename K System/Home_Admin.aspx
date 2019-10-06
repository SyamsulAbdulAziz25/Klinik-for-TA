<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home_Admin.aspx.cs" Inherits="K_System.Home_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="page-title-box">
            <div class="row align-items-center">
                <div class="col-sm-6">
                    <h4 class="page-title">Dashboard</h4>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item active">Welcome to Veltrix Dashboard</li>
                    </ol>
                </div>
                <div class="col-sm-6">
                    <div class="float-right d-none d-md-block">
                        <div class="dropdown">
                            <button aria-expanded="false" aria-haspopup="true" class="btn btn-primary dropdown-toggle arrow-none waves-effect waves-light" data-toggle="dropdown" type="button">
                                <i class="mdi mdi-settings mr-2"></i>Settings
                            </button>
                            <div class="dropdown-menu dropdown-menu-right">
                                <a class="dropdown-item" href="#">Action</a> <a class="dropdown-item" href="#">Another action</a> <a class="dropdown-item" href="#">Something else here</a><div class="dropdown-divider">
                                </div>
                                <a class="dropdown-item" href="#">Separated link</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                    <!-- end row -->
                    <div class="row">
                        <div class="col-xl-3 col-md-6">
                            <div class="card mini-stat bg-primary text-white">
                                <div class="card-body">
                                    <div class="mb-4">
                                        <div class="float-left mini-stat-img mr-4">
                                            <img alt="" src="assets\images\services-icon\01.png" /></div>
                                        <h5 class="font-16 text-uppercase mt-0 text-white-50">Orders</h5>
                                        <h4 class="font-500">1,685 <i class="mdi mdi-arrow-up text-success ml-2"></i></h4>
                                        <div class="mini-stat-label bg-success">
                                            <p class="mb-0">
                                                + 12%</p>
                                        </div>
                                    </div>
                                    <div class="pt-2">
                                        <div class="float-right">
                                            <a class="text-white-50" href="#"><i class="mdi mdi-arrow-right h5"></i></a>
                                        </div>
                                        <p class="text-white-50 mb-0">
                                            Since last month</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-6">
                            <div class="card mini-stat bg-primary text-white">
                                <div class="card-body">
                                    <div class="mb-4">
                                        <div class="float-left mini-stat-img mr-4">
                                            <img alt="" src="assets\images\services-icon\02.png" /></div>
                                        <h5 class="font-16 text-uppercase mt-0 text-white-50">Revenue</h5>
                                        <h4 class="font-500">52,368 <i class="mdi mdi-arrow-down text-danger ml-2"></i></h4>
                                        <div class="mini-stat-label bg-danger">
                                            <p class="mb-0">
                                                - 28%</p>
                                        </div>
                                    </div>
                                    <div class="pt-2">
                                        <div class="float-right">
                                            <a class="text-white-50" href="#"><i class="mdi mdi-arrow-right h5"></i></a>
                                        </div>
                                        <p class="text-white-50 mb-0">
                                            Since last month</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-6">
                            <div class="card mini-stat bg-primary text-white">
                                <div class="card-body">
                                    <div class="mb-4">
                                        <div class="float-left mini-stat-img mr-4">
                                            <img alt="" src="assets\images\services-icon\03.png" /></div>
                                        <h5 class="font-16 text-uppercase mt-0 text-white-50">Average Price</h5>
                                        <h4 class="font-500">15.8 <i class="mdi mdi-arrow-up text-success ml-2"></i></h4>
                                        <div class="mini-stat-label bg-info">
                                            <p class="mb-0">
                                                00%</p>
                                        </div>
                                    </div>
                                    <div class="pt-2">
                                        <div class="float-right">
                                            <a class="text-white-50" href="#"><i class="mdi mdi-arrow-right h5"></i></a>
                                        </div>
                                        <p class="text-white-50 mb-0">
                                            Since last month</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-6">
                            <div class="card mini-stat bg-primary text-white">
                                <div class="card-body">
                                    <div class="mb-4">
                                        <div class="float-left mini-stat-img mr-4">
                                            <img alt="" src="assets\images\services-icon\04.png" /></div>
                                        <h5 class="font-16 text-uppercase mt-0 text-white-50">Product Sold</h5>
                                        <h4 class="font-500">2436 <i class="mdi mdi-arrow-up text-success ml-2"></i></h4>
                                        <div class="mini-stat-label bg-warning">
                                            <p class="mb-0">
                                                + 84%</p>
                                        </div>
                                    </div>
                                    <div class="pt-2">
                                        <div class="float-right">
                                            <a class="text-white-50" href="#"><i class="mdi mdi-arrow-right h5"></i></a>
                                        </div>
                                        <p class="text-white-50 mb-0">
                                            Since last month</p>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
                    <!-- end row -->
                    <div class="row">
                        <div class="col-xl-9">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="mt-0 header-title mb-5">Monthly Earning</h4>
                                    <div class="row">
                                        <div class="col-lg-7">
                                            <div>
                                                <div id="chart-with-area" class="ct-chart earning ct-golden-section">
                                                    <div class="chartist-tooltip">
                                                    </div>
                                                    <svg class="ct-chart-line" height="100%" style="width: 100%; height: 100%;" width="100%" xmlns:ct="http://gionkunz.github.com/chartist-js/ct">
                                                        <g class="ct-grids">
                                                        <line x1="50" x2="50" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="94.21484375" x2="94.21484375" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="138.4296875" x2="138.4296875" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="182.64453125" x2="182.64453125" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="226.859375" x2="226.859375" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="271.07421875" x2="271.07421875" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="315.2890625" x2="315.2890625" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line x1="359.50390625" x2="359.50390625" y1="15" y2="249" class="ct-grid ct-horizontal">
                                                        </line>
                                                        <line y1="249" y2="249" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="223" y2="223" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="197" y2="197" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="171" y2="171" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="145" y2="145" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="119" y2="119" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="93" y2="93" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="67" y2="67" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="41" y2="41" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        <line y1="15" y2="15" x1="50" x2="403.71875" class="ct-grid ct-vertical">
                                                        </line>
                                                        </g>
                                                        <g>
                                                        <g class="ct-series ct-series-a">
                                                        <path d="M50,249L50,119C64.738,84.333,79.477,15,94.215,15C108.953,15,123.691,67,138.43,67C153.168,67,167.906,41,182.645,41C197.383,41,212.121,98.2,226.859,119C241.598,139.8,256.336,171,271.074,171C285.813,171,300.551,119,315.289,119C330.027,119,344.766,136.333,359.504,145L359.504,249Z" class="ct-area">
                                                        </path>
                                                        <path d="M50,119C64.738,84.333,79.477,15,94.215,15C108.953,15,123.691,67,138.43,67C153.168,67,167.906,41,182.645,41C197.383,41,212.121,98.2,226.859,119C241.598,139.8,256.336,171,271.074,171C285.813,171,300.551,119,315.289,119C330.027,119,344.766,136.333,359.504,145" class="ct-line">
                                                        </path>
                                                        <line x1="50" y1="119" x2="50.01" y2="119" class="ct-point" ct:value="5">
                                                        </line>
                                                        <line x1="94.21484375" y1="15" x2="94.22484375" y2="15" class="ct-point" ct:value="9">
                                                        </line>
                                                        <line x1="138.4296875" y1="67" x2="138.4396875" y2="67" class="ct-point" ct:value="7">
                                                        </line>
                                                        <line x1="182.64453125" y1="41" x2="182.65453125" y2="41" class="ct-point" ct:value="8">
                                                        </line>
                                                        <line x1="226.859375" y1="119" x2="226.869375" y2="119" class="ct-point" ct:value="5">
                                                        </line>
                                                        <line x1="271.07421875" y1="171" x2="271.08421875" y2="171" class="ct-point" ct:value="3">
                                                        </line>
                                                        <line x1="315.2890625" y1="119" x2="315.2990625" y2="119" class="ct-point" ct:value="5">
                                                        </line>
                                                        <line x1="359.50390625" y1="145" x2="359.51390625" y2="145" class="ct-point" ct:value="4">
                                                        </line>
                                                        </g>
                                                        </g>
                                                        <g class="ct-labels">
                                                        <foreignObject style="overflow: visible;" x="50" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="94.21484375" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="138.4296875" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="182.64453125" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="226.859375" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="271.07421875" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="315.2890625" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" x="359.50390625" y="254" width="44.21484375" height="20">
                                                        <span class="ct-label ct-horizontal ct-end" style="width: 44px; height: 20px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="223" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="197" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="171" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="145" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="119" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="93" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="67" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="41" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="15" x="10" height="26" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 26px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        <foreignObject style="overflow: visible;" y="-15" x="10" height="30" width="30">
                                                        <span class="ct-label ct-vertical ct-start" style="height: 30px; width: 30px;" xmlns="http://www.w3.org/2000/xmlns/"></span>
                                                        </foreignObject>
                                                        </g>
                                                    </svg>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="text-center">
                                                        <p class="text-muted mb-4">
                                                            This month</p>
                                                        <h4>$34,252</h4>
                                                        <p class="text-muted mb-5">
                                                            It will be as simple as in fact it will be occidental.</p>
                                                        <span class="peity-donut" data-height="72" data-peity="{ &quot;fill&quot;: [&quot;#02a499&quot;, &quot;#f2f2f2&quot;], &quot;innerRadius&quot;: 28, &quot;radius&quot;: 32 }" data-width="72" style="display: none;">4/5</span>
                                                        <svg class="peity" height="72" width="72">
                                                            <path d="M 36 0 A 36 36 0 1 1 1.7619654133744689 24.875388202501895 L 9.370417543735698 27.347524157501475 A 28 28 0 1 0 36 8" data-value="4" fill="#02a499">
                                                            </path>
                                                            <path d="M 1.7619654133744689 24.875388202501895 A 36 36 0 0 1 35.99999999999999 0 L 35.99999999999999 8 A 28 28 0 0 0 9.370417543735698 27.347524157501475" data-value="1" fill="#f2f2f2">
                                                            </path>
                                                        </svg>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="text-center">
                                                        <p class="text-muted mb-4">
                                                            Last month</p>
                                                        <h4>$36,253</h4>
                                                        <p class="text-muted mb-5">
                                                            It will be as simple as in fact it will be occidental.</p>
                                                        <span class="peity-donut" data-height="72" data-peity="{ &quot;fill&quot;: [&quot;#02a499&quot;, &quot;#f2f2f2&quot;], &quot;innerRadius&quot;: 28, &quot;radius&quot;: 32 }" data-width="72" style="display: none;">3/5</span>
                                                        <svg class="peity" height="72" width="72">
                                                            <path d="M 36 0 A 36 36 0 1 1 14.83973091747097 65.1246117974981 L 19.542012935810757 58.65247584249853 A 28 28 0 1 0 36 8" data-value="3" fill="#02a499">
                                                            </path>
                                                            <path d="M 14.83973091747097 65.1246117974981 A 36 36 0 0 1 35.99999999999999 0 L 35.99999999999999 8 A 28 28 0 0 0 19.542012935810757 58.65247584249853" data-value="2" fill="#f2f2f2">
                                                            </path>
                                                        </svg>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end row -->
                                </div>
                            </div>
                            <!-- end card -->
                        </div>
                        <div class="col-xl-3">
                            <div class="card">
                                <div class="card-body">
                                    <div>
                                        <h4 class="mt-0 header-title mb-4">Sales Analytics</h4>
                                    </div>
                                    <div class="wid-peity mb-4">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div>
                                                    <p class="text-muted">
                                                        Online</p>
                                                    <h5 class="mb-4">1,542</h5>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-4">
                                                    <span class="peity-line" data-height="60" data-peity="{ &quot;fill&quot;: [&quot;rgba(2, 164, 153,0.3)&quot;],&quot;stroke&quot;: [&quot;rgba(2, 164, 153,0.8)&quot;]}" data-width="100%" style="display: none;">6,2,8,4,3,8,1,3,6,5,9,2,8,1,4,8,9,8,2,1</span>
                                                    <svg class="peity" height="60" width="100%">
                                                        <polygon fill="rgba(2, 164, 153,0.3)" points="0 59.5 0 20.16666666666667 4.467105263157895 46.388888888888886 8.93421052631579 7.055555555555557 13.401315789473685 33.27777777777778 17.86842105263158 39.833333333333336 22.335526315789473 7.055555555555557 26.80263157894737 52.94444444444444 31.269736842105264 39.833333333333336 35.73684210526316 20.16666666666667 40.203947368421055 26.72222222222222 44.671052631578945 0.5 49.13815789473684 46.388888888888886 53.60526315789474 7.055555555555557 58.07236842105263 52.94444444444444 62.53947368421053 33.27777777777778 67.00657894736842 7.055555555555557 71.47368421052632 0.5 75.9407894736842 7.055555555555557 80.40789473684211 46.388888888888886 84.875 52.94444444444444 84.875 59.5">
                                                        </polygon>
                                                        <polyline fill="none" points="0 20.16666666666667 4.467105263157895 46.388888888888886 8.93421052631579 7.055555555555557 13.401315789473685 33.27777777777778 17.86842105263158 39.833333333333336 22.335526315789473 7.055555555555557 26.80263157894737 52.94444444444444 31.269736842105264 39.833333333333336 35.73684210526316 20.16666666666667 40.203947368421055 26.72222222222222 44.671052631578945 0.5 49.13815789473684 46.388888888888886 53.60526315789474 7.055555555555557 58.07236842105263 52.94444444444444 62.53947368421053 33.27777777777778 67.00657894736842 7.055555555555557 71.47368421052632 0.5 75.9407894736842 7.055555555555557 80.40789473684211 46.388888888888886 84.875 52.94444444444444" stroke="rgba(2, 164, 153,0.8)" stroke-width="1" stroke-linecap="square">
                                                        </polyline>
                                                    </svg>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="wid-peity mb-4">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div>
                                                    <p class="text-muted">
                                                        Offline</p>
                                                    <h5 class="mb-4">6,451</h5>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-4">
                                                    <span class="peity-line" data-height="60" data-peity="{ &quot;fill&quot;: [&quot;rgba(2, 164, 153,0.3)&quot;],&quot;stroke&quot;: [&quot;rgba(2, 164, 153,0.8)&quot;]}" data-width="100%" style="display: none;">6,2,8,4,-3,8,1,-3,6,-5,9,2,-8,1,4,8,9,8,2,1</span>
                                                    <svg class="peity" height="60" width="100%">
                                                        <polygon fill="rgba(2, 164, 153,0.3)" points="0 31.735294117647058 0 10.911764705882355 4.467105263157895 24.79411764705882 8.93421052631579 3.970588235294116 13.401315789473685 17.852941176470587 17.86842105263158 42.147058823529406 22.335526315789473 3.970588235294116 26.80263157894737 28.264705882352942 31.269736842105264 42.147058823529406 35.73684210526316 10.911764705882355 40.203947368421055 49.088235294117645 44.671052631578945 0.5 49.13815789473684 24.79411764705882 53.60526315789474 59.5 58.07236842105263 28.264705882352942 62.53947368421053 17.852941176470587 67.00657894736842 3.970588235294116 71.47368421052632 0.5 75.9407894736842 3.970588235294116 80.40789473684211 24.79411764705882 84.875 28.264705882352942 84.875 31.735294117647058">
                                                        </polygon>
                                                        <polyline fill="none" points="0 10.911764705882355 4.467105263157895 24.79411764705882 8.93421052631579 3.970588235294116 13.401315789473685 17.852941176470587 17.86842105263158 42.147058823529406 22.335526315789473 3.970588235294116 26.80263157894737 28.264705882352942 31.269736842105264 42.147058823529406 35.73684210526316 10.911764705882355 40.203947368421055 49.088235294117645 44.671052631578945 0.5 49.13815789473684 24.79411764705882 53.60526315789474 59.5 58.07236842105263 28.264705882352942 62.53947368421053 17.852941176470587 67.00657894736842 3.970588235294116 71.47368421052632 0.5 75.9407894736842 3.970588235294116 80.40789473684211 24.79411764705882 84.875 28.264705882352942" stroke="rgba(2, 164, 153,0.8)" stroke-width="1" stroke-linecap="square">
                                                        </polyline>
                                                    </svg>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div>
                                                    <p class="text-muted">
                                                        Marketing</p>
                                                    <h5>84,574</h5>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-4">
                                                    <span class="peity-line" data-height="60" data-peity="{ &quot;fill&quot;: [&quot;rgba(2, 164, 153,0.3)&quot;],&quot;stroke&quot;: [&quot;rgba(2, 164, 153,0.8)&quot;]}" data-width="100%" style="display: none;">6,2,8,4,3,8,1,3,6,5,9,2,8,1,4,8,9,8,2,1</span>
                                                    <svg class="peity" height="60" width="100%">
                                                        <polygon fill="rgba(2, 164, 153,0.3)" points="0 59.5 0 20.16666666666667 4.467105263157895 46.388888888888886 8.93421052631579 7.055555555555557 13.401315789473685 33.27777777777778 17.86842105263158 39.833333333333336 22.335526315789473 7.055555555555557 26.80263157894737 52.94444444444444 31.269736842105264 39.833333333333336 35.73684210526316 20.16666666666667 40.203947368421055 26.72222222222222 44.671052631578945 0.5 49.13815789473684 46.388888888888886 53.60526315789474 7.055555555555557 58.07236842105263 52.94444444444444 62.53947368421053 33.27777777777778 67.00657894736842 7.055555555555557 71.47368421052632 0.5 75.9407894736842 7.055555555555557 80.40789473684211 46.388888888888886 84.875 52.94444444444444 84.875 59.5">
                                                        </polygon>
                                                        <polyline fill="none" points="0 20.16666666666667 4.467105263157895 46.388888888888886 8.93421052631579 7.055555555555557 13.401315789473685 33.27777777777778 17.86842105263158 39.833333333333336 22.335526315789473 7.055555555555557 26.80263157894737 52.94444444444444 31.269736842105264 39.833333333333336 35.73684210526316 20.16666666666667 40.203947368421055 26.72222222222222 44.671052631578945 0.5 49.13815789473684 46.388888888888886 53.60526315789474 7.055555555555557 58.07236842105263 52.94444444444444 62.53947368421053 33.27777777777778 67.00657894736842 7.055555555555557 71.47368421052632 0.5 75.9407894736842 7.055555555555557 80.40789473684211 46.388888888888886 84.875 52.94444444444444" stroke="rgba(2, 164, 153,0.8)" stroke-width="1" stroke-linecap="square">
                                                        </polyline>
                                                    </svg>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
                    <!-- end row -->
                    <div class="row">
                        <div class="col-xl-3">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="mt-0 header-title mb-4">Sales Report</h4>
                                    <div class="cleafix">
                                        <p class="float-left">
                                            <i class="mdi mdi-calendar mr-1 text-primary"></i>Jan 01 - Jan 31</p>
                                        <h5 class="font-18 text-right">$4230</h5>
                                    </div>
                                    <div id="ct-donut" class="ct-chart wid">
                                        <div class="chartist-tooltip">
                                        </div>
                                        <svg class="ct-chart-donut" height="100%" style="width: 100%; height: 100%;" width="100%" xmlns:ct="http://gionkunz.github.com/chartist-js/ct">
                                            <g class="ct-series ct-series-a">
                                            <path d="M81.598,172.247A64.875,64.875,0,1,0,99.875,45.125" class="ct-slice-donut" ct:value="54" style="stroke-width: 60px;">
                                            </path>
                                            </g>
                                            <g class="ct-series ct-series-b">
                                            <path d="M42.691,79.361A64.875,64.875,0,0,0,81.815,172.311" class="ct-slice-donut" ct:value="28" style="stroke-width: 60px;">
                                            </path>
                                            </g>
                                            <g class="ct-series ct-series-c">
                                            <path d="M99.875,45.125A64.875,64.875,0,0,0,42.584,79.561" class="ct-slice-donut" ct:value="17" style="stroke-width: 60px;">
                                            </path>
                                            </g>
                                        </svg>
                                    </div>
                                    <div class="mt-4">
                                        <table class="table mb-0">
                                            <tr>
                                                <td><span class="badge badge-primary">Desk</span></td>
                                                <td>Desktop</td>
                                                <td class="text-right">54.5%</td>
                                            </tr>
                                            <tr>
                                                <td><span class="badge badge-success">Mob</span></td>
                                                <td>Mobile</td>
                                                <td class="text-right">28.0%</td>
                                            </tr>
                                            <tr>
                                                <td><span class="badge badge-warning">Tab</span></td>
                                                <td>Tablets</td>
                                                <td class="text-right">17.5%</td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="mt-0 header-title mb-4">Activity</h4>
                                    <ol class="activity-feed">
                                        <li class="feed-item">
                                            <div class="feed-item-list">
                                                <span class="date">Jan 22</span> <span class="activity-text">Responded to need “Volunteer Activities”</span></div>
                                        </li>
                                        <li class="feed-item">
                                            <div class="feed-item-list">
                                                <span class="date">Jan 20</span> <span class="activity-text">At vero eos et accusamus et iusto odio dignissimos ducimus qui deleniti atque...<a class="text-success" href="#">Read more</a></span></div>
                                        </li>
                                        <li class="feed-item">
                                            <div class="feed-item-list">
                                                <span class="date">Jan 19</span> <span class="activity-text">Joined the group “Boardsmanship Forum”</span></div>
                                        </li>
                                        <li class="feed-item">
                                            <div class="feed-item-list">
                                                <span class="date">Jan 17</span> <span class="activity-text">Responded to need “In-Kind Opportunity”</span></div>
                                        </li>
                                        <li class="feed-item">
                                            <div class="feed-item-list">
                                                <span class="date">Jan 16</span> <span class="activity-text">Sed ut perspiciatis unde omnis iste natus error sit rem.</span></div>
                                        </li>
                                    </ol>
                                    <div class="text-center">
                                        <a class="btn btn-primary" href="#">Load More</a></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-5">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="card text-center">
                                        <div class="card-body">
                                            <div class="py-4">
                                                <i class="ion ion-ios-checkmark-circle-outline display-4 text-success"></i>
                                                <h5 class="text-primary mt-4">Order Successful</h5>
                                                <p class="text-muted">
                                                    Thanks you so much for your order.</p>
                                                <div class="mt-4">
                                                    <a class="btn btn-primary btn-sm" href="">Chack Status</a></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="card bg-primary">
                                        <div class="card-body">
                                            <div class="text-center text-white py-4">
                                                <h5 class="mt-0 mb-4 text-white-50 font-16">Top Product Sale</h5>
                                                <h1>1452</h1>
                                                <p>
                                                    Computer</p>
                                                <p class="text-white-50 mb-0">
                                                    At solmen va esser necessi far uniform myth... <a class="text-white" href="#">View more</a></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-body">
                                            <h4 class="mt-0 header-title mb-4">Client Reviews</h4>
                                            <p class="text-muted mb-5">
                                                &quot; Everyone realizes why a new common language would be desirable one could refuse to pay expensive translators it would be necessary. &quot;</p>
                                            <div class="float-right mt-2">
                                                <a class="text-primary" href="#"><i class="mdi mdi-arrow-right h5"></i></a>
                                            </div>
                                            <h6 class="mb-0">
                                                <img alt="" class="thumb-sm rounded-circle mr-2" src="assets\images\users\user-3.jpg" /> James Athey</h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
                    <!-- end row -->
                    <div class="row">
                        <div class="col-xl-8">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="mt-0 header-title mb-4">Latest Trasaction</h4>
                                    <div class="table-responsive">
                                        <table class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th scope="col">(#) Id</th>
                                                    <th scope="col">Name</th>
                                                    <th scope="col">Date</th>
                                                    <th scope="col">Amount</th>
                                                    <th colspan="2" scope="col">Status</th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <th scope="row">#14256</th>
                                                <td>
                                                    <div>
                                                        <img alt="" class="thumb-md rounded-circle mr-2" src="assets\images\users\user-2.jpg" /> Philip Smead</div>
                                                </td>
                                                <td>15/1/2018</td>
                                                <td>$94</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>
                                                    <div>
                                                        <a class="btn btn-primary btn-sm" href="#">Edit</a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">#14257</th>
                                                <td>
                                                    <div>
                                                        <img alt="" class="thumb-md rounded-circle mr-2" src="assets\images\users\user-3.jpg" /> Brent Shipley</div>
                                                </td>
                                                <td>16/1/2019</td>
                                                <td>$112</td>
                                                <td><span class="badge badge-warning">Pending</span></td>
                                                <td>
                                                    <div>
                                                        <a class="btn btn-primary btn-sm" href="#">Edit</a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">#14258</th>
                                                <td>
                                                    <div>
                                                        <img alt="" class="thumb-md rounded-circle mr-2" src="assets\images\users\user-4.jpg" /> Robert Sitton</div>
                                                </td>
                                                <td>17/1/2019</td>
                                                <td>$116</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>
                                                    <div>
                                                        <a class="btn btn-primary btn-sm" href="#">Edit</a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">#14259</th>
                                                <td>
                                                    <div>
                                                        <img alt="" class="thumb-md rounded-circle mr-2" src="assets\images\users\user-5.jpg" /> Alberto Jackson</div>
                                                </td>
                                                <td>18/1/2019</td>
                                                <td>$109</td>
                                                <td><span class="badge badge-danger">Cancel</span></td>
                                                <td>
                                                    <div>
                                                        <a class="btn btn-primary btn-sm" href="#">Edit</a></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">#14260</th>
                                                <td>
                                                    <div>
                                                        <img alt="" class="thumb-md rounded-circle mr-2" src="assets\images\users\user-6.jpg" /> David Sanchez</div>
                                                </td>
                                                <td>19/1/2019</td>
                                                <td>$120</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>
                                                    <div>
                                                        <a class="btn btn-primary btn-sm" href="#">Edit</a></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="mt-0 header-title mb-4">Chat</h4>
                                    <div class="chat-conversation">
                                        <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 443.594px;">
                                            <ul class="conversation-list slimscroll" style="max-height: 400px; overflow: hidden; width: auto; height: 443.594px;">
                                                <li class="clearfix">
                                                    <div class="chat-avatar">
                                                        <img alt="male" src="assets\images\users\user-2.jpg" /> <span class="time">10:00</span></div>
                                                    <div class="conversation-text">
                                                        <div class="ctext-wrap">
                                                            <span class="user-name">John Deo</span><p>
                                                                Hello!</p>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="clearfix odd">
                                                    <div class="chat-avatar">
                                                        <img alt="Female" src="assets\images\users\user-3.jpg" /> <span class="time">10:01</span></div>
                                                    <div class="conversation-text">
                                                        <div class="ctext-wrap">
                                                            <span class="user-name">Smith</span><p>
                                                                Hi, How are you? What about our next meeting?</p>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="clearfix">
                                                    <div class="chat-avatar">
                                                        <img alt="male" src="assets\images\users\user-2.jpg" /> <span class="time">10:04</span></div>
                                                    <div class="conversation-text">
                                                        <div class="ctext-wrap">
                                                            <span class="user-name">John Deo</span><p>
                                                                Yeah everything is fine</p>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="clearfix odd">
                                                    <div class="chat-avatar">
                                                        <img alt="male" src="assets\images\users\user-3.jpg" /> <span class="time">10:05</span></div>
                                                    <div class="conversation-text">
                                                        <div class="ctext-wrap">
                                                            <span class="user-name">Smith</span><p>
                                                                Wow that&#39;s great</p>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="clearfix odd">
                                                    <div class="chat-avatar">
                                                        <img alt="male" src="assets\images\users\user-3.jpg" /> <span class="time">10:08</span></div>
                                                    <div class="conversation-text">
                                                        <div class="ctext-wrap">
                                                            <span class="user-name mb-2">Smith</span>
                                                            <img alt="" class="rounded mr-2" height="48px" src="assets\images\small\img-1.jpg" />
                                                            <img alt="" class="rounded" height="48px" src="assets\images\small\img-2.jpg" /></div>
                                                    </div>
                                                </li>
                                            </ul>
                                            <div class="slimScrollBar" style="background: rgb(158, 165, 171); width: 5px; position: absolute; top: 0px; opacity: 0.4; display: block; border-radius: 7px; z-index: 99; right: 1px; height: 304.183px;">
                                            </div>
                                            <div class="slimScrollRail" style="width: 5px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; background: rgb(51, 51, 51); opacity: 0.2; z-index: 90; right: 1px;">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-9 col-8 chat-inputbar">
                                                <input class="form-control chat-input" placeholder="Enter your text" type="text" /></div>
                                            <div class="col-sm-3 col-4 chat-send">
                                                <button class="btn btn-success btn-block" type="submit">
                                                    Send
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
                    <!-- end row -->
                </div>
</asp:Content>
