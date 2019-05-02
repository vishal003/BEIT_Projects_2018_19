import urllib
from bs4 import BeautifulSoup
from urllib.request import urlopen
from datetime import datetime


data = urllib.request.urlopen(" https://api.thingspeak.com/update?api_key=URE1SY7XC53AYHZ4&field5=1");
