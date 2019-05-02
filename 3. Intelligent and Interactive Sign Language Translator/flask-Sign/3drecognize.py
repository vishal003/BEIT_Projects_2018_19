import cv2
import numpy as np

def nothing(x):
	pass

image_x, image_y = 64,64

from keras.models import model_from_json
# classifier = load_model('model_my.h5')
json_file = open('sign_model.json', 'r')
loaded_model_json = json_file.read()
json_file.close()
loaded_model = model_from_json(loaded_model_json)
# load weights into new model
loaded_model.load_weights("sign_model.h5")
print("Loaded model from disk")

def predictor():

	X_tr_array = np.array(X_tr)

	print(X_tr_array)

	num_samples = len(X_tr_array) 
	print(num_samples)

	train_set = np.zeros((num_samples, 1, img_rows,img_cols,img_depth))

	for h in range(num_samples):
		train_set[h][0][:][:][:]=X_tr_array[h,:,:,:]

	train_set = train_set.astype('float32')
	train_set -= np.mean(train_set)
	# train_set /= np.max(train_set)
	
	result = loaded_model.predict(train_set)

	print('hello: ' + str(result[0][0]))
	# print('how are you: ' + str(result[0][1]))
	print('morning: ' + str(result[0][1]))

	print(max(map(max, result)))

	if result[0][0] == 1:
		return 'hello'
	# elif result[0][1] == 1:
	#     return 'how are you'
	elif result[0][1] == 1:
		return 'morning'

img_rows,img_cols,img_depth=16,16,15

cam = cv2.VideoCapture(0)

cap = cv2.VideoCapture('output.mp4')

fourcc = cv2.VideoWriter_fourcc(*'XVID')


# fps = vid.get(5)
# print("Frames per second using video.get(cv2.cv.CV_CAP_PROP_FPS): {0}".format(fps))

img_counter = 0

img_text = ''

while True:
	ret, frame = cam.read()
	frame = cv2.flip(frame,1)
	cv2.imshow("test", frame)

	k = cv2.waitKey(5) & 0xFF

	if k == ord('c'):
		print('capturing')
		cv2.putText(frame, 'capturing', (30, 400), cv2.FONT_HERSHEY_TRIPLEX, 1.5, (0, 255, 0))
		out = cv2.VideoWriter('output1.avi',fourcc, 25.0, (640,480))
		out.write(frame)

	if k == ord('s'):
		print('video saved')
		cv2.putText(frame, 'video saved', (30, 400), cv2.FONT_HERSHEY_TRIPLEX, 1.5, (0, 255, 0))
		out.release()

	if k == ord('r'):
		print('predicting')
		cv2.putText(frame, 'predicting', (30, 400), cv2.FONT_HERSHEY_TRIPLEX, 1.5, (0, 255, 0))
		
		cap = cv2.VideoCapture('output1.avi')
		frames = []

		for k in range(15):
			#ret, frame = cap.read()
			re_frame=cv2.resize(frame, (img_rows,img_cols), interpolation=cv2.INTER_AREA)
			gray = cv2.cvtColor(re_frame, cv2.COLOR_BGR2GRAY)
			frames.append(gray)

		input=np.array(frames)

		print(input.shape)
		ipt=np.rollaxis(np.rollaxis(input,2,0),2,0)
		print(ipt.shape)
		X_tr=[]
		X_tr.append(ipt)

		img_text = predictor()

		print(img_text)

		cv2.putText(frame, img_text, (30, 400), cv2.FONT_HERSHEY_TRIPLEX, 1.5, (0, 255, 0))

	if k == ord('q'):
		break


cam.release()
cap.release()

cv2.destroyAllWindows()