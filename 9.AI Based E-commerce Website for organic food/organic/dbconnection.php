<?php
$db = new PDO('mysql:host=localhost;dbname=organic;','root','',
        array(PDO::ATTR_EMULATE_PREPARES => false, 
            PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION));
?>