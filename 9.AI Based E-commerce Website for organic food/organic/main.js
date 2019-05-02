$(document).ready(function(){
	
product();
cat();

	function cat(){
		$.ajax({
			url	:	"action.php",
			method:	"POST",
			data	:	{category:1},
			success	:	function(data){
				$("#get_category").html(data);
				
			}
		})
	}
	
		$("body").delegate(".category","click",function(event){
		
		event.preventDefault();
		var cid = $(this).attr('cid');
		
			$.ajax({
			url		:	"action.php",
			method	:	"POST",
			data	:	{get_seleted_Category:1,cat_id:cid},
			success	:	function(data){
				$("#get_product").html(data);
				if($("body").width() < 480){
					$("body").scrollTop(683);
				}
			}
		})
	
	})

	
	function product(){
		$.ajax({
			url	:	"action.php",
			method:	"POST",
			data	:	{getProduct:1},
			success	:	function(data){
				$("#get_product").html(data);
			}
		})
	}
	
	
	cart_count();
		$("body").delegate("#product","click",function(event){

		event.preventDefault();
		var pro_id=$(this).attr('pid');

		$.ajax({
			url: "action.php",
			method:"POST",
			data:{addProduct:1,proId:pro_id},
			success:function(data){
				cart_count();
				cart_container();
				$("#product_msg").html(data);

			}
		})
	})
	
	cart_container();
	function cart_container(){
		$.ajax({
			url: "action.php",
			method:"POST",
			data:{Common:1,get_cart_product:1},
			success:function(data){

				$("#cart_product").html(data);

			}
	})
	};
	
	cart_count();
	function cart_count()
	{
		$.ajax({
			url: "action.php",
			method:"POST",
			data:{cart_count:1},
			success:function(data){
				$(".badge").html(data);
				cart_count();
			}
	})
		
	}
		
	
	/*$("#cart_container").click(function(){
		event.preventDefault();
		
		$.ajax({
			url: "action.php",
			method:"POST",
			data:{get_cart_product:1},
			success:function(data){
				$("#cart_product").html(data);
			}
	})
	
	})*/
	
		$("#search_btn").click(function(){
		
		var keyword = $("#search").val();
		if(keyword != ""){
			$.ajax({
			url		:	"action.php",
			method	:	"POST",
			data	:	{search:1,keyword:keyword},
			success	:	function(data){ 
				$("#get_product").html(data);
				if($("body").width() < 480){
					$("body").scrollTop(683);
				}
			}
			})
		}
		})
		
		/*$("#signup").click(function(event){
			
			
		event.preventDefault();
		
			$.ajax({
			url		:	"customer_registration.php",
			method	:	"POST",
			data	:	$("form").serialize(),
			success	:	function(data){ 
							$("#signup_msg").html(data);
							alert(data);
							
							

			}
			})
})

/*$("#login").click(function(event){
			
			event.preventDefault();
			var email=$("#email").val();
			var password=$("#password").val();
			$.ajax({
			url		:	"customer_farmer_login.php",
			method	:	"POST",
			data	:	{userLogin:1,userEmail:email,userPassword:password},
			success	:	function(data){ 
							/*$("#login_msg").html(data)
							alert(data);
							

			}
			})
})*/



 /*$("#country").autocomplete("action.php", {
	 
		selectFirst: true
	})*/
	checkout();
	function checkout()
	{
		$.ajax({
			url: "action.php",
			method:"POST",
			data:{Common:1,checkout:1},
			success:function(data){
				$("#checkout").html(data);
			}
	})
	}
	
	$("body").delegate(".qty","keyup",function(){
		var pro_id=$(this).attr("pid");

		var qty=$("#qty-"+pro_id).val();
		var price=$("#price-"+pro_id).val();
		var total=qty*price;
		$("#total-"+pro_id).val(total);
		
		
	})
	
	
	$("body").delegate(".remove","click",function(event){
	event.preventDefault();
	var pro_id=$(this).attr('pid');

	
	$.ajax({
			url: "action.php",
			method:"POST",
			data:{removeFromCart:1,removeId:pro_id},
			success:function(data){
				checkout();
				$('#cart_message').html(data);
			}
	})
	
	})
	
	$("body").delegate(".update","click",function(event){
	event.preventDefault();
	var pro_id=$(this).attr('pid');
	var qty=$("#qty-"+pro_id).val();
	var price=$("#price-"+pro_id).val();
	var total=$("#total-"+pro_id).val();
	
	$.ajax({
			url: "action.php",
			method:"POST",
			data:{UpdateCart:1,UpdateId:pro_id,qty:qty,price:price,total:total},
			success:function(data){
				checkout();
				$('#cart_message').html(data);
			}
	})
	
	})
	
	page();
	function page()
	{
		$.ajax({
			url: "action.php",
			method:"POST",
			data:{page:1},
			success:function(data)
			{
				$('#pageno').html(data);
			}
		})
	}
	
	$("body").delegate("#page","click",function(){
		var pn=$(this).attr("page");
		
		$.ajax({
			url: "action.php",
			method:"POST",
			data:{getProduct:1,setpage:1,pagenumber:pn},
			success:function(data)
			{
				$('#get_product').html(data);
			}
		})
		
		
	})

		
})