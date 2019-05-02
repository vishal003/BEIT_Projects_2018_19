<!DOCTYPE html>

<?php 
include'connection_demo.php';

session_start();
if (strlen($_SESSION['user'])==0  && $_SESSION['user']!="admin") {
    header('Location:index.php');
}

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

	<script type="text/javascript" src="js/jquery.min.js"></script>
	<script type="text/javascript" src="js/Chart.min.js"></script>

</head>
<body class="text-secondary" style="background-color: #EEEEEE;"  style="margin: auto;" onload="changeGraph();showGraph()" >

	<?php include('header.php') ?>
	<?php include('nav_bar.php'); ?>
	<br/>

    <div class="my-center-container" >
    	<div style="width: 50%;background-color: #fff;">

    		<div style="background-color: #9da4cf;padding: 30px 10px">
    		
            	<h3 style=" text-transform: uppercase;text-align: center;margin: 0;padding: 0; color: #2b3187">Graph</h3>

                <div class="col-md-4">
                <div class="form-group">

                    <label style="color:#2b3187">Select %</label>

                        <select id="percentage" type="text" class="form-control" placeholder="Behaviour" name="s_behav" onchange="showGraph()" required>
                            <option value="0">Select</option>
                            <option value="75">75%</option>
                            <option value="60">60%</option>
                            <option value="50">50%</option>
                        </select>

                </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">

                    <label style="color:#2b3187">Select Month</label>

                        <select id="month" type="text" class="form-control" placeholder="Behaviour" name="s_behav" onchange="showGraph()" required>
                            <?php 
                                $query = "SELECT DISTINCT(SUBSTR(date,4,7)) as month FROM attendance_info;";
                                $result = mysqli_query($connect,$query);
                                $no_of_row=mysqli_num_rows($result);
                                if($no_of_row>0){
                                    while($row=mysqli_fetch_assoc($result)){
                                        $mon=$row['month'];
                                        $monInText=date('F Y',strtotime("01-".$mon)); 
                                        echo "<option value='$mon'>$monInText</option>";
                                    }
    
                                }else{
                                    echo "<option value='no data'>No DATA</option>";
                                }

                                

                            ?>

                            <!-- <option value="01-2019">January</option>
                            <option value="02-2019">February</option>
                            <option value="03-2019">March</option>
                            <option value="04-2019">April</option>
                            <option value="05-2019">May</option>
                            <option value="06-2019">June</option>
                            <option value="07-2019">July</option>
                            <option value="08-2019">August</option>
                            <option value="09-2019">September</option>
                            <option value="10-2019">October</option>
                            <option value="11-2019">November</option>
                            <option value="12-2019">December</option> -->
                        </select>

                </div>
                </div>

                <div class="col-md-4">
                <div class="form-group">

                    <label style="color:#2b3187">Graph Type</label>

                        <select id="graph_type" type="text" class="form-control" placeholder="Behaviour" name="s_behav" onchange="changeGraph();showGraph()" required>
                            <option value="bar">Bar</option>
                            <option value="pie">Pie</option>
                            <option value="doughnut">Doughnut Pie</option>

                        </select>

                </div>
                </div>

            </div>
            

            <div style="padding: 1%">
            	<br/>

				<div class="row">

					<div class="col-md-12">

						<!-- graph view -->
						<div id="chart-container">
        					<canvas id="graphCanvas"></canvas>
    					</div>

					

					</div>

				</div>

			</div>
		</div>
			
				
	</div>

    <br><br>

<script>
        /*$(document).ready(function () {
            showGraph();
        });*/
        var graphTarget = $("#graphCanvas");
        var chartdata = {};
        var barGraph ;
        var graphBackgroundColor

        function changeGraph(){
            var graph_type = document.getElementById("graph_type").value;
            if( barGraph  != null){
                barGraph.destroy();
            }
            if(graph_type != 'bar'){
                graphBackgroundColor =["red", "blue", "green", "yellow", "orange", "pink"];
                //graphBackgroundColor = '#49e2ff';
            }
            else {
                graphBackgroundColor = '#49e2ff';
            }
            
            barGraph = new Chart(graphTarget, {
                        type: graph_type,
                        data: chartdata,
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
        }


        function showGraph()
        {
            var p = document.getElementById("percentage").value;
            var m = document.getElementById("month").value;
            
            
            
                $.post("graph_data.php",
                    {pr : p,month : m},
                function (data)
                {
                    console.log(data);
                     var name = [];
                    var attendance = [];

                    for (var i in data) {
                        name.push(data[i].user_name);
                        attendance.push(data[i].p);
                    }
                    /*name.push("");
                    attendance.push(0);*/

                    chartdata = {
                        labels: name,
                        datasets: [
                            {
                                label: 'Student Attendance',
                                backgroundColor: graphBackgroundColor,
                                /*borderColor: '#46d5f1',*/
                                hoverBackgroundColor: '#9da4cf',
                                hoverBorderColor: '#666666',
                                data: attendance
                            }
                        ]
                    };


                    barGraph.data = chartdata;
                    barGraph.update();
                    

                });

            
            
        }
</script>

</body>
</html>