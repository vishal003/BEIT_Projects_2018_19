<?php
	include('header.php');
?>
<div class="container">
	<div class="content_box">
	<?php
		include('../connect.php');
		$id=$_GET['id'];
		$runquery = "SELECT * FROM blog_post WHERE blog_id=$id";
		$fetchquery = mysqli_query($conn,$runquery);
		while($rows = mysqli_fetch_array($fetchquery))
		{
	
		echo'<div class="content_heading">'.$rows['blog_title'].
		'</div>';
		echo'<span class="date">'.$rows['date'].'</span><br>';
		echo'<span class="name">'.$rows['blog_name'].'</span><br>';
		echo'<div class="content">'
		.$rows['blog_description'].'</div>';
		}?>
	</div>
</div>	