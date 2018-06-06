@echo off
echo updating application
git pull
pip install -r requirements.txt
echo complete

echo starting download loop
cd queue
start /b python download.py
echo complete

cd ..

echo starting application scripts
cd scripts
start /b python prevent_sleep.py
echo complete

cd ..

echo starting minimal webserver on port 8000
cd html
start /b python -m http.server 8000
start chrome http://localhost:8000

echo server available on local machine @ http://localhost:8000