	var defcolor = "#2F2842";
	var redcolor = "#FF4949";
	var greencolor = "#24CF98";
	var pass1Ok = 0;
	var pass2Ok = 0;
	var pass3Ok = 0;
	
	formRemovebackspace();
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
				
				var iPass03 = $("#pass3").val();
				var pass3 = iPass03.replace(/\s+/g, '');
				
				var token = $("#token").val();
				
				
				if(pass2 != pass3){
					$("#pass1").css( "border-color", redcolor );
					$("#pass2").css( "border-color", redcolor );
					$("#pass3").css( "border-color", redcolor );
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p>Las contraseñas no coinciden</p>" );
					return;
				}
				
				else{
					$("#pass1").css( "border-color", greencolor );
					$("#pass2").css( "border-color", greencolor );
					$("#pass3").css( "border-color", greencolor );
					$( "#notification" ).hide( "slow" );
				}
				
				if(($.trim(pass).length < 1) || ($.trim(pass2).length < 1) || ($.trim(pass3).length < 1))
				{
					
					$("#pass1").css( "border-color", redcolor );
					$("#pass2").css( "border-color", redcolor );
					$("#pass3").css( "border-color", redcolor );
					$( "#notification" ).show( "slow" );
					$("#notification p").replaceWith( "<p>Debes completar todos los campos</p>" );
					return;
				}
				else{
					//todo bien
					$("#pass1").css( "border-color", greencolor );
					$("#pass2").css( "border-color", greencolor );	
					$("#pass3").css( "border-color", greencolor );	
					
					$( "#notification" ).show( "slow" );
			    	$("#notification p").replaceWith( "<p><img style=\"float: none;margin-top: 5px;margin-left: 0;\" src=\"img/icon/ajaxLoad.gif\"></img></p>" );
				
					cambiarPass(token,pass,pass2,pass3);
					//$("#notification p").replaceWith( "<p>Cuenta Creada Satisfactoriamente.. (Demo)</p>" );

				}
			});
		});
	}
function checkPasswords(){

	$("#pass1").change(function(){
		var pass1 = $("#pass1").val();
		$( "#notification" ).hide( "slow" );

		if($.trim(pass1).length < 8)
		{
			$("#pass1").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>La contraseña debe superar los 8 caracteres de largo.</p>" );
			return
		}	
		$("#pass1").css("border-color", greencolor);
		pass1Ok = 1;

		$( "#notification" ).hide( "slow" );
		});
		
		$("#pass2").change(function(){
		var pass2 = $("#pass2").val();
		$( "#notification" ).hide( "slow" );

		if($.trim(pass2).length < 8)
		{
			$("#pass2").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>La contraseña debe superar los 8 caracteres de largo.</p>" );
			return
		}	
		$("#pass2").css("border-color", greencolor);
		pass2Ok = 1;
		
		$( "#notification" ).hide( "slow" );
		});
		
		$("#pass3").change(function(){
		var pass3 = $("#pass3").val();
		$( "#notification" ).hide( "slow" );

		if($.trim(pass3).length < 8)
		{
			$("#pass3").css( "border-color", redcolor );
			$( "#notification" ).show( "slow" );
			$("#notification p").replaceWith( "<p>La contraseña debe superar los 8 caracteres de largo.</p>" );
			return
		}	
		$("#pass3").css("border-color", greencolor);
		pass3Ok = 1;
		$( "#notification" ).hide( "slow" );
		});
		
	}
	
function cambiarPass(var1,var2,var3,var4){
		
	$.get( "inc/main_changepass_do.php?1="+var1+"&2="+var2+"&3="+var3+"&4="+var4, function(data) {
		
				if(data != ""){
					$("#notification p").replaceWith( "<p>"+data+"</p>" );
				}				
		});	
		
	}