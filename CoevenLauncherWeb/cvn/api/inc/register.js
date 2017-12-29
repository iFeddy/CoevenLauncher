	var defcolor = "#2F2842";
	var redcolor = "#FF4949";
	var greencolor = "#24CF98";
	var userOk = 0;
	var emailOk = 0;
	var pass1Ok = 0;
	var pass2Ok = 0;
	
	formRemovebackspace();
	checkUser();
	checkEmail();
	checkPasswords();
	submitValidate();
	
	//Crear Cuenta^
	

	function formRemovebackspace(){
		$("form").on({
keydown: function(e) {
				if (e.which === 32)
				return false;
			},
change: function() {
				value = value.replace(/\s/g, "");
			}
		});
	}
	
	function submitValidate() {
		$( document ).ready(function() {
			$( "#submit" ).click(function( event ) {
				event.preventDefault();
				
				var iPass01 = $("#pass1").val();
				var pass = iPass01.replace(/\s+/g, '');
				
				var iPass02 = $("#pass2").val();
				var pass2 = iPass02.replace(/\s+/g, '');
				
				var iUser = $("#cuser").val();
				var validateUser = iUser.replace(/\s+/g, '');
				
				var iEmail = $("#cemail").val();
				var validateEmail = iEmail.replace(/\s+/g, '');

				if(pass != pass2){
					$("#pass1").css( "border-color", redcolor );
					$("#pass2").css( "border-color", redcolor );
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p>Las contraseñas no coinciden</p>" );
					return;
				}
				else{
					$("#pass1").css( "border-color", greencolor );
					$("#pass2").css( "border-color", greencolor );
					pass1Ok = 1;
					pass2Ok = 1;
					$( "#notification" ).hide( "slow" );
				}
				
				if(($.trim(validateUser).length < 1) || ($.trim(validateEmail).length < 1) || ($.trim(pass).length < 1) || ($.trim(pass2).length < 1))
				{
					$("#cuser").css( "border-color", redcolor );
					$("#cemail").css( "border-color", redcolor );
					$("#pass1").css( "border-color", redcolor );
					$("#pass2").css( "border-color", redcolor );
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p>Debes completar todos los campos</p>" );
					return;
				}
				else if (userOk == 0){
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p>Debes seleccionar un usuario valido para continuar</p>" );
					return;
				}else if (emailOk == 0){
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p>Debes seleccionar un correo electronico valido para continuar</p>" );
					return;
				}
				else{
					//todo bien
					$("#cuser").css( "border-color", greencolor );
					$("#cemail").css( "border-color", greencolor );
					$("#pass1").css( "border-color", greencolor );
					$("#pass2").css( "border-color", greencolor );	
					
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p><img style=\"float: none;margin-top: 5px;margin-left: 0;\" src=\"img/icon/ajaxLoad.gif\"></img></p>" );
					
					crearCuenta(validateUser,pass,pass2,validateEmail);
					//$("#notification p").replaceWith( "<p>Cuenta Creada Satisfactoriamente.. (Demo)</p>" );

				}
			});
		});
	}
	function checkUser(){
		//if(UserExists)
		$("#cuser").change(function(){
			
			var usuario = $("#cuser").val();
			$( "#notification" ).hide( "slow" );
			//var email = new RegExp('^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$');
			var validUser = new RegExp('^[A-Za-z0-9_]*[A-Za-z0-9][A-Za-z0-9_]*$');
			$("#noUser").css("display","none");
			$("#siUser").css("display","none");
			
			if (!(validUser.test(usuario))) {
				$("#cuser").css( "border-color", redcolor );
				$( "#notification" ).show( "slow" );
				$("#notification p").replaceWith( "<p>No puedes utilizar caracteres especiales en tu nombre de usuario.</p>" );
				userOk = 0;
				return;
			}
			
			else if($.trim(usuario).length == 0)
			{
				$("#cuser").css( "border-color", redcolor );
				userOk = 0;
				return
			}
			
			else if($.trim(usuario).length < 5)
			{
				$("#cuser").css( "border-color", redcolor );
				$( "#notification" ).show( "slow" );
				$("#notification p").replaceWith( "<p>El nombre de usuario no puede ser inferior a los 5 caracteres de largo.</p>" );
				userOk = 0;
				return
			}
			
			else if($.trim(usuario).length > 15 )
			{
				$("#cuser").css( "border-color", redcolor );
				$( "#notification" ).show( "slow" );
				$("#notification p").replaceWith( "<p>El nombre de usuario no puede superar los 15 caracteres de largo.</p>" );
				userOk = 0;
				return
			}
			else{

				$("#userAjax").css("display","block");

				$.get( "inc/isUserActive.php?cUser="+usuario, function(data) {
					if(data == "si"){
						$("#userAjax").css("display","none");
						$("#noUser").css("display","block");
						$("#cuser").css( "border-color", redcolor );
						$( "#notification" ).hide( "slow" );
						userOk = 0;
					}else{
						$("#userAjax").css("display","none");
						$("#siUser").css("display","block");
						$("#cuser").css( "border-color", greencolor );
						userOk = 1;
					}
				});
			}
		});

	}
	function validateEmail(email) { 
		var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return re.test(email);
	}
	function checkEmail(){
	//if(UserExists)
	$("#cemail").change(function(){

		var email = $("#cemail").val();
		$( "#notification" ).hide( "slow" );
		
		$("#noEmail").css("display","none");
		$("#siEmail").css("display","none");
		if($.trim(email).length == 0)
		{
			emailOk = 0;
			$("#cemail").css( "border-color", redcolor );
			return
		}
			
		if(!(validateEmail(email))){
			$("#cemail").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>Ingresaste una direccion de correo electronico invalida.</p>" );
			emailOk = 0;
			return;
		}

		else if($.trim(email).length < 4)
		{
			$("#cemail").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>Email Incorrecto</p>" );
			emailOk = 0;
			return
		}
		
		else{

			$("#emailAjax").css("display","block");

			$.get( "inc/isUserActive.php?cEmail="+email, function(data) {
				if(data == "si"){
					$("#emailAjax").css("display","none");
					$("#noEmail").css("display","block");
					$("#cemail").css( "border-color", redcolor );
					emailOk = 0;
				}else{
					$("#emailAjax").css("display","none");
					$("#siEmail").css("display","block");
					$("#cemail").css( "border-color", greencolor );
					emailOk = 1;
					$( "#notification" ).hide( "slow" );
				}
			});
		}
	});

	}
	function checkPasswords(){

	$("#pass1").change(function(){
		var pass1 = $("#pass1").val();
		$( "#notification" ).hide( "slow" );

		if($.trim(pass1).length < 7)
		{
			$("#pass1").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>La contraseña debe superar los 8 caracteres de largo.</p>" );
			return
		}	
		$("#pass1").css("border-color", greencolor);
		$( "#notification" ).hide( "slow" );
		});
		
		$("#pass2").change(function(){
		var pass2 = $("#pass2").val();
		$( "#notification" ).hide( "slow" );

		if($.trim(pass2).length < 7)
		{
			$("#pass2").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>La contraseña debe superar los 8 caracteres de largo.</p>" );
			return
		}	
		$("#pass2").css("border-color", greencolor);
		$( "#notification" ).hide( "slow" );
		});
		
		
	}
	function crearCuenta(var1,var2,var3,var4){
		
	$.get( "inc/RegisterDO.php?1="+var1+"&2="+var2+"&3="+var3+"&4="+var4, function(data) {
		
				if(data != ""){
					$("#notification p").replaceWith( "<p>"+data+"</p>" );
				}				
		});	
		
	}