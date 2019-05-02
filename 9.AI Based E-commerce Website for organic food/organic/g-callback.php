<?php
	require_once "config.php";
	require_once "User.php";

	if (isset($_SESSION['access_token']))
		$gClient->setAccessToken($_SESSION['access_token']);
	else if (isset($_GET['code'])) {
		$token = $gClient->fetchAccessTokenWithAuthCode($_GET['code']);
		$_SESSION['access_token'] = $token;
	} else {
		header('Location: login.php');
		exit();
	}

	$oAuth = new Google_Service_Oauth2($gClient);
	$userData = $oAuth->userinfo_v2_me->get();

  /*  
if(isset($_GET['code'])){
	$gClient->authenticate($_GET['code']);
	$_SESSION['token'] = $gClient->getAccessToken();
	header('Location: ' . filter_var($redirectURL, FILTER_SANITIZE_URL));
}

if (isset($_SESSION['token'])) {
	$gClient->setAccessToken($_SESSION['token']);
}

if ($gClient->getAccessToken()) {
	//Get user profile data from google
	$userData = $google_oauthV2->userinfo->get();
	*/
	$_SESSION['id'] = $userData['id'];
	$_SESSION['email'] = $userData['email'];
	$_SESSION['gender'] = $userData['gender'];
	$_SESSION['picture'] = $userData['picture'];
	$_SESSION['familyName'] = $userData['familyName'];
	$_SESSION['givenName'] = $userData['givenName'];
	$_SESSION['dob'] = $userData['birthday'];

    //Initialize User class
	$user = new User();
	
	//Insert or update user data to the database
    $gpUserData = array(
        'oauth_provider'=> 'google',
        'oauth_uid'     => $userData['id'] ,
        'first_name'    => $userData['given_name'] ,
        'last_name'     => $userData['family_name'] ,
        'email'         => $userData['email'],
        'gender'        => $userData['gender'] ,
        'locale'        => $userData['locale'] ,
        'picture'       => $userData['picture'] ,
        'link'          => $userData['link'] 
    );
    $userData = $user->checkUser($gpUserData);



	
	header('Location: index.php');
	// exit();
?>
<?php include "close.php"; ?>