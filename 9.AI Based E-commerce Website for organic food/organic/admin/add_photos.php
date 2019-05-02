<?php include('header.php');?>

<div class="container">
	<form method="post" action="picture-upload.php" enctype="multipart/form-data">

	<div class="col-md-3"></div>
	<div class="col-md-6">
	<div class="content_box">
		<input type="file" name="photo" class="btn1 btn">
		<select name="category" class="caption">
			<option value="select category">--Category--</option>
			<option value="street">Street Photography</option>
			<option value="nature">Nature Photography</option>
			<option value="portrait">portrait</option>
		</select><br>
		<label class="caption_heading">Caption :</label>
		<textarea name="caption" class="caption" rows="6" cols="68"></textarea><br>
		<input type="submit" value="Upload" name="upload" class="btn1 btn">
	</div>
	</div>
	</form>
</div>

     <!--<!--head-top
    <div class="content">
            <div class="container">
			
                <div class="cont-top">
				
					<!-- column video 				
                    <div class="col-md-4" style="background:#FF9966; padding:20px; border:1px solid #CFCFCF;"> 
						
                    <h3>UPLOAD PHOTO</h3>
                    <p>Image Supported : JPG, JPEG, BMP, PNG</p>

					<hr>

					<form method="POST" name="upload-picture-form" action="picture-upload.php" enctype="multipart/form-data">

					<div class="form-group">
						<label for="email_id">Select File</label>
						<div class="input-group1">
						<input type="file" id="file" name="file" class="form-control">
						</div>
					</div>
					
					<div class="form-group">
						<label for="title">Headline</label>
						<div class="input-group1">
						<input type="text" id="title" name="title" class="form-control" required="">
						</div>
					</div>
					<div class="form-group">
						<label for="title">Mobile No.</label>
						<div class="input-group1">
						<input type="text" id="mobile" name="mobile" class="form-control" required="">
						</div>
					</div>
					
					<!-- Button -->
					<!--<div class="form-group">
						<button id="btn-upload" name="btn-upload" class="btn btn-primary" style="padding:10px 20px;">Upload</button>
						
					</div>
					
					
					</form>
						
						
                    </div>-->
					