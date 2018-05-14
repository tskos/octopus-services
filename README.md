# Octopus Services
ASP.Net Core Test Task

Write a api in .net using either Framwork 4.6 or .Net Core 2.0.
 
Solution is to include Swagger and to have a single endpoint "\OctopusServices\CountWordLengths".
 
The post is to take in Json request with an array of words (strings) and returns a new json response with the word and the length of the word
 
please make sure you are using JsonObject for the definitions
 
Request
 ```json
{ 
  "myWords":[ 
    "test",
    "Testing",
    "Tester",
    "Tests"
  ]
}
 ```
 
Response
 ```json
{ 
  "results":[ 
    { 
      "word":"test",
      "count":4
    },
    { 
      "word":"Testing",
      "count":7
    },
    { 
      "word":"Tester",
      "count":6
    },
    { 
      "word":"Tests",
      "count":5
    }
  ]
}
```