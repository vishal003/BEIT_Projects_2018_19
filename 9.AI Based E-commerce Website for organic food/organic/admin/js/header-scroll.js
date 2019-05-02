
$(document).ready(function(){
  $(window).scroll(function(){
  	var scroll = $(window).scrollTop();
	  if (scroll > 300) {
	    $(".black").css("background" , "#333");
	  }

	  else{
		  $(".black").css("background" , "");  	
	  }
  })
})