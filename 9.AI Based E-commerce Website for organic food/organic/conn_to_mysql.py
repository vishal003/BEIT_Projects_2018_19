import numpy as np
import pandas as pd
from numpy import *
import mysql.connector
from mysql.connector import Error
try:
	mySQLconnection = mysql.connector.connect(host='localhost',database='organic',user='root',password='123456') #change the name database,username,password
	#fetch user list from database
	sql_select_User = "SELECT DISTINCT user_id FROM  review" #change the name of the table
	cursor = mySQLconnection .cursor()
	cursor.execute(sql_select_User)
	records1=cursor.fetchall()
	user=[]
	#print user list
	for row in records1:
		user.append(row[0])
	print(user)	
	num_users = cursor.rowcount	#this variable store count of users
	#fetch product list from database
	sql_select_Product = "SELECT DISTINCT product_id FROM  review" 
	cursor.execute(sql_select_Product)
	records2 =cursor.fetchall()
	product=[]
	#print product list
	for row in records2:
		product.append(row[0])
	print(product)
	num_products = cursor.rowcount	#this variable store count of products
	#print(num_user,num_products)
	product_id=(num_products,num_users)
	print(product_id)
	ratings=zeros(product_id)
	only_rating=[]
	binery_rating=[]
	results=[]

	#Fetch reting from database 
	
	for user_arr in user:
		for product_arr in product:
			sql_select_Product1 = "SELECT rating FROM review WHERE product_id =%s  AND user_id=%s "
			cursor.execute(sql_select_Product1,(product_arr,user_arr))
			results = cursor.fetchall()
			results=np.asarray(results)#convert to array
			#store rating as 1 if given  or zero if not
			if not results :
				binery_rating.append(0)
			else:
				binery_rating.append(1)
			#fetch only rating and store into array
			for row in results:
				if row:
					only_rating.append(row[0])
	#convert string array into int array
	onlyint_rating=[int(x) for x in only_rating]
	print(onlyint_rating)
	print(binery_rating)
	x=0
	for n,i in enumerate(binery_rating):
		if i==1:
			binery_rating[n]=onlyint_rating[x]
			x=x+1
	print(binery_rating)
	final_rate=[]
	y=0
	for m,i in enumerate(user):
		for n,j in enumerate(product):
			ratings[n][m]=binery_rating[y]
			y=y+1
	print(ratings)
	did_rate = (ratings != 0) * 1
	print(did_rate)
	
	# a function that normalizes a dataset

	def normalize_ratings(ratings, did_rate):
		num_products = ratings.shape[0]
		
		ratings_mean = zeros(shape = (num_products, 1))
		ratings_norm = zeros(shape = ratings.shape)
		
		for i in range(num_products): 
			# Get all the indexes where there is a 1
			idx = where(did_rate[i] == 1)[0]
			#  Calculate mean rating of ith product only from user's that gave a rating
			ratings_mean[i] = mean(ratings[i, idx])
			ratings_norm[i, idx] = ratings[i, idx] - ratings_mean[i]
		return ratings_norm, ratings_mean
		
	ratings, ratings_mean = normalize_ratings(ratings, did_rate)
	print(ratings)
	print(ratings_mean)
	num_users = ratings.shape[1]
	num_features = 3
	product_features = random.randn( num_products, num_features )
	user_prefs = random.randn( num_users, num_features )
	initial_X_and_theta = r_[product_features.T.flatten(), user_prefs.T.flatten()]
	print (product_features)	
	print (user_prefs)
	print (initial_X_and_theta)
	initial_X_and_theta.shape
	product_features.T.flatten().shape
	user_prefs.T.flatten().shape
	initial_X_and_theta
	
	
	def unroll_params(X_and_theta, num_users, num_products, num_features):
		# Retrieve the X and theta matrixes from X_and_theta, based on their dimensions (num_features, num_products, num_products)
		# --------------------------------------------------------------------------------------------------------------
		# Get the first 30 (10 * 3) rows in the 48 X 1 column vector
		first_30 = X_and_theta[:num_products * num_features]
		# Reshape this column vector into a 10 X 3 matrix
		X = first_30.reshape((num_features, num_products)).transpose()
		# Get the rest of the 18 the numbers, after the first 30
		last_18 = X_and_theta[num_products * num_features:]
		# Reshape this column vector into a 6 X 3 matrix
		theta = last_18.reshape(num_features, num_users ).transpose()
		return X, theta
	
	
	def calculate_gradient(X_and_theta, ratings, did_rate, num_users, num_products, num_features, reg_param):
		X, theta = unroll_params(X_and_theta, num_users, num_products, num_features)
		
		# we multiply by did_rate because we only want to consider observations for which a rating was given
		difference = X.dot( theta.T ) * did_rate - ratings
		X_grad = difference.dot( theta ) + reg_param * X
		theta_grad = difference.T.dot( X ) + reg_param * theta
		
		# wrap the gradients back into a column vector 
		return r_[X_grad.T.flatten(), theta_grad.T.flatten()]
	
	
	def calculate_cost(X_and_theta, ratings, did_rate, num_users, num_products, num_features, reg_param):
		X, theta = unroll_params(X_and_theta, num_users, num_products, num_features)
		
		# we multiply (element-wise) by did_rate because we only want to consider observations for which a rating was given
		cost = sum( (X.dot( theta.T ) * did_rate - ratings) ** 2 ) / 2
		# '**' means an element-wise power
		regularization = (reg_param / 2) * (sum( theta**2 ) + sum(X**2))
		return cost + regularization

	
	from scipy import optimize

	reg_param = 30

	minimized_cost_and_optimal_params = optimize.fmin_cg(calculate_cost, fprime=calculate_gradient, x0=initial_X_and_theta, 								args=(ratings, did_rate, num_users, num_products, num_features, reg_param), 								maxiter=100, disp=True, full_output=True )

	
	cost, optimal_product_features_and_user_prefs = minimized_cost_and_optimal_params[1], minimized_cost_and_optimal_params[0]

	product_features, user_prefs = unroll_params(optimal_product_features_and_user_prefs, num_users, num_products, num_features)

	print (product_features)
	
	print (user_prefs)

	all_predictions = product_features.dot( user_prefs.T )

	print (all_predictions)
	
	predictions_for_products= all_predictions[:, 0:1] + ratings_mean

	print(predictions_for_products)

	#fetch user list from database
	cursor.execute("TRUNCATE TABLE recommendation")
	mySQLconnection.commit()
	print ("TRUNCATE recommendation table")
	str_product=[str(x) for x in product]
	#str_predictions_for_products=[str(x) for x in predictions_for_products]
	product_recomm=[]
	#predictions_for_products=int(str_predictions_for_products)
	for row in predictions_for_products:
		product_recomm.append(row[0])
	
	print(product_recomm)
	#str_predictions_for_products=np.asarray(str_predictions_for_products)
	#print(str_predictions_for_products)
	y=0
	for x in range(0,num_products):
		sql_insert_rating = "INSERT INTO recommendation (`product_id`, `rating`) VALUES (%s,%s) " #change the name of the table
		insert_tuple = (str_product[y],str(product_recomm[y]))
		cursor = mySQLconnection.cursor()
		insertion=cursor.execute(sql_insert_rating,insert_tuple)
		mySQLconnection.commit()
		y=y+1
		
	print ("Record inserted successfully into recommendation table")
	
except Error as e :
	print ("Error while connecting to MySQL", e)
#finally:
    #closing database connection.
  #  if(mySQLconnection .is_connected()):
       # connection.close()
       # print("MySQL connection is closed")

