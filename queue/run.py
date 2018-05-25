import cx_Oracle
import os
import time
import sys
from structure.query import Query
from structure.qqueue import QQueue
from settings import UPLOAD_INTERVAL
from pydrive.auth import GoogleAuth
from pydrive.drive import GoogleDrive


# Load connection to oracle
CONNECTION_STRING = r"logistics/log78gist@10.201.207.188:1521/smsprd"

print('Connecting to oracle')
CONNECTION = cx_Oracle.connect(CONNECTION_STRING)
CURSOR = CONNECTION.cursor()
print('Complete.')

DIRECTORY = os.path.dirname(os.path.abspath(__file__))
QUEUE = QQueue()
WAIT_TIME = UPLOAD_INTERVAL

print('connecting to google drive')
gauth = GoogleAuth()
print('Complete.')
print('authenticating')
gauth.LocalWebserverAuth()
drive = GoogleDrive(gauth)


# Load queries

print('Building queue')
with open(DIRECTORY + '\\sql\\ORACLE_COMPLETED_WORK.sql', 'r')as q_file:
    completed_work = Query(CURSOR, q_file.read(),
                           'completed_work.json',
                           'completed_work',
                           '1azQ3ZMQDLE0CiRDdcM2o3HusjdDlfnuT'
                           )

with open(DIRECTORY + '\\sql\\ORACLE_COMPLETED_WORK_OTHER.sql', 'r')as q_file:
    completed_work_other = Query(CURSOR, q_file.read(),
                           'completed_work_other.json',
                           'completed_work_other',
                           '1k5WvS0VZYWAp2n29OVbht2w6FCCRYb0L'
                           )


# enqueue queries
QUEUE.enqueue(completed_work)
QUEUE.enqueue(completed_work_other)

print('{} queries queued'.format(str(QUEUE.size)))
print('Time between execution: {} minutes'.format(str(WAIT_TIME / 60)))


def ListFolder(parent):
  filelist=[]
  file_list = drive.ListFile({'q': "'%s' in parents and trashed=false" % parent}).GetList()
  for f in file_list:
    if f['mimeType']=='application/vnd.google-apps.folder': # if folder
        filelist.append({"id":f['id'],"title":f['title'],"list":ListFolder(f['id'])})
    else:
        filelist.append(f['title'])
  return filelist


# main application loop
while(True):
    q = QUEUE.dequeue()

    try:

        print('Running query [{}]'.format(q.name))
        q.execute()
        print('Finished query [{}]'.format(q.name))
        q.write()
        print('Writing query to [{}]'.format(q.file_name))

        QUEUE.enqueue(q)

        print('uploading file to drive')

        files = drive.ListFile({'q': "'14ATnYYdZ2Rax2wCO1_86UHwVIczzXaIv' in parents and trashed=false"}).GetList()

        for f in files:
            if f['title'] == q.name + '.json':
                print('deleting [{}] [{}]'.format(f['id'], f['title']))
                temp = drive.CreateFile({'id': f['id']})
                temp.Delete()

        file1 = drive.CreateFile(
            {
                q.name: q.name + '.json', 'parents': [
                {'id': '14ATnYYdZ2Rax2wCO1_86UHwVIczzXaIv'}
            ]}
        )

        file1.SetContentFile(q.name + '.json')
        file1.Upload()

        print('Complete.')


    except Exception as error:
        print('An error occured. ' + str(error))

    except KeyboardInterrupt as kberror:
        print('Closing application')
        CONNECTION.close()
        sys.exit()

    time.sleep(WAIT_TIME)
