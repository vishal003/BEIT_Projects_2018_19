import cv2
import sqlite3
import string
import urllib
from bs4 import BeautifulSoup
from urllib.request import urlopen
import numpy as np
from datetime import datetime
# from matplotlib import pyplot as plt

import postmethod
import closepost



recognizer = cv2.face.LBPHFaceRecognizer_create()
recognizer.read('trainner/trainner.yml')
faceCascade = cv2.CascadeClassifier('face_cascade.xml');
cam = cv2.VideoCapture(0)
font = cv2.FONT_HERSHEY_SIMPLEX

def unknown():
        ret, camread=cam.read()
        img = cv2.cvtColor(camread,cv2.COLOR_BGR2RGB)
        for (x, y, w, h) in faces:
            d=datetime.date(datetime.now())
            cv2.imwrite("Unknown/User."+str(d)+'.'+str(datetime.now().strftime("%I"))+'.'+str(datetime.now().strftime("%M"))+'.'+str(datetime.now().strftime("%S"))+'.'+str(datetime.now().strftime("%p"))+".jpg",img)


def retrival(Id):
        conn = sqlite3.connect("faceset.db")
        cmd = "SELECT Name FROM family WHERE Id = " +str(Id)
        cursor = conn.execute(cmd)
        conn.commit()
        return cursor

Name=""
flag= 0
while True:
    ret, im =cam.read()
    gray=cv2.cvtColor(im,cv2.COLOR_BGR2GRAY)
    faces=faceCascade.detectMultiScale(gray, 1.2,5)
    for(x,y,w,h) in faces:
        cv2.rectangle(im,(x,y),(x+w,y+h),(225,0,0),2)
        Id,conf = recognizer.predict(gray[y:y+h,x:x+w])
        UsrName= retrival(Id)
        for row in UsrName:
            Name=row[0]
            print(conf)
        if(conf < 70):
            print("Welcome "+Name+"! Access Granted!")
            if(flag==0):
                  exec(open('postmethod.py').read())
                  flag = 1

        else:
            print("You have been recorded! Access Denied")
            unknown()
            Name="Unknown"
            if(flag==1):
                  exec(open('closepost.py').read())
                  flag = 0


        cv2.rectangle(im, (x, y), (x + w, y + h), (225, 0, 0), 2)
        cv2.putText(im,str(Name),(x,y+h), cv2.FONT_HERSHEY_SIMPLEX, 1.0, (0, 255, 0))
        break

    cv2.imshow('Enigma',im)
    # hist = cv2.calcHist([im], [0], None, [256], [0, 256])
    # plt.hist(im.ravel(), 256, [0, 256])
    # plt.title('Histogram for New image')
    # plt.show()
    if cv2.waitKey(1) == ord('q'):
        break
cam.release()
cv2.destroyAllWindows()