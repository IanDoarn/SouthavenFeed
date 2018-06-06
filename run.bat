@echo off

echo updating application
git pull
pip install -r requirements.txt
echo complete

echo starting helper scripts
cd scripts
start /b python prevent_sleep.py
echo complete

cd ..

echo starting minimal webserver on port 8000
cd html
start /b python -m http.server 8000
start chrome http://localhost:8000
echo serving on local machine @ http://localhost:8000
cd ..

echo starting application loop
cd %cd%\tracker\tracker\tracker\bin\Release
start /b tracker.exe %USERPROFILE%\SouthavenFeed\html\data\
echo setup complete
echo !!WATCH CONSOLE FOR ERRORS!!