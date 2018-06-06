
  
# Zimmer Biomet Southaven Productivity Feed  
Southaven live productivity feed uses C# and Python to present real time employee numbers in a visual animated format to employees, management, and other working on site.  
  
## Example  
Employees can see what has been done in real time presented like:  

| EMPLOYEE | KIT_INBOUND | PIECE_INBOUND | INSTRUMENT_INBOUND | PUTAWAY | KIT_BUILD | OUTBOUND | OTHER |
|:--------------|:---:|:--:|:-:|:-:|:--:|:-:|:-:|    
| ROLANDO FLORES | 163 | 48 | 0 | 4 | 26 | 0 | 0 |
  
## Process  
Information is queried from Oracle using the queries in the folder `sql`. These are then written to a json file. For example, running `completed_work_other.sql` returns the following json:  
```json  
[
  {
    "EMPLOYEE": "NICHOLAS THOMAS",
    "KIT_INBOUND_TRANSFER": 0,
    "PIECE_INBOUND_TRANSFER": 0,
    "INSTRUMENT_INBOUND_TRANSFER": 0,
    "PUTAWAY_TRANSFER": 63,
    "KIT_BUILD_TRANSFER": 0,
    "OUTBOUND_TRANSFER": 7,
    "OTHER_TRANSFER": 0,
    "TOTAL_PRODUCTIVITY": 0.19
  },
  {
    "EMPLOYEE": "GONZLA JOYNER",
    "KIT_INBOUND_TRANSFER": 0,
    "PIECE_INBOUND_TRANSFER": 0,
    "INSTRUMENT_INBOUND_TRANSFER": 0,
    "PUTAWAY_TRANSFER": 6,
    "KIT_BUILD_TRANSFER": 0,
    "OUTBOUND_TRANSFER": 0,
    "OTHER_TRANSFER": 8,
    "TOTAL_PRODUCTIVITY": 0.58
  }
]
```  
  
# Running the application  
The application consists of three main parts:  
  
 1. Webserver / Website (Python, HTML, Js)  
 2. Data Refresh (C#)  
 3. Helper Scripts (Python)  
   
The application runs off a python webserver using  
```cmd  
 python -m http.server 8000
 ```  
Data is refreshed in the background by the tracker application. it is then presented to the website via js.  
  
### Requirements  
The application currently requires Python 3.6+, .NET 4+, and HTML5. However, I plan on depreciating python entirely by setting up the simple web server in C#. Additionally, the proper Oracle prequisites are necessary, but these come standard on the computers this would run on at Southaven.  
  
# Examples  
There are currently 3 pages displayed during the applications main loop as outlined in `navigation.json`  
```json  
{    
  "productivity": "otherproductivity.html",    
  "otherproductivity": "motto.html",    
"motto": "productivity.html" }  
```  
  
## Homepage  
![Homepage](https://github.com/IanDoarn/SouthavenFeed/blob/master/images/Homepage.PNG)  
  
## Productivity  
There are 2 productivity pages but one if for managers, this is the main page  
![Productivity](https://github.com/IanDoarn/SouthavenFeed/blob/master/images/Porductivity.PNG)  
  
## The Power Of Us  
![The Power Of Us](https://github.com/IanDoarn/SouthavenFeed/blob/master/images/ThePowerOfUs.PNG)

# Credit
Created by: Ian Doarn (https://github.com/IanDoarn/)



---
###### Copyright (c) Zimmer Biomet 2018 all right reserved
