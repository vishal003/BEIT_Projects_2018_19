<?php include "header.php";?>
<?php include "action.php";?>
<?php 
include ('db.php');
?>
<link href="css/rate.css" rel="stylesheet">

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
  .checked {
    color: orange;
  }
  .name-header{
    color: #006622;
    font-weight: bold;
    font-family: Verdana;
    font-size: 20pt;
  }
  .review-font{
    color: #006622;
    font-weight: normal;
    font-family: Bookman Old Style;
    font-size: 12pt;
  }
  .fa-star { color: green; }
</style>
<?php $pro_id=$_GET['product_id'];?>
<br><br><br>
 <?php

                    
                    //$pro_id=$_GET['product_id'];

                    
                    $SqlQueryRun=mysqli_query($con,"SELECT * FROM addproduct  WHERE product_id='$pro_id'");
                    $sqlrun=mysqli_query($con,"SELECT * FROM farmers WHERE farmer_id IN (SELECT farmer_id FROM addproduct WHERE product_id='$pro_id')");
                    
              
                    $rows=mysqli_fetch_array($sqlrun);
                    
                    $fname=$rows['f_name'];
                    $contact=$rows['mobile'];
                  
                    while($rows=mysqli_fetch_array($SqlQueryRun))
                    {
                      $pro_cat=$rows['product_cat'];
          ?>
          
          
    <div class="container">
      <div class="col-md-12 ">
            <div class="row">
              <div class="col-md-12" id="product_msg"></div>
            </div>
          </div>
      
      <div class="row">
        <div class="col-md-5">
        &nbsp;&nbsp;<h1><?php echo $rows['product_title']; ?></h1>
			  <?php echo "<img class='cimg' src='farmer_images/".$rows['product_image']."' style='width:60%; height:auto;'/> "?>
        </div>
        <div class="col-md-7">
            <br><br>
            <p class="lead"><b>Owner</b></p>
            <p>Farmer name :<?php echo $fname;?></p>
            <p>Farmer contact no :<?php echo $contact; ?></p><br>
            <p class="lead"><b>Description</b></p>
            <p><?php echo $rows['product_desc']; ?></p><br>
            <p class="lead"><b>Price </b></p>
            <p><?php echo $rows['product_price']; ?> Rs</p>

            <form action="">
              <!-- Default input -->
              <input type="number" value="1" class="input-sm" style="width:20%">
              <?php echo "<button  class='btn btn-primary' pid='$pro_id' id='product' type='submit'>Add to cart"?>
                <i class="glyphicon glyphicon-shopping-cart"></i>
              </button>
            </form>
        </div>
          <?php } ?>
       <!-- <div class="col-md-3"></div>-->
                   <br><br>
            <?php 
            echo"<hr></hr>";
            echo"<h3 style='color:#59B210;'>Recommended Products</h3><hr></hr>";
              $sqlrunsimilar=mysqli_query($con,"SELECT * FROM addproduct WHERE product_id <> '$pro_id' AND product_id IN(SELECT product_id FROM recommendation ORDER BY rating DESC) LIMIT 3;");
              while($rows=mysqli_fetch_array($sqlrunsimilar))
                    {
                      $pro_id=$rows['product_id'];
           ?>
           <div class="col-md-4">
                       

              <div class='cards'>
                <?php echo "<img class='cimg' src='farmer_images/".$rows['product_image']."' style='width:100%; height:auto;'/>";?>
                <?php echo $rows['product_title']; ?><br>
                <?php echo $rows['product_price']; ?> Rs<br>
                <?php echo "<button pid='$pro_id' id='product' class='act_btn 'style='width:103px;'>Add To Cart</button>";?>
                <?php echo "<a href='view.php?product_id=$pro_id'><button pid='$pro_id' class='act_btn' >View</button></a>";?>
              </div>  
          
        </div>
        <?php }
                  //include ('../close.php');
                  ?>


          
          <br><br>
            <?php 
            echo"<hr></hr>";
            echo"<h3 style='color:#59B210;'>You May Also Buy</h3><hr></hr>";
              $sqlrunsimilar=mysqli_query($con,"SELECT * FROM addproduct WHERE product_cat='$pro_cat' AND product_id <> '$pro_id' ORDER BY RAND() LIMIT 3;");
              while($rows=mysqli_fetch_array($sqlrunsimilar))
                    {
                      $pro_id=$rows['product_id'];
           ?>
           <div class="col-md-4">
                       

              <div class='cards'>
                <?php echo "<img class='cimg' src='farmer_images/".$rows['product_image']."' style='width:100%; height:auto;'/>";?>
                <?php echo $rows['product_title']; ?><br>
                <?php echo $rows['product_price']; ?> Rs<br>
                <?php echo "<button pid='$pro_id' id='product' class='act_btn 'style='width:103px;'>Add To Cart</button>";?>
                <?php echo "<a href='view.php?product_id=$pro_id'><button pid='$pro_id' class='act_btn' >View</button></a>";?>
              </div>  
          
        </div>
        <?php }
                  //include ('../close.php');
                  ?>

           

      </div>
	  </div>

<?php
 //$pro_id=$_GET['product_id'];
    $pro_id=$_GET['product_id']; 
      
?>
  <br>
  <div class="container">
    <div class="col-md-12 ">
            <div class="row">
            </div>
          </div>
    <ul class="nav nav-tabs">
      <li class="active"><a data-toggle="tab" href="#review">Review & Ratings</a></li>
      <li><a data-toggle="tab" href="#feedback">Give Review </a></li>
    </ul>
    <div class="tab-content">
      <div id="review" class="tab-pane fade in active">
        <h1><div class="name-header">Reviews</div></h1>
        <?php
            $fetchfd = "SELECT * FROM review where product_id=$pro_id";
            $run_query = mysqli_query($con,$fetchfd);
            if(mysqli_num_rows($run_query) > 0)
              {
                  while($row = mysqli_fetch_array($run_query))
                  {
                      $user_id  = $row['user_id'];
                      $rating   = $row['rating']; 
                      $review   = $row['review'];
                      
                      $sql="SELECT first_name FROM users WHERE user_id IN(SELECT user_id FROM review WHERE user_id='$user_id')";
                      $fetch_query = mysqli_query($con,$sql);
                      if(mysqli_num_rows($run_query) > 0)
                      {
                          while($row = mysqli_fetch_array($fetch_query))
                          {
                              $user_name=$row['first_name'];                                    
                          }
                      }
                      echo "$rating<i class='fa fa-star'></i>
                      <div class='review-font'>$review</div>
                      <hr style='width:40%;height:auto;'>";

                  }
              }
        ?>
        
      </div>

      <div id="feedback" class="tab-pane fade">
        <div class="signup-form">
          <form action="feed_action.php"  method="get">
              <div class="rate">
                    
                    <input type="radio" id="star5" name="rate" value="5" />
                    <label for="star5" >5 stars</label>
                    <input type="radio" id="star4" name="rate" value="4" />
                    <label for="star4" >4 stars</label>
                    <input type="radio" id="star3" name="rate" value="3" />
                    <label for="star3" >3 stars</label>
                    <input type="radio" id="star2" name="rate" value="2" />
                    <label for="star2" >2 stars</label>
                    <input type="radio" id="star1" name="rate" value="1" />
                    <label for="star1" >1 star</label>
              </div>
            <br><br>
            <div class="form-group">
                  <textarea name="feedback" id="fd" cols="45" rows="3" placeholder="Giver your Review Here..." style="box-shadow: 0px 2px 2px 2px;"></textarea>
            </div>
            <div class="form-group">
                 <input type="hidden" name="product_id" value="<?php echo $pro_id;?>" >
            </div>
            <div class="form-group">
                  <button type="submit" name="feed" class="btn btn-success btn-lg btn-block signup-btn">Submit Your Review</button>
                  
              </div>
          </form>
          
      </div>
    </div>
  </div>
</div>



<br><br><br><br><br>
		
<?php include "footer.php";?>
<?php
 
//    }
//}
// mysqli_close($con);
//exit;
?>