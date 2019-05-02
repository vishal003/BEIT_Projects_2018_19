<?php
include'connection_demo.php';

session_start();
if (strlen($_SESSION['user'])==0  && $_SESSION['user']!="admin") {
    header('Location:index.php');
}

$user_id="none";
$user_name="none";
$department="none";
$attendance="none";
$percentage="none";
$behavior="none";

$email_id="none";
$mobile_no="none";
$address="none";
$year="none";

global $connect;

$student_id=$_SESSION['sid'];
if (strlen($student_id)==0) {
    header('Location:index.php');
}
else{
    $current_week=date('W');
    $query="SELECT a.user_id ,u.user_name,u.department, count(a.user_id) as attendance,ROUND( ( (  COUNT( a.user_id ) / 40 ) * 100 ),2)as percentage,u.behavior,u.email_id,u.mobile_no,u.address,u.year FROM attendance_info a INNER JOIN users u ON a.user_id=u.user_id AND a.user_id='$student_id' AND a.a_flag='2' AND a.week='$current_week' ;";

    $result=mysqli_query($connect,$query);
    $no_of_row=mysqli_num_rows($result);

    if($no_of_row>0){

        $row=mysqli_fetch_assoc($result);
        $user_id=$row['user_id'];
        if($user_id==$student_id){
        $user_name=$row['user_name'];
        $department=$row['department'];
        $attendance=$row['attendance'];
        $percentage=$row['percentage']."%";
        $behavior=$row['behavior'];
        $email_id=$row['email_id'];
        $mobile_no=$row['mobile_no'];
        $address=$row['address'];
        $year=$row['year'];
         
        }
        else{
           $query2="SELECT user_id , user_name, department, (0) as attendance,(0.00)as percentage, behavior,email_id,mobile_no,address,year FROM users WHERE user_id='$student_id' ";

        $result2=mysqli_query($connect,$query2);
        $no_of_row2=mysqli_num_rows($result2);

        $row2=mysqli_fetch_assoc($result2);
        
        $user_id=$row2['user_id'];
        $user_name=$row2['user_name'];
        $department=$row2['department'];
        $attendance=$row2['attendance'];
        $percentage=$row2['percentage']."%";
        $behavior=$row2['behavior'];
        $email_id=$row2['email_id'];
        $mobile_no=$row2['mobile_no'];
        $address=$row2['address'];
        $year=$row2['year']; 
        }
    }
}


?>
<html>
<head>
    <title><?php echo"$project_name"; ?></title>
    <!--<meta http-equiv="refresh" content="5" />-->
    
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">
    <!-- Custom styles for our template -->
    <link rel="stylesheet" href="assets/css/bootstrap-theme.css" media="screen">
    <link rel="stylesheet" href="assets/css/style.css">

    <link rel="stylesheet" href="css/style.css" type="text/css">

    <link rel="stylesheet" href="css/table.css" type="text/css">

   

</head>
<body class="my-backgroud-color my-body-background-color">

    <?php include('header.php'); ?>
    <?php include('nav_bar.php'); ?>
    
  
    <table class="data-table">
        <caption class="title"></caption>
        <thead>
            <tr > 

                <th colspan="3" style="color: #2b3187;text-align: center;"> Student Details </th>
            
            </tr>
        </thead>
        <tbody>
            
            <tr>
                <th>Student ID</th>
                <td align="right"> <?php echo "$user_id"; ?> </td>
                <th rowspan="10"><img src="images/image4.png" /></th>
            </tr>
            <tr> 
                <th>Name</th> 
                <td><?php echo "$user_name";  ?></td>
            </tr>

             <tr> 
                <th>Department </th> 
                <td><?php echo "$department"; ?></td>
            </tr>

             <tr> 
                <th>Attandance</th> 
                <td><?php echo "$attendance"; ?></td>
            </tr>

            <tr> 
                <th>Percentage</th> 
                <td><?php echo "$percentage"; ?></td>
            </tr>

            <tr> 
                <th>Behaviour</th> 
                <td><?php echo "$behavior"; ?></td>
            </tr>

            <tr> 
                <th>Year</th> 
                <td><?php echo "$year"; ?></td>
            </tr>

            <tr>
                <th>Moblie No</th>
                <td> <?php echo "+91 "."$mobile_no"; ?> </td> 
                
            </tr>
            
            <tr> 
                <th>Email ID</th>
                <td> <?php echo "$email_id"; ?> </td>
            </tr>

            <tr> 
                <th>Address </th> 
                <td style="text-transform: uppercase;"><?php echo "$address"; ?></td>
            </tr>
            

        </tbody>       
    </table>
    
</body>
</html>
