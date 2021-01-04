<?php 
header('Content-Type: application/json');
$json_ugly = '{
  "screens": [
    {
      "deviceID": "456456465",
      "isTimer": "False",
      "time": "12.45",
      "arrowsize": "0.001x0.001",
      "AnimationSpeed": "90",
      "AnimationTime": "1.0",
      "AnimationDelay": "5.0",
      "AnimationDelayEnd": "0.1",
      "EaseType": "easeInOutQuint",
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
        }
      ],
      "images": [
        {
          "limage": "limage1",
          "lposition": "1x1",
          "lsize": "450x250",
          "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images4/",
          "simage": "simage1",
          "sposition": "-200x-100",
          "ssize": "1x1",
          "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
        },
        {
          "limage": "limage2",
          "lposition": "1x1",
          "lsize": "450x250",
          "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images4/",
          "simage": "simage2",
          "sposition": "-100x-100",
          "ssize": "1x1",
          "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
        },
        {
          "limage": "limage3",
          "lposition": "1x1",
          "lsize": "450x250",
          "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images4/",
          "simage": "simage3",
          "sposition": "1x-100",
          "ssize": "1x1",
          "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
        }
      ]
    },
    {
      "deviceID": "4fa553d7a38581d3aff1532ff924cc0294082f24",
      "isTimer": "False",
      "time": "12.45",
      "arrowsize": "0.001x0.001",
      "AnimationSpeed": "90",
      "AnimationTime": "1.0",
      "AnimationDelay": "5.0",
      "AnimationDelayEnd": "0.1",
      "EaseType": "easeInOutQuint",
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
        }
      ],
      "images": [
        {
          "limage": "limage1",
          "lposition": "1x1",
          "lsize": "450x250",
          "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images4/",
          "simage": "simage1",
          "sposition": "-200x-100",
          "ssize": "1x1",
          "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
        },
        {
          "limage": "limage2",
          "lposition": "1x1",
          "lsize": "450x250",
          "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images4/",
          "simage": "simage2",
          "sposition": "-100x-100",
          "ssize": "1x1",
          "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
        },
        {
          "limage": "limage3",
          "lposition": "1x1",
          "lsize": "450x250",
          "lpath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images4/",
          "simage": "simage3",
          "sposition": "1x-100",
          "ssize": "1x1",
          "spath": "http://imscorgau.ipage.com/cinnzeo/minimenusizes/images3/"
        }
      ]
    }
  ]
}';
$json_pretty = json_encode(json_decode($json_ugly), JSON_PRETTY_PRINT);
echo $json_pretty;

?>