from socket import *
import sys
from rx import *
from rx.scheduler import ThreadPoolScheduler
from rx import operators as ops
import multiprocessing

finish = False

def client(main):
    while True:
        try:
            text = s.recv(2048)
            if text:
                print(text.decode('utf-8'))
        except:
            break

s = socket(AF_INET, SOCK_STREAM)
s.connect(('localhost', 7200))
of(s).pipe(ops.subscribe_on(ThreadPoolScheduler(multiprocessing.cpu_count()))
                  ).subscribe(lambda c: client(c))
while True:
    text = input()
    if text == '\f':
        print(text)
    else:
        s.send(bytes(text,'utf-8'))
        print("<You> " + text)
        if text == "/close":
            print("Exiting...")
            s.close()
            break
