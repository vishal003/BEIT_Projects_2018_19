import cv2
import sqlite3
import string
import os, fnmatch

cam = cv2.VideoCapture(0)
detector= cv2.CascadeClassifier('face_cascade.xml')

count = 0

def newimages(path,Id):
    asd = 0
    find = []
    imagePaths = [os.path.join(path, f) for f in os.listdir(path)]
    i = 0
    Idnew=0
    for imagePath in imagePaths:
        Idnew = int(os.path.split(imagePath)[-1].split(".")[1])
        if(Id==Idnew):
            asd = Idnew
            x= int(os.path.split(imagePath)[-1].split(".")[2])
            find.append(x)

    if(Id == asd):
        numb = find.__len__()
        count = numb+1
        return int(count)

def updateusr():
    conn = sqlite3.connect("faceset.db")
    updusr= conn.execute(cmd)
    conn.commit()
    conn.close()
    return 1

def getId(Name):
    conn = sqlite3.connect("faceset.db")
    cmd = "SELECT Id FROM family WHERE Name="+"'"+Name+"'"+";"
    usrid = conn.execute(cmd)
    conn.commit()
    return usrid

def insertOrUpdate(Name):
    conn= sqlite3.connect("faceset.db")
    cmd="INSERT INTO family(Name) VALUES('"+str(Name)+"');"
    asd=conn.execute(cmd)
    conn.commit()
    conn.close()

Id=""
Name = input('ENTER YOUR NAME: ')
Ids= getId(Name)
for row in Ids:
    Id=row[0]
print(Id)

if(Id==""):
 insertOrUpdate(Name)

Ids= getId(Name)
for row in Ids:
    Id=row[0]
print(Id)
count = newimages('dataSet',Id)
Num=0
while True:
    ret, im= cam.read()
    gray=cv2.cvtColor(im,cv2.COLOR_BGR2GRAY)
    faces=detector.detectMultiScale(gray,scaleFactor=1.2, minNeighbors=5, minSize=(100, 100), flags=cv2.CASCADE_SCALE_IMAGE)
    for(x,y,w,h) in faces:
        Num=Num+1
        if(count is None):
            cv2.imwrite("dataSet/user." +str(Id)+'.' +str(Num)+".jpg",gray[y:y+h,x:x+w])
        else:
            cv2.imwrite("dataSet/user."+str(Id)+'.'+str(count)+".jpg",gray[y:y+h,x:x+w])
            count=int(count)+1

        cv2.rectangle(im, (x-50,y-50), (x+w+50,y+h+50), (225,0,0),2)

    cv2.imshow('RECOGNISATION',im)
    cv2.waitKey(100)

    if Num>50 :
        cam.release()
        cv2.destroyAllWindows()
        break

