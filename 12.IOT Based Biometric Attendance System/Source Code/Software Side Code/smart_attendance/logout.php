<?php
session_start();
	if (isset($_SESSION['user'])) {
    	if ($_SESSION['user']=='admin') {
        	session_destroy();
        	echo "<script> window.location.href='index.php'; </script>";
        }
    }
?>