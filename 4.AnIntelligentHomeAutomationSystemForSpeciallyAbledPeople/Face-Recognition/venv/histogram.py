import cv2
import numpy as np
from matplotlib import pyplot as plt

path="C:\\Users\\ROHAN\\PycharmProjects\\Face-Recognition\\venv\\dataSet\\user.3.211.jpg"
hist = cv2.calcHist([path], [0], None, [256], [0, 256])
    plt.hist(im.ravel(), 256, [0, 256])
    plt.title('Histogram for dataset items')
    plt.show()