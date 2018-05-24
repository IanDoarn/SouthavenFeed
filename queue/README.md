queue
-----

This directory contains the python application to collect information for oracle and postgres.

This application is run while the web server is running and generates json files that will be read by the website using jQuery.
This is necessary since python is locked by GIL and can not truly be multi-threaded.