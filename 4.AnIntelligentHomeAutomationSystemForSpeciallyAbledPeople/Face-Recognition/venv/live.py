# This script will detect faces via your webcam.
# Tested with OpenCV3

import cv2

faceCascade = cv2.CascadeClassifier('face_cascade.xml')

video_capture = cv2.VideoCapture(0)

while True:

    ret, frame = video_capture.read()

    if ret == True:

        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

        faces = faceCascade.detectMultiScale(
            frame,
            scaleFactor=1.1,
            minNeighbors=5,
            minSize=(30, 30),
            #flags=cv2.CASCADE_SCALE_IMAGE
        )

        # Draw a rectangle around the faces
        for (x, y, w, h) in faces:
            cv2.rectangle(frame, (x, y), (x+w, y+h), (0, 255, 0), 2)

        # Display the resulting frame
        cv2.imshow('Video', frame)

        if cv2.waitKey(1)==ord('q'):
            break

# When everything done, release the capture
#cap.release()
cv2.destroyAllWindows()
