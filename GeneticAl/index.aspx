<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GeneticAl.index" %>

<!doctype html>
<html class="no-js h-100" lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>Genetic Algorithm</title>
    <meta name="description" content="Genetic Algorithm AI By CPE.59241/Group.9">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<link rel='shortcut icon' type='image/x-icon' href='images/favicon.ico' />
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.9.0/css/all.css" integrity="sha384-i1LQnF23gykqWXg6jxC2ZbCbUMxyw5gLZY6UiUS98LYV5unm8GWmfkIS6jqJfb4E" crossorigin="anonymous">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" data-version="1.1.0" href="styles/shards-dashboards.1.1.0.css">
    <link rel="stylesheet" href="styles/extras.1.1.0.min.css">
    <script async defer src="https://buttons.github.io/buttons.js"></script>
    <script src="https://kit.fontawesome.com/790878a58b.js"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.9.0/js/all.js" integrity="sha384-7Gk1S6elg570RSJJxILsRiq8o0CO99g1zjfOISrqjFUCjxHDn3TmaWoWOqt6eswF" crossorigin="anonymous"></script>
    
    <!-- SweetAlert -->
    <link rel="stylesheet" href="dist/sweetalert2.min.css">
    <script src="dist/sweetalert2.min.js"></script>


     <script type="text/javascript">
        function success(x) {
          swal.fire({
                title: 'สิ้นสุดการทำงาน !',
                text: 'ค่า x สูงสุดของฟังชันก์ y = x ^ 2 เท่ากับ: ' + x +' ',
                type: 'success', // อันนี้คือประเภทว่าจะให้เป็นแบบไหน
                timer: 2500  // หน่วงเวลา 
            })
        }
        function falsenode(node) {
            swal.fire({
                title: 'ไม่พบโหนด ' + node + ' ที่ค้นหา',  //สิ่งที่เปลี่ยนได้ คือหัว
                text: 'กรุณากรอกโหนดที่ต้องการค้นหาใหม่ !',  // ข้อความที่แสดง
                type: 'error', // อันนี้คือประเภทว่าจะให้เป็นแบบไหน
                timer: 3000
            })
        }
        function errorSearch() {
            swal.fire({
                title: 'กรุณากรอกโหนดที่ต้องการค้นหา !',  //สิ่งที่เปลี่ยนได้ คือหัว
                type: 'warning', // อันนี้คือประเภทว่าจะให้เป็นแบบไหน
                timer: 2000
            })
        }
        function errorMode() {
            swal.fire({
                title: 'กรุณาเลือกโหมดการค้นหา !',  //สิ่งที่เปลี่ยนได้ คือหัว
                type: 'warning', // อันนี้คือประเภทว่าจะให้เป็นแบบไหน
                timer: 2000
            })
        }
    </script>

</head>
<body class="h-100">
    <form id="mainform" runat="server">
        <div class="container-fluid">
            <div class="row">
                <main class="main-content col-lg-10 col-md-9 col-sm-12 p-0 offset-lg-1 offset-md-2">
                    <div class="main-navbar bg-white">
                        <!-- Main Navbar -->
                        <nav class="navbar align-items-stretch navbar-light flex-md-nowrap p-0">
                            <div class="input-group input-group-seamless ml-3">
                                <div class="input-group-prepend">
                                    <div class="input-group-text headTitle">
                                        <img src="images/icon/rmuti.ico" width="40px" />
                                        <b style="margin-top: 15px;">RAJAMANGALA UNIVERSITY OF TECHNOLOGY ISAN</b>
                                    </div>
                                </div>
                            </div>
                            <ul class="navbar-nav  flex-row ">
                                <li class="nav-item dropdown">
                                    <a class="nav-link dropdown-toggle text-nowrap px-3" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false"  >
                                        <img class="user-avatar rounded-circle mr-2" src="images/avatars/pro.jpg" alt="User Avatar">
                                        <span class="d-none d-md-inline-block" style="margin-top: 15px;" data-toggle="tooltip" data-placement="bottom" title="เกี่ยวกับเรา">CPE.59241 / Group 9</span>
                                    </a>
                                    <div class="dropdown-menu dropdown-menu-small">
                                        <a class="dropdown-item" href="https://www.facebook.com/Fluke.Kittikorn.B" target="_blank">
                                            <span data-toggle="tooltip" data-placement="right" title="59172110122-0"><i class="fab fa-facebook"></i>&ensp; KITTIKORN BUNJONGPRU</span></a>
                                        <a class="dropdown-item" href="https://www.facebook.com/pcshadows" target="_blank">
                                            <span data-toggle="tooltip" data-placement="right" title="59172110214-1"><i class="fab fa-facebook"></i>&ensp; YUTTHASARD NORKHUNTOD</span></a>
                                        <a class="dropdown-item" href="https://www.facebook.com/bank.tawonsan" target="_blank">
                                             <span data-toggle="tooltip" data-placement="right" title="59172110223-9"><i class="fab fa-facebook"></i>&ensp; PAKORN TAWANSAN</span></a>
                                        <a class="dropdown-item" href="https://www.facebook.com/kanjana.vingpimay" target="_blank">
                                             <span data-toggle="tooltip" data-placement="right" title="59172110441-3"><i class="fab fa-facebook"></i>&ensp; KANJANA VINGPIMAY</span></a>
                                    </div>
                                </li>
                            </ul>
                        </nav>
                    </div>
                    <!-- main-navbar -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="1000" Enabled="False" />
                    <asp:UpdatePanel ID="GeneticPanel" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" />
                        </Triggers>
                        <ContentTemplate>
                            <div class="main-content-container container-fluid px-4">
                                <!-- Page Header -->
                                <div class="page-header row no-gutters py-4">
                                    <div class="col-12 col-sm-4 text-center text-sm-left mb-0">
                                        <h3 class="page-title">GENETIC ALGORITHM</h3>
                                        <span class="text-uppercase page-subtitle">&nbsp;Artificial Intelligence</span>
                                    </div>
                                </div>
                                <!-- End Page Header -->
                                <!-- Feed -->
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 col-sm-12 mb-4">
                                        <div class="card card-small card-post card-post--1">
                                            <div class="card-post__image" style="background-image: url('images/dna-string.jpg');">
                                                <a href="#" class="card-post__category badge badge-pill badge-dark">Algorithm</a>
                                                <div class="card-post__author d-flex">
                                                    <a href="#" class="card-post__author-avatar card-post__author-avatar--small" style="background-image: url('images/icon/DNA Helix_48px.ico');">Written by Anna Kunis</a>
                                                </div>
                                            </div>
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <a class="text-fiord-blue" href="#">ขั้นตอนวิธีเชิงพันธุกรรม (Genetic Algorithm: GA)</a>
                                                </h5>
                                                <p class="card-text d-inline-block mb-3">
                                                    ถูกคิดขึ้นในปี ค.ศ. 1960 โดย John Holland
                        เป็นเทคนิคการเรียนรู้ ที่ทำการค้นหาคำตอบของปัญหาโดยการเลียนแบบการคัดเลือกทางธรรมชาติและธรรมชาติทางพันธุกรรม 
                        โดยอาศัยหลักการสุ่มทางสถิติ (Stochastic) ...
                                                </p>
                                                <span class="text-muted">12 June 2019</span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Feed -->
                                    <!--Status -->
                                    <div class="col-lg-3 col-md-6 col-sm-12 mb-4">
                                        <div class="card card-small h-100">
                                            <div class="card-header border-bottom">
                                                <h6 class="m-0">Status</h6>
                                            </div>
                                            <div class="card-footer ">
                                                <div class="progress-wrapper">
                                                    <strong class="text-muted d-block mb-2">Finish Function : </strong>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <img src="images/icon/Variable_48px.png" width="35px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <span data-toggle="tooltip" data-placement="right" title="ฟังก์ชันที่ต้องการหาค่า"><b>y = 15x - x^2</b></span>
                                                </div>
                                            </div>
                                            <div class="card-footer border-top">
                                                <div class="progress-wrapper">
                                                    <strong class="text-muted d-block mb-2">Loop : </strong>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <img id="imgLoop" runat="server" src="images/ezgif.com-crop_1.png" style="width:35px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <b>
                                     <asp:Label ID="lbl_loop" runat="server" CssClass="Loop"><span data-toggle="tooltip" data-placement="right" title="รอบที่ทำงาน">0</span></asp:Label></b>
                                                </div>
                                            </div>
                                            <div class="card-footer border-top">
                                                <div class="progress-wrapper">
                                                    <strong class="text-muted d-block mb-2">ค่า X สูงสุด : </strong>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="images/icon/Signal_48px.png" width="35px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <b>
                                    <asp:Label ID="lbl_max_X" runat="server" CssClass="Loop" ><span data-toggle="tooltip" data-placement="right" title="ค่า X สูงสุด">0</span></asp:Label></b>
                                                </div>
                                            </div>
                                            <div class="card-footer border-top">
                                                <div class="progress-wrapper">
                                                    <strong class="text-muted d-block mb-2">completed</strong>
                                                    <div class="progress" style="height: 10px;">
                                                        <div runat="server" id="process" class="progress-bar progress-bar-striped progress-bar-animated bg-info" role="progressbar">
                                                            <asp:Label ID="lbl_process" runat="server" ></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Status -->
                                    <!-- Control -->
                                    <div class="col-lg-6 col-md-12 col-sm-12 mb-4">
                                        <div class="card card-small h-100">
                                            <div class="card-header border-bottom">
                                                <h6 class="m-0">Control</h6>
                                            </div>
                                            <div class="card-header border-bottom text-center">
                                                <center>
                                                    <img height="150px" src="images\dna-rna-double-helix-rotating-animation-5-2.gif">
                                                    <img height="150px" src="images\dna-rna-double-helix-rotating-animation-5-3.gif"> </img></img></center>
                                            </div>
                                            <ul class="list-group list-group-flush">
                                                <li class="list-group-item p-3">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="form-row">
                                                                <div class="form-group col-md-4">
                                                                    <label for="">
                                                                        Cossover Rate : (PC)</label>
                                                                    <asp:TextBox ID="txb_coss_rate" runat="server" CssClass="form-control" max="1" min="0" placeholder="0 - 1" required="" step="0.1" type="number" value="0.5" data-toggle="tooltip" data-placement="bottom" title="อัตราการไคว้โครโมโซม"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group col-md-4">
                                                                    <label for="">
                                                                        Mutation Rate : (PM)</label>
                                                                    <asp:TextBox ID="txb_mu_rate" runat="server" CssClass="form-control" max="1" min="0" placeholder="0 - 1" required="" step="0.1" type="number" value="0.1" data-toggle="tooltip" data-placement="bottom" title="อัตราการกลายพันธุ์"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group col-md-4">
                                                                    <label for="">
                                                                        Generation :
                                                                    </label>
                                                                    <asp:TextBox ID="txb_gen" runat="server" CssClass="form-control" min="1" placeholder="&gt; 1" required="" step="1" type="number" value="20" data-toggle="tooltip" data-placement="bottom" title="จำนวนรุ่นโครโมโซม"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <hr color="#FFFFFF" width="100%">
                                                                <p>
                                                                    <center>
                                                                    <asp:Button ID="btn_gen" runat="server" CssClass="mb-2 btn btn-success btn-pill mr-2" OnClick="btn_gen_Click" Text="&nbsp;&nbsp;&nbsp;&nbsp;Auto&nbsp;&nbsp;&nbsp;&nbsp;" data-toggle="tooltip" data-placement="top" title="ทำงานแบบอัตโนมัติ"/>
                                                                    <asp:Button ID="btn_next" runat="server" CssClass="mb-2 btn btn-secondary btn-pill mr-2" Text="&nbsp;&nbsp;Manual&nbsp;&nbsp;" OnClick="btn_next_Click" data-toggle="tooltip" data-placement="top" title="ทำงานแบบกำหนดเอง"/>
                                                                    <asp:Button ID="btn_cencle" runat="server" CssClass="mb-2 btn btn-danger btn-pill mr-2" OnClick="btn_cencle_Click" Text="&nbsp;&nbsp;&nbsp;Reset&nbsp;&nbsp;&nbsp;" data-toggle="tooltip" data-placement="top" title="ยกเลิกการทำงาน"/>
                                                                </center>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Control -->
                                <div class="row">
                                    <!-- Table 1 -->
                                    <div class="col-lg-12 col-md-12 col-sm-12 mb-4">
                                        <div class="card card-small">
                                            <div class="card-header border-bottom">
                                                <h6 class="m-0 tb_head">การคัดเลือก (Selection)</h6>
                                            </div>
                                            <div class="card-body p-0 pb-3 text-center">
                                                <div class="table-responsive">
                                                    <asp:Table ID="TB1H" runat="server" CellSpacing="0" CssClass="table table-striped mb-0 tb_data">
                                                        <asp:TableHeaderRow CssClass="bg-light">
                                                            <asp:TableHeaderCell Text="ลำดับ" CssClass="border-0" Width="8%" />
                                                            <asp:TableHeaderCell Text="โคโมโซม" CssClass="border-0" Width="12%" />
                                                            <asp:TableHeaderCell Text="X" CssClass="border-0" Width="7%" />
                                                            <asp:TableHeaderCell Text="ความเหมาะสม (F)" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="ความน่าจะเป็น (Pselect)" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="จำนวนที่คาดหวัง (Ei)" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="ความถี่สะสมความน่าจะเป็น (qi)" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="เลขสุ่มในการหมุนวงล้อ (r)" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="ลำดับโครโมโซมที่ถูกเลือก" CssClass="border-0" />
                                                        </asp:TableHeaderRow>
                                                    </asp:Table>
                                                    <asp:Table ID="Table1" runat="server" CellSpacing="0" CssClass="table table-striped mb-0 tb_data">
                                                    </asp:Table>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                    <!-- End Table 1 -->
                                    <!-- Table2 -->
                                    <div class="col-lg-12 col-md-12 col-sm-12 mb-4">
                                        <div class="card card-small">
                                            <div class="card-header border-bottom">
                                                <h6 class="m-0 tb_head">การไขว้เปลี่ยน (Crossover)</h6>
                                            </div>
                                            <div class="card-body p-0 pb-3 text-center">
                                                <div class="table-responsive">
                                                    <asp:Table ID="TB2H" runat="server" CellSpacing="0" CssClass="table table-striped mb-0 tb_data">
                                                        <asp:TableHeaderRow CssClass="bg-light">
                                                            <asp:TableHeaderCell Text="ลำดับที่คัดเลือก" CssClass="border-0" Width="8%" />
                                                            <asp:TableHeaderCell Text="Mating Pool" CssClass="border-0" Width="10%" />
                                                            <asp:TableHeaderCell Text="สุ่มจับคู่ (พ่อ-แม่)" CssClass="border-0" Width="10%" />
                                                            <asp:TableHeaderCell Text="เลขสุ่ม (r)" CssClass="border-0" Width="10%" />
                                                            <asp:TableHeaderCell Text="ก่อนครอสโอเวอร์" CssClass="border-0" Width="15%" />
                                                            <asp:TableHeaderCell Text="สุ่มตำแหน่ง (pos)" CssClass="border-0" Width="15%" />
                                                            <asp:TableHeaderCell Text="หลังคลอสโอเวอร์" CssClass="border-0" Width="15%" />
                                                            <asp:TableHeaderCell Text="X" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="ความเหมาะสม (F)" CssClass="border-0" Width="10%" />
                                                            <asp:TableHeaderCell Text="ลำดับโคโมโซมลูก" CssClass="border-0" Width="8%" />
                                                        </asp:TableHeaderRow>
                                                    </asp:Table>
                                                    <asp:Table ID="Table2" runat="server" CellSpacing="0" CssClass="table table-striped mb-0 tb_data">
                                                    </asp:Table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Table2 -->
                                    <!-- Table3 -->
                                    <div class="col-lg-12 col-md-12 col-sm-12 mb-4">
                                        <div class="card card-small">
                                            <div class="card-header border-bottom">
                                                <h6 class="m-0 tb_head">การกลายพันธุ์ (Mutation)</h6>
                                            </div>
                                            <div class="card-body p-0 pb-3 text-center">
                                                <div class="table-responsive">
                                                    <asp:Table ID="TB3H" runat="server" CellSpacing="0" CssClass="table table-striped mb-0 tb_data">
                                                        <asp:TableHeaderRow CssClass="bg-light">
                                                            <asp:TableHeaderCell Text="ลำดับ" CssClass="border-0" Width="8%" />
                                                            <asp:TableHeaderCell Text="ก่อนมิวเตชัน" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="เลขสุ่ม (r)" CssClass="border-0" Width="50%" />
                                                            <asp:TableHeaderCell Text="หลังมิวเตชัน" CssClass="border-0" />
                                                            <asp:TableHeaderCell Text="X" CssClass="border-0" Width="6%" />
                                                            <asp:TableHeaderCell Text="ความเหมาะสม (F)" CssClass="border-0" Width="10%" />
                                                        </asp:TableHeaderRow>
                                                    </asp:Table>
                                                    <asp:Table ID="Table3" runat="server" CellSpacing="0" CssClass="table table-striped mb-0 tb_data">
                                                    </asp:Table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Table3 -->
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <footer class="main-footer d-flex p-2 px-3 bg-white border-top">
                    <span class="copyright ml-auto my-auto mr-2">Copyright © 2019. Create By Generation1Studio Inc, CPE#8 RMUTI Korat.</span>
                    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
                    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
                    <script src="https://unpkg.com/shards-ui@latest/dist/js/shards.min.js"></script>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/Sharrre/2.0.1/jquery.sharrre.min.js"></script>
                    <script src="scripts/extras.1.1.0.min.js"></script>
                    <script src="scripts/shards-dashboards.1.1.0.min.js"></script>
                    <script src="scripts/app/app-blog-overview.1.1.0.js"></script>
                    <script>
		                $(document).ready(function()
		                {
                            $('[data-toggle="tooltip"]').tooltip({ trigger: "hover" });
                            $('[data-toggle="tooltip"]').click(function () {
                              $('[data-toggle="tooltip"]').tooltip("hide");
                           });
		                });
	                </script>
    </form>
</body>
</html>
