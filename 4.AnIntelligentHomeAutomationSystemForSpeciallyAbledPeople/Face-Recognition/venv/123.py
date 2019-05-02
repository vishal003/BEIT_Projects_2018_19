import cv2
import numpy as np
from PIL import Image
from matplotlib import pyplot as plt

img =Image.open("C:\\Users\\ROHAN\\PycharmProjects\\Face-Recognition\\venv\\dataSet\\user.3.211.jpg")
imgarr = np.asanyarray(img)
hist = cv2.calcHist([imgarr], [0], None, [256], [0, 256])
plt.hist(imgarr.ravel(), 256, [0, 256])
plt.title('Histogram for dataset items')
plt.show()