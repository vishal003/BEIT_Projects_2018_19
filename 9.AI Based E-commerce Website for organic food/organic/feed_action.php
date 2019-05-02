    <?php 
    
    include "session.php";
if(isset($_GET["feed"]))
  {
	  include "db.php";
    $pro_id=$_GET["product_id"];
    $feedback = $_GET["feedback"];
    $rating = $_GET["rate"];

  
        if(isset($_SESSION["user_id"]))
        {
			
          $user_id = $_SESSION["user_id"];
          
          $sql = "INSERT INTO review(user_id,product_id,rating,review,review_timestamp) VALUES ('$user_id','$pro_id',$rating,'$feedback','".date("Y-m-d H:i:s")."' )";
          $result = mysqli_query($con, $sql);
		  
		  			 header('Location: ' . $_SERVER['HTTP_REFERER']);
			         exit;

 
        }
        else
        {

          /*echo "
            <div class='alert alert-success'>
              <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <b>Please&nbsp;<a href='login.php'>LogIn</a>&nbsp;First..!</b>
              </div>
            ";*/
            echo
              '<script type="text/javascript">
			  
              alert("Your Product Is Uploaded ....");
             
              </script>';
			  header('Location: ' . $_SERVER['HTTP_REFERER']);
			            exit;
          //exit();
          
        }
          

         
 }
 ?>

<?php include "close.php"; ?>

