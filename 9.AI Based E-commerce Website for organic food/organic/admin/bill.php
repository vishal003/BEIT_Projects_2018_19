
<?php

error_reporting(E_ALL);
include "connect.php";

	//$GET='';
	if(isset($_GET["order_form"]))
	{ 
		
		$date=date('Y-m-d H:i:s');
		$cust_name=$_GET["cust_name"]; 
		$pro_name=$_GET["product_title"]; 
		$qty=$_GET["qty"];
		$units=$_GET["units"];
		$price=$_GET["price"];
		$total=$_GET["total"];
		$paid=$_GET["paid"];
		$due=$_GET["due"];
		$payment=$_GET["payment"];
		
	
	require "fpdf/fpdf.php";
	require "fpdf/font/helveticab.php";
 
	$pdf=new FPDF();
	
	$pdf->AddPage();
	
		$pdf->SetFont("Arial","B",26);
		$pdf->Cell(175,10,"OrganiCrate",0,1,"C");
		
		$pdf->SetFont("Arial",null,16);
		
		$pdf->Cell(50,10,"Date",0,0);
		$pdf->Cell(50,10,": ".$_GET["date"],0,1);
		
		$pdf->Cell(50,10,"Customer Name",0,0);
		$pdf->Cell(50,10,": ".$_GET["cust_name"],0,1);
		
		$pdf->Cell(50,10,"",0,1);
		
		$pdf->Cell(10,10,"#",1,0,"C");
		$pdf->Cell(70,10,"Product Name",1,0,"C");
		$pdf->Cell(25,10,"Quantity",1,0,"C");
		$pdf->Cell(25,10,"Units",1,0,"C");
		$pdf->Cell(25,10,"Price",1,0,"C");
		$pdf->Cell(25,10,"Total",1,1,"C");
		
		$pdf->Cell(50,10,"",0,1);
		
		$pdf->Cell(50,10,"Paid Rs.",0,0);
		$pdf->Cell(50,10,": ".$_GET["paid"],0,1);
		
		$pdf->Cell(50,10,"Due",0,0);
		$pdf->Cell(50,10,": ".$_GET["due"],0,1);
		
		$pdf->Cell(50,10,"Payment",0,0);
		$pdf->Cell(50,10,": ".$_GET["payment"],0,1);
		
		$pdf->Cell(180,10,"Signature",0,0,"R");
		
		
		
	
	$pdf->Output();
	
	
}
	$sql="INSERT INTO invoices(date,cust_name,product_title,qty,units,price,total,paid,due,payment)VALUES('$date','$cust_name','$pro_name','$qty','$units','$price','$total','$paid','$due','$payment')";
	
		$sql	=	mysqli_query($conn, $sql);
	

?>