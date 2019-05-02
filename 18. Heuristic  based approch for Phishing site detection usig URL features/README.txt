Title :- Heuristic-based Approach for Phishing Site Detection
Group No :- 18
Group Members:- 1) Chirag Chaudhari
		2) Swapnil Ghawali
		3) Swapil Kshetre
		4) Aakash Sane

Breaf Description:- 

We implement a a desktop application. Name of application is Heuristic-based Approach for Phishing Site Detection. On based of URL features,we ues Decision Tree algorithm to check the URL featurs.

REQUIREMENTS ANALYSIS(Hardware And Software Requirements):-
Hardware Description :- 
The selection of hardware is very important in the existence and proper working of any software. When selecting hardware, the size and requirements are also important.
Minimum Requirements :-
Processor :- Intel 1.66 GHz Processor Pentium 4
RAM :-	     1 GB
Hard Disk Drive :- 250 GB

Software Description :- 
The selection of software is very important in the existence and proper working of any hardware.
Minimum Requirements :-
Operating System : Windows XP/7/8/10
Front - End : Visual Studio 2013
Back - End : MS SQL Server 2008

STEPS:- 
1. These in main Screen of our desktop application, They have two stages: Training and detection. We want to ?rst train our system then we move to detection part of our application. there are two button training system and detection system that is check URL. Select the button test ?le system start the training state.
2. After selecting test with system we want to upload the database which store in folders. We have collection of database which collect in our system .The ?le are in Excel format which is upload in applicationBrowse the database then we uploaded.
3. Extracting features of database Using ID3 algorithm of decision tree .Click the button EXTRACT FEATURES OF ID3 and extracted.
4. View of extracted featured data in terms of 1 and 0. 1 is stands for the value is true and 0 is stands for false value. 1 is stands of the value are present in URL and 0 is stands for the value of URL are not present. It also be categorized by URL which is IP contain, length of URL, suspicious character, pre?x su?x, dots, slashes, HTTP present are not etc.
5. There are Extracted feature is also generates some rule we applied in URL .?rst we upload the ?le which generates from extracting features and set some rule of URL which applied on phishing URL.
6. There is a End of training part which done successfully in project Using ID3 algorithm.
7. Now, We move to detection part of software. In detection part we check URL which is phishing or Legitimate. click check URL button and move forward.
8. Click Test URL button to check phishing site or not.
9. In TEST URL there are one search button to input the value of URL.After the putting URL we Check the URL using ID3 algorithm. After check we shown the result which is length of URL , HTTP present or not, suspicious character , Dots available or not , length of sub domain, number of URL, Page rank, Age of website.
10. Check with Id3 algorithm we know the current URL are phishing site or Legitimate site . If the site will be Legitimate it run successfully and open it.
11. If the site will be phishing then it gives error message. This is end of detection part, After completing detection part we known which URL sites are phishing or Legitimate. Then we skip the phishing site and done work proper on legitimate site.
12. After completing training and detection technique phase, We have accurate result of URL site.But, some site is pure legitimate and some site part will OK to use there for we done some calculation to create statistics of URL site. The calculation is used by decision tree to conclude TRUE POSITIVE, FALSE POSITIVE ,TRUE NEGATIVE AND FALSE NEGATIVE web sites in database and categorized by them as following result. We found Accuracy , Speci?city, Sensitivity and False measure of database and also shown in graph.


