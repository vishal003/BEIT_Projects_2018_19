from importlib import import_module
import os
import pyrebase
from flask import Flask, render_template, Response,redirect, url_for,request

from find import find_now


app = Flask(__name__)

config = {
	"apiKey": "AIzaSyCVb8WGYsjUwYPAS1ZY8O8s7JXGPETn9gM",
    "authDomain": "webtesting-rkamra.firebaseapp.com",
    "databaseURL": "https://webtesting-rkamra.firebaseio.com",
    "projectId": "webtesting-rkamra",
    "storageBucket": "webtesting-rkamra.appspot.com",
    "messagingSenderId": "751221935891"
}

firebase = pyrebase.initialize_app(config);

auth = firebase.auth()

@app.route('/')
def index():
    return render_template('index.html')
# def login1():
# 	return render_template('login.html')



@app.route('/login',methods = ['POST'])
def login():
	if request.method == 'POST':
		return redirect(url_for('login1'))

@app.route('/index1',methods = ['POST'])
def index1():
	if request.method == 'POST':
		fname = request.form['first_name']
		lname = request.form['last_name']
		bday = request.form['birthday']
		email = request.form['email']
		passwd = request.form['pass2']
		phone = request.form['phone']
		gender = request.form['gender']
		authe = auth.create_user_with_email_and_password(email,passwd)
		db =firebase.database()
		db.child("users").push({"First_name":fname,"Last_name":lname,"birthday":bday,"email":email,"password":passwd,"phone":phone,"gender":gender})
		return redirect(url_for('index'))

@app.route('/translate',methods = ['POST'])
def translate():
	if request.method == 'POST':
		img_res = find_now()
		return render_template('dashboard.html', value_res = img_res)

@app.route('/dashboard1',methods = ['GET','POST'])
def dashboard1():
	if request.method == 'POST':
		email = request.form['email']
		passwd = request.form['passwd']
		authe = auth.sign_in_with_email_and_password(email,passwd)
		# print(authe)
		# if auth.get_account_info(authe['idToken']).exists():
			# return "<h3>Incorrect Credentials</h3>"
		# else:
		# if authe == Null:
		return redirect(url_for('dashboard'))
		# else:
			# return "<h3>Incorrect Credentials</h3>"

@app.route('/dashboard')
def dashboard():
	return render_template('dashboard.html')

# @app.route('/translate1')
# def translate1():

@app.route('/signup',methods = ['POST'])
def signup():
	if request.method == 'POST':
		return redirect(url_for('signup1'))

@app.route('/login1')
def login1():
	return render_template('login.html')

@app.route('/index2')
def index2():
	return redirect(url_for('index'))

@app.route('/alphabets')
def alphabets():
	return render_template('main.html')

@app.route('/tutorials')
def tutorials():
	return render_template('tutuorials.html')

@app.route('/profile')
def profile():
	return render_template('profile.html')

@app.route('/signup1')
def signup1():
	return render_template('signup.html')

if __name__ == '__main__':
	app.debug = True
	app.run(host='0.0.0.0', threaded=True)