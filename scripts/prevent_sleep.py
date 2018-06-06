import time
import pyautogui

pyautogui.FAILSAFE = False
idle = False
not_idle_timer = 300
idle_timer = 15


def user_not_idle():
    global idle
    mouse_position = pyautogui.position()
    time.sleep(not_idle_timer)
    if pyautogui.position() == mouse_position:
        pyautogui.press('printscreen')
        idle = True


def user_is_idle():
    global idle
    mouse_position = pyautogui.position()
    time.sleep(idle_timer)
    if pyautogui.position() != mouse_position:
        idle = False
    else:
        pyautogui.press('printscreen')


def post_time():
    localtime = time.asctime(time.localtime(time.time()))
    if idle == True:
        print("User gone at ", localtime)
    if idle == False:
        print("User back at ", localtime)
        print()


print("Program started...")
print('idle timer: [{}]\nnot idle timer: [{}]\nRunning main loop'.format(
    str(idle_timer / 60), str(not_idle_timer / 60)
))

while True:
    while idle == False:
        user_not_idle()
    post_time()
    while idle == True:
        user_is_idle()
    post_time()
