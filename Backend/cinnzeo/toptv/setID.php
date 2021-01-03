 <?php
    
/*$servername = "imscorgau.ipagemysql.com";
$username = "hasan";
$password = "hasan";
$dbname = "comparemarket";*/
 

 $servername = "localhost";
$username = "user1";
$password = "SjuHp1egQTHLmUrO";
$dbname = "cinnzeo";

$conn = mysqli_connect($servername, $username, $password, $dbname);
 
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
 
 
   $deviceID= $_REQUEST['deviceID']; 
   
if ($deviceID != ""){   
 
$sql = "INSERT INTO tv_ids (device_id) VALUES ('$deviceID')";

if ($conn->query($sql) === TRUE) {
    echo "success";
	 
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}
}
 
 ?>