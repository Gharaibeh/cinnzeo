<?php 
header('Content-Type: application/json');
$json_ugly = '{
  "isTimer": "False",
  "time": "12.45",
  "arrowsize": "1.0x0.08",
  "AnimationSpeed": "90",
  "AnimationTime": "1.0",
  "AnimationDelay": "5.0",
  "AnimationDelayEnd": "0.1",
  "EaseType":"easeInOutQuint",
  "yPosition": "-55",
  "xpositions": [
    {
      "xPosition1": "-200"
    },
    {
      "xPosition2": "-100"
    },
    {
      "xPosition3": "0"
    },
    {
      "xPosition4": "100"
    },
    {
      "xPosition5": "200"
    }
  ],
  "images": [
    {
      "limage": "limage1",
      "lposition": "1x45",
	  "lsize":"350x180",
	  "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/",
	  "simage": "simage1",
      "sposition": "-200x-100",
	  "ssize":"200x200",
	  "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
    },{
      "limage": "limage2",
      "lposition": "1x45",
	  "lsize":"350x180",
	  "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/",
	  "simage": "simage2",
      "sposition": "-100x-100",
	  "ssize":"200x200",
	  "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
    },{
      "limage": "limage3",
      "lposition": "1x45",
	  "lsize":"350x180",
	  "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/",
	  "simage": "simage3",
      "sposition": "1x-100",
	  "ssize":"200x200",
	  "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
    },{
      "limage": "limage4",
      "lposition": "1x45",
	  "lsize":"350x180",
	  "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/",
	  "simage": "simage4",
      "sposition": "100x-100",
	  "ssize":"200x200",
	  "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
    },{
      "limage": "limage5",
      "lposition": "1x45",
	  "lsize":"350x180",
	  "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/",
	  "simage": "simage5",
      "sposition": "200x-100",
	  "ssize":"200x200",
	  "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
    }
  ]
}';
$json_pretty = json_encode(json_decode($json_ugly), JSON_PRETTY_PRINT);
echo $json_pretty;

?>