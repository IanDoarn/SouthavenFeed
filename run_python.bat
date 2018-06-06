@echo off
echo starting helper scripts
cd scripts
start /b python prevent_sleep.py
echo complete
cd ..
echo starting upload loop
cd queue
start /b python run.py
echo complete