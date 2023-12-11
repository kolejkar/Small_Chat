from socket import *
import sys
from rx import *
from rx.scheduler import ThreadPoolScheduler
from rx import operators as ops
import multiprocessing

def sendMsg1(message,user):
    for client in list_client:
        us,adr=client
        if us != user:
            try:
                msg="<"+adr[0]+"> "+ message
                us.send(bytes(msg,'utf-8'))
            except:
                print("Disconnet: "+adr[0])
                sendMsg1("is exting sesion.",us)
                us.close()
                remove(client)

def sendMsg(message):
    for client in list_client:
        us,adr=client
        try:
            msg=message
            us.send(bytes(msg,'utf-8'))
        except:
            print("Disconnet: "+adr[0])
            sendMsg1("is exting sesion.",us)
            us.close()
            remove(client)

def server(main):
    user,adr=main
    while True:
        try:
            msg = user.recv(2048)
            if msg:
                print("<"+adr[0]+"> "+ msg.decode('utf-8'))
                if msg.decode('utf-8') == "/close":
                    print(adr[0] + " is exting sesion.")
                    sendMsg1("is exting sesion.",user)
                    remove(user)
                else:
                    sendMsg1(msg.decode('utf-8'),user)
            else:
                print("Disconnet: "+adr[0])
                sendMsg1("is exting sesion.",user)
                remove(user)
        except:
            continue

def mainRoom(main):
    user,adr=main
    user.send(bytes("Welcome!",'utf-8'))
    of(main).pipe(ops.subscribe_on(ThreadPoolScheduler(multiprocessing.cpu_count()))
                  ).subscribe(lambda c: server(c))
    while True:
        text = input()
        if text == '\f':
            print(text)
        else:
            if text == "/close":
                print("Exiting...")
                sendMsg("<server> Closing server...")
                os.kill(os.getpid(),signal.SIGKILL)
            else:
                msg = "<server> " + text 
                sendMsg(msg)
                print("<You> " + text,end='\r\n')

def remove(conn):
    if conn in list_client:
        list_client.remove(conn)

print("Server starting ...")
s = socket(AF_INET, SOCK_STREAM)
s.bind(('localhost',7200))
s.listen(10)

list_client = []

while True:
    try:
        main=s.accept()
        conn,adr = main
        list_client.append(main)
        print("<" + adr[0] + "> conected")
        of(main).pipe(ops.subscribe_on(ThreadPoolScheduler(multiprocessing.cpu_count()))
                  ).subscribe(lambda c: mainRoom(c))
    except:
        break
s.close()
