<?php
if(isset($_SESSION["user_id"]))
{
	header("location:index.php");
}
?>

<?php include "header.php"; 

?>

	<!-- Header -->
        <header>
        <div class="header-content">
            <div class="header-content-inner">
                <h1 style="color:#FF6600;font-size:80px;"><b>OrganiCrate<b></h2>
                <p><input type="text" class="form-control" id="search" style="border :solid 1px #FF6600;" placeholder="Search..."></p>
                <button class="btn btn-primary btn-lg" id="search_btn">Search Now</button>
            </div>
        </div>
    </header>
	
		<p><br/></p>
	

	<div class="container-fluid">
		<div class="row">
			<div class="col-md-1"></div>
			<div class="col-md-2">
				<div id="get_category">
				</div>
				
			</div>
			<div class="col-md-8 col-xs-12">
				<div class="row">
					<div class="col-md-12 col-xs-12" id="product_msg">
					</div>
				</div>

					<div class="panel-body">
						<div id="get_product">
							<!--Here we get product jquery Ajax Request-->
						</div>

					</div>
					
				</div>
			</div>
			
			<div class="row">
			<div class="col-md.12">
				<center>
					<ul class="pagination" id="pageno">
						<li><a href="#">1</a></li>

					</ul>
			</div>
			</div>
			

		</div>
	</div>
	
		<p><br/></p>
	
    <!-- jQuery -->   
			<div class="col-md-2"></div>

    <!-- Bootstrap Core JavaScript -->
	
	

</body>
<?php 
include "footer.php";
?>
<?php include "close.php"; ?>

</html>