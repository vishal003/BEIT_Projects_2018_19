/*Validation for customer*/
$(function(){
$("form[name='buyer']").validate({
rules:{
            name: {
                    required: true,
                    minlength: 3
                },
            email: {
                    required: true,
                    email: true
                },
            mobile:{
                required:true,
                number:true,
                maxlength:10,
                minlength:10
            },
            gender:"required",
            pwd:{
                    required: true,
                    minlength: 6
                },
            cpwd:{
                    required: true,
                    equalTo: "#pwd"
            },
            agree: "required"
        },
        messages:{
                name: {
                    required:"Please Enter name",
                    minlength:"Enter valid name "
                },
                email: {
                    required:"Please Enter email address",
                    email:"Enter valid email address"
                },
                mobile:{
                    required:"Enter Contact Number",
                    number:"Enter only number",
                    maxlength:"Enter only 10 digits",
                    minlength:"Enter only 10 digits"
                },
                gender:"Select your gender",
                pwd: {
                    required: "Please enter a password",
                    minlength: "Your password must be at least 6 characters long"
                },
                cpwd:{
                    required: "Please re-enter password ",
                    equalTo: "Password does not match "
                },
                agree:"Please read and agree to the Terms and Conditions "
},
submitHandler: function(form){
form.submit();
}
});
});

/*validation for seller */
$(function(){
$("form[name='seller']").validate({
rules:{
            name: {
                    required: true,
                    minlength: 3
                },
            email: {
                    required: true,
                    email: true
                },
            mobile:{
                required:true,
                number:true,
                maxlength:10,
                minlength:10
            },
            gender:"required",
            pwd:{
                    required: true,
                    minlength: 6
                },
            cpwd:{
                    required: true,
                    equalTo: "#fpwd"
            },
            cert :"required",
            agree: "required"
        },
        messages:{
                name: {
                    required:"Please Enter name",
                    minlength:"Enter valid name "
                },
                email: {
                    required:"Please Enter email address",
                    email:"Enter valid email address"
                },
                mobile:{
                    required:"Enter Contact Number",
                    number:"Enter only number",
                    maxlength:"Enter only 10 digits",
                    minlength:"Enter only 10 digits"
                },
                gender:"Select your gender",
                pwd: {
                    required: "Please enter a password",
                    minlength: "Your password must be at least 6 characters long"
                },
                cpwd:{
                    required: "Please re-enter password ",
                    equalTo: "Password does not match "
                },
                cert:"Select your certificate",
                agree:"Please read and agree to the Terms and Conditions "
},
submitHandler: function(form){
form.submit();
}
});
});
