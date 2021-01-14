 <?php
    
$servername = "imscorgau.ipagemysql.com";
$username = "hasan";
$password = "hasan";
$dbname = "cinnzeo";
 

 /*$servername = "localhost";
$username = "user1";
$password = "SjuHp1egQTHLmUrO";
$dbname = "cinnzeo";*/

$conn = mysqli_connect($servername, $username, $password, $dbname);
 
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 


$deviceID= $_REQUEST['deviceID']; 

$result = $conn->query("SELECT * FROM tv_ids  where device_id= '$deviceID'");

$name = "";
$configs = "";

if ($result->num_rows > 0) {
	while($row = $result->fetch_assoc()) {
	$name =$row["tv_name"];
	$configs =$row["tv_configs"];

}
} else {
	$configs= "null";
}


 
if ($configs == "null")
{
	$sqll ="";
	if ($deviceID != ""){ 
	$sqll = "INSERT INTO tv_ids (device_id) VALUES ('$deviceID')";
	}

if ($conn->query($sqll) === TRUE) {
	echo "success";
	 
} else {
	echo "Error: " . $sqll . "<br>" . $conn->error;
}

} else if ($configs == ""){ 
	echo "configs empty for".$name;
}  else { 
	
header('Content-Type: application/json');
$json_ugly = $configs;
$json_pretty = json_encode(json_decode($json_ugly), JSON_PRETTY_PRINT);
echo $json_pretty;
} 
 
 ?>
 
 
 
 
 