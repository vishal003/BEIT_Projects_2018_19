import firebase_admin
from firebase_admin import credentials
from firebase_admin import db
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.metrics import accuracy_score
from sklearn import tree
from sklearn.externals import joblib
import pickle
import numpy as np

model=joblib.load('prediction.pkl')
model2=joblib.load('prediction2.pkl')
model3=joblib.load('prediction3.pkl')
model4=joblib.load('prediction4.pkl')
cred = credentials.Certificate("serviceKey.json")
firebase_admin.initialize_app(cred,{
    'databaseURL' : 'https://bottomnavigationbar-d5987.firebaseio.com/'
})
root = db.reference()
override=root.child('override').get()
print(override)

x= 1
while (x == 1):
	root = db.reference()
	override = root.child('override').get()
	print(override)
	while (override == 1):
		root = db.reference()
		time = root.child('time').get()
		userid = root.child('userid').get()
		day = root.child('day').get()
		print("Time:")
		print(time)
		print("userid")
		print(userid)
		print("day")
		print(day)
		datasets=np.array([userid,time,day])
		datasets=datasets.reshape(1,-1)
		class_ids=model.predict(datasets)
		class_ids=int (class_ids[0])
		class_ids2=model2.predict(datasets)
		class_ids2=int (class_ids2[0])
		class_ids3=model.predict(datasets)
		class_ids3=int (class_ids3[0])
		class_ids4=model4.predict(datasets)
		class_ids4=int (class_ids4[0])
		root.update({'Light1':class_ids})
		root.update({'Light2':class_ids2})
		root.update({'Light3':class_ids3})
		root.update({'Light4':class_ids4})
		override = root.child('override').get()
		print("predicton1")
		print(class_ids)
		print("predicton2")
		print(class_ids2)
		print("predicton3")
		print(class_ids3)
		print("predicton4")
		print(class_ids4)