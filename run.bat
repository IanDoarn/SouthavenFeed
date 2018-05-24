cd queue
start /b python run.py
cd ..
cd html
start chrome http://localhost:8000
start /b python -m http.server 8000