import time
import os
import sys
from pydrive.auth import GoogleAuth
from pydrive.drive import GoogleDrive

print('Connecting to google drive')
gauth = GoogleAuth()
gauth.LocalWebserverAuth()

drive = GoogleDrive(gauth)
print('Complete.')


DIRECTORY = os.path.dirname(os.path.abspath(__file__))
WAIT_TIME = 60

file_ids = [
    {'id': '1YF_LEJG6JRYkP0ClKnyYNyxFm0OaA_zQ', "name": "completed_work.json"},
    {"id": '1WuQfQkKGHgKBXGsrCkLLZb0oTkD0s2tx', "name": "completed_work_other.json"}
]

while(True):
    print('Running download loop')
    try:
        for fid in file_ids:
            print('Downloading [{}]'.format(fid['name']))
            filedl = drive.CreateFile({'id': fid['id']})
            filedl.GetContentFile(os.path.abspath(os.path.join(DIRECTORY, os.pardir, 'html', 'data', fid['name'])))
            print('Complete.')
            print('Waiting [{}] seconds'.format(WAIT_TIME))
            time.sleep(WAIT_TIME)

    except Exception as error:
        print('An error occured. ' + str(error))

    except KeyboardInterrupt as kberror:
        print('Closing application')
        sys.exit()
