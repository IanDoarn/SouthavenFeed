import cx_Oracle
import os
import time
import sys
from structure.query import Query
from structure.qqueue import QQueue

# Load connection to oracle
CONNECTION_STRING = r"logistics/log78gist@10.201.207.188:1521/smsprd"
CONNECTION = cx_Oracle.connect(CONNECTION_STRING)
CURSOR = CONNECTION.cursor()
DIRECTORY = os.path.dirname(os.path.abspath(__file__))
QUEUE = QQueue()
WAIT_TIME = 30

# Load queries
with open(DIRECTORY + '\\sql\\ORACLE_COMPLETED_WORK.sql', 'r')as q_file:
    completed_work = Query(CURSOR, q_file.read(),
                           os.path.abspath(os.path.join(DIRECTORY, os.pardir, 'html', 'data', 'completed_work.json'))
                           )

with open(DIRECTORY + '\\sql\\ORACLE_COMPLETED_WORK_OTHER.sql', 'r')as q_file:
    completed_work_other = Query(CURSOR, q_file.read(),
                           os.path.abspath(os.path.join(DIRECTORY, os.pardir, 'html', 'data', 'completed_work_other.json'))
                           )


# enqueue queries
QUEUE.enqueue(completed_work)
QUEUE.enqueue(completed_work_other)

print('{} queries queued'.format(str(QUEUE.size)))
print('Time between execution: {} seconds'.format(str(WAIT_TIME)))

# main application loop
while(True):
    q = QUEUE.dequeue()

    try:

        print('Running query [{}]'.format(q.file_name))
        q.execute()
        print('Finished query [{}]'.format(q.file_name))
        q.write()

        QUEUE.enqueue(q)

    except Exception as error:
        print('An error occured. ' + str(error))

    except KeyboardInterrupt as kberror:
        print('Closing application')
        CONNECTION.close()
        sys.exit()

    time.sleep(WAIT_TIME)
