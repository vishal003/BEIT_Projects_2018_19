import cv2
import numpy as np
import tensorflow as tf
from cnn_tf import cnn_model_fn
import os
import sqlite3
from keras.models import load_model
from keras.models import model_from_json
class find_now():
	
	
	def __init__(self):
		os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'
		tf.logging.set_verbosity(tf.logging.ERROR)
		classifier = tf.estimator.Estimator(model_dir="tmp/cnn_model2", model_fn=cnn_model_fn)
		prediction = None
		model = load_model('cnn_model_keras2.h5')
		image_x, image_y = cv2.imread('gestures/100.jpg', 0).shape
		self.keras_predict(model,image_x, image_y, np.zeros((50, 50), dtype=np.uint8))
		self.recognize(model,image_x, image_y)


	def keras_process_image(self,image_x, image_y,img):
		img = cv2.resize(img, (image_x, image_y))
		img = np.array(img, dtype=np.float32)
		img = np.reshape(img, (1, image_x, image_y, 1))
		return img

	def keras_predict(self,model,image_x, image_y, image):
		processed = self.keras_process_image(image_x, image_y,image)
		pred_probab = model.predict(processed)[0]
		pred_class = list(pred_probab).index(max(pred_probab))
		return max(pred_probab), pred_class

	def get_pred_text_from_db(self,pred_class):
		conn = sqlite3.connect("gesture_db.db")
		cmd = "SELECT g_name FROM gesture WHERE g_id="+str(pred_class)
		cursor = conn.execute(cmd)
		for row in cursor:
			return row[0]

	def split_sentence(self,text, num_of_words):
		'''
		Splits a text into group of num_of_words
		'''
		list_words = text.split(" ")
		length = len(list_words)
		splitted_sentence = []
		b_index = 0
		e_index = num_of_words
		while length > 0:
			part = ""
			for word in list_words[b_index:e_index]:
				part = part + " " + word
			splitted_sentence.append(part)
			b_index += num_of_words
			e_index += num_of_words
			length -= num_of_words
		return splitted_sentence

	def put_splitted_text_in_blackboard(self,blackboard, splitted_text):
		y = 200
		for text in splitted_text:
			cv2.putText(blackboard, text, (4, y), cv2.FONT_HERSHEY_TRIPLEX, 2, (255, 255, 255))
			y += 50

	
	def recognize(self,model,image_x, image_y):
		global prediction
		cam = cv2.VideoCapture(1)
		if cam.read()[0] == False:
			cam = cv2.VideoCapture(0)
		# hist = get_hand_hist()
		x, y, w, h = 300, 100, 300, 300
		while True:
			text = ""
			img = cam.read()[1]
			img = cv2.flip(img, 1)
			img = cv2.resize(img, (640, 480))
			imgCrop = img[y:y+h, x:x+w]
			img_ycrcb = cv2.cvtColor(imgCrop, cv2.COLOR_BGR2YCR_CB)
			blur = cv2.GaussianBlur(img_ycrcb,(11,11),0)

			lower_blue = np.array([20, 133, 77])
			upper_blue = np.array([255, 173, 127])

			mask = cv2.inRange(blur, lower_blue, upper_blue)

			contours = cv2.findContours(mask.copy(), cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)[0]
			if len(contours) > 0:
				contour = max(contours, key = cv2.contourArea)
				#print(cv2.contourArea(contour))
				if cv2.contourArea(contour) > 10000:
					x1, y1, w1, h1 = cv2.boundingRect(contour)
					save_img = mask[y1:y1+h1, x1:x1+w1]
					
					if w1 > h1:
						save_img = cv2.copyMakeBorder(save_img, int((w1-h1)/2) , int((w1-h1)/2) , 0, 0, cv2.BORDER_CONSTANT, (0, 0, 0))
					elif h1 > w1:
						save_img = cv2.copyMakeBorder(save_img, 0, 0, int((h1-w1)/2) , int((h1-w1)/2) , cv2.BORDER_CONSTANT, (0, 0, 0))
					
					pred_probab, pred_class = self.keras_predict(model,image_x, image_y, save_img)
					
					if pred_probab*100 > 80:
						text = self.get_pred_text_from_db(pred_class)
						print(text)
			blackboard = np.zeros((480, 640, 3), dtype=np.uint8)
			splitted_text = self.split_sentence(text, 2)
			self.put_splitted_text_in_blackboard(blackboard, splitted_text)
			#cv2.putText(blackboard, text, (30, 200), cv2.FONT_HERSHEY_TRIPLEX, 1.3, (255, 255, 255))
			cv2.rectangle(img, (x,y), (x+w, y+h), (0,255,0), 2)
			res = np.hstack((img, blackboard))
			cv2.imshow("Recognizing gesture", res)
			cv2.imshow("thresh", mask)
			if cv2.waitKey(1) == ord('q'):
				break
			# return splitted_text