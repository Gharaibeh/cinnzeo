 <?php
     $file = $_FILES["file"];
 
     if (!empty($file))
	 {
		 echo "Got file";
		 move_uploaded_file($_FILES["file"]["tmp_name"], "Images/" . $_FILES["file"]["name"]);
         echo "Stored in: " . "Images/" . $_FILES["file"]["name"];
	 }
     else
         echo "Failed to get File";
 ?>