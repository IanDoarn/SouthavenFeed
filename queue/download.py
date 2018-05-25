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


while(True):
    print('Running download loop')

    files = drive.ListFile({'q': "'14ATnYYdZ2Rax2wCO1_86UHwVIczzXaIv' in parents and trashed=false"}).GetList()

    try:

        for fid in files:
            print('Downloading [{}]'.format(fid['title']))

            filedl = drive.CreateFile({'id': fid['id']})

            filedl.GetContentFile(os.path.abspath(os.path.join(DIRECTORY, os.pardir, 'html', 'data', fid['title'])))
            print('Complete.')
            print('Waiting [{}] seconds'.format(WAIT_TIME))
            time.sleep(WAIT_TIME)

    except Exception as error:
        print('An error occured. ' + str(error))

    except KeyboardInterrupt as kberror:
        print('Closing application')
        sys.exit()
