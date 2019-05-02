<!DOCTYPE html>
<?php 
require 'connection_demo.php';


session_start();
if (strlen($_SESSION['user'])==0  && $_SESSION['user']!="admin") {
    header('Location:index.php');
}

global $connect;
	$query="SELECT (user_id+1) as user_id FROM users ORDER BY user_id DESC LIMIT 1;";
	$result=mysqli_query($connect,$query);
    $row=mysqli_fetch_assoc($result);
    $user_id=$row['user_id'];
    
?>

<html>
<head>
<meta charset="ISO-8859-1">
<title><?php echo"$project_name"; ?></title>

	<link rel="stylesheet" href="assets/css/bootstrap.min.css">

	<link rel="stylesheet" href="assets/css/font-awesome.min.css">

	<!-- Custom styles for our template -->

	<link rel="stylesheet" href="assets/css/bootstrap-theme.css" media="screen">

	<link rel="stylesheet" href="assets/css/style.css">

	<link rel="stylesheet" href="css/style.css" type="text/css">


</head>
<body class="text-secondary my-body-background-color"  onload="doubleAttendanceAlert();">

	<div id="chk_double_att" ></div>
	<?php include('header.php'); ?>
	<?php include('nav_bar.php'); ?>

<br/>
    <div class="container" >
    	<div style="width: 100%;background-color: #fff;">

    		<div style="background-color: #9da4cf;padding: 20px 10px">
    		
            	<h3 style=" text-transform: uppercase;text-align: center;margin: 0;padding: 0; color: #2b3187">Register Student</h3>

            </div>
            

            <div style="padding: 1%">
            	<br/>

				<div class="row">

					<div class="col-md-12">

						


						<form class="form-light mt-20" role="form"  method="post" action="add_student.php">

							<div class="col-md-4">


								<div class="col-md-6" style="padding: 0px">

									<div class="form-group">

										<label style="color:#2b3187">Student ID</label>

										<input type="text" id="get_id" class="form-control readonly" name="s_id" required>

										<!-- placeholder="<?php echo(strlen($user_id)!=0? $user_id: '1') ?>" -->

									</div>

								</div>


								<div class="col-md-6" >

									<div class="form-group">

										<label style="color:#2b3187;">&nbsp;</label>

										<input type="button"  class="btn btn-two form-control" style="background-color: #9da4cf" value="Check" onclick="getRegistrationId();" />

									</div>

								</div>

							<div class="form-group">

								<label style="color:#2b3187">Enter Student Name</label>

								<input type="text" class="form-control" placeholder="Student Name" name="s_name" required>

							</div>


							<div class="form-group">

								<label style="color:#2b3187">Select Department</label>

								<select type="text" class="form-control" placeholder="Department" name="s_dept" required>
									<option value="">Select Department</option>
									<option value="Information technology">Information technology</option>
							        <option value="Computer Science">Computer Science</option>
							        <option value="EXTC. Electronics">EXTC. Electronics</option>
							        <option value="Mechanical Electrical">Mechanical</option>
							        <option value="Mechanical Electrical">Electrical</option>
							    </select>

							</div>

							</div>
						

							<div class="col-md-4">

							<div class="form-group">

								<label style="color:#2b3187">Enter Behaviour</label>

								<select type="text" class="form-control" placeholder="Behaviour" name="s_behav" required>
									<option value="">Select Behaviour</option>
									<option value="Very good">Very good</option>
							        <option value="Good">Good</option>
							        <option value="Bad">Bad</option>
							    </select>

							</div>

							<div class="form-group">

								<label style="color:#2b3187">Enter Year</label>

								<select type="text" class="form-control" placeholder="Year" name="s_year" autocomplete="off" required>
									<option value="">Select Year</option>
									<?php $date=date("Y"); ?>
									<option value="<?php echo "".$date ?>"><?php echo "".$date ?></option>
							    </select>

							</div>


							</div>

							<div class="col-md-4">

							<div class="form-group">

								<label style="color:#2b3187">Enter Email ID</label>

								<input type="email" class="form-control" placeholder="Email ID" name="s_email" autocomplete="off" pattern="[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{1,63}$" oninvalid="setCustomValidity('Please enter valid email')" required>

							</div>


							<div class="form-group">
								<div>
								<label style="color:#2b3187">Enter Mobile Number</label>
								</div>
								<div class="col-md-2" style="padding: 0px">
									<input type="tel" class="form-control" placeholder="+91" readonly="true" required>
								</div>
								<div class="col-md-10" style="padding: 0px">
									<input type="tel" class="form-control" placeholder="Mobile Number" maxlength="10" minlength="10"  pattern="[0-9]{10}" name="s_mobile" autocomplete="off" oninvalid="setCustomValidity('Please enter valid number')" onchange="setCustomValidity('')" required>
								</div>

							</div>

							</div>


							<div class="col-md-8">

							<div class="form-group">

								<label style="color:#2b3187">Enter Address</label>

								<input type="text" class="form-control" placeholder="Address" name="s_address" autocomplete="off" required>

							</div>

							</div>
							
							<div class="col-md-12">
							<center><button type="submit" class="btn btn-two" style="background-color: #9da4cf">Add Student</button></center>
							<p><br/></p>
							</div>
							

						</form>

					

					</div>

				</div>

			</div>
		</div>
			
				
	</div>


<script type="text/javascript" src="jquery-3.2.1.min.js"></script>

<script type="text/javascript">
    
    function getRegistrationId(){
    	$.ajax({
            type:'post',
            url:'get_id.php',
            success:function(response){ 
                $("#get_id").html(response);
            }              
       	});    
    }

    var t;
    function doubleAttendanceAlert(){
    $.ajax({
        type:'post',
        url:'check_double_attendance.php',
        success:function(response){ 
        	$("#chk_double_att").html(response);
            t=setTimeout(doubleAttendanceAlert, 500);                                      
            }              
        });    
    }

	$(".readonly").keydown(function(e){
        e.preventDefault();
    });
</script>


</body>
</html>