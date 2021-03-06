
function deletarUsuario(idUsuario) {

	swal({
		title: "Excluir Usuário",
		text: "Confirma a exclusão do usuário?",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				var dados = "";

				if (idUsuario != "") {
					dados += '{name:"Id", value:"' + idUsuario + '"},';
				}

				dadosEnvio = eval("[" + dados + "]");

				$.ajax({
					url: "/Usuarios/Delete",
					method: "POST",
					data: dadosEnvio,
					success: function (data) {
						swal({
							title: "Sucesso!",
							text: "Usuário excluido com Sucesso",
							icon: "success",
						});

						//$("#pagina").html(data).find('.page-wrapper')
						var doc = new DOMParser().parseFromString(data, "text/html");
						var subtabelas = doc.getElementsByClassName("main-body");
						var div = document.getElementById("pagina");
						div.innerHTML = subtabelas[0].innerHTML

					},
					error: function (data) {
						swal({
							title: "Erro ao Excluir!",
							text: "Erro desconhecido!",
							icon: "error",
						});
					}
				});
			}
		});
}

function salvarUsuario() {

	var dados = "";

	if ($('#nomeUsuario').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome do Usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#loginUsuario').val() != "") {
		dados += '{name:"Login", value:"' + $('#loginUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Login do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#senhaUsuario').val() != "") {

		if ($('#senhaUsuario').val() != "" && $('#senhaConfirmacaoUsuario').val() == "") {
			swal({
				title: "Erro ao cadastrar!",
				text: "Confirmação da senha está vazia!",
				icon: "error",
			});
			return;
		} else {
			if ($('#senhaUsuario').val() != "" && $('#senhaConfirmacaoUsuario').val() != "") {

				if ($('#senhaUsuario').val() != $('#senhaConfirmacaoUsuario').val()) {
					swal({
						title: "Erro ao cadastrar!",
						text: "A senha está diferente da confirmação da senha!",
						icon: "error",
					});
					return;
				} else {
					dados += '{name:"Senha", value:"' + $('#senhaUsuario').val() + '"},';
				}
			} else {
				dados += '{name:"Senha", value:"' + $('#senhaUsuario').val() + '"},';
			}
		}

	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Senha do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#emailUsuario').val() != "") {
		dados += '{name:"Email", value:"' + $('#emailUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Email do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#funcaoUsuario').val() != "") {
		dados += '{name:"Funcao", value:"' + $('#funcaoUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Função do usuário está vazio!",
			icon: "error",
		});
		return;
	}

	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Usuarios/Create",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Usuário cadastrado com Sucesso.",
				icon: "success",
			});

			//$("#pagina").html(data).find('.page-wrapper')
			var doc = new DOMParser().parseFromString(data, "text/html");
			var subtabelas = doc.getElementsByClassName("main-body");
			var div = document.getElementById("pagina");
			div.innerHTML = subtabelas[0].innerHTML

		},
		error: function (data) {
			swal({
				title: "Erro ao cadastrar!",
				text: "Erro desconhecido!",
				icon: "error",
			});
		}
	});
}

function mostrarSenha() {

	var passwordField = $('#senhaUsuario');

	var passwordFieldType = passwordField.attr('type');

	if (passwordFieldType == 'password') {

		passwordField.attr('type', 'text');

	} else {
		passwordField.attr('type', 'password');
	}

}

function mostrarSenhaConfirma() {

	var passwordField = $('#senhaConfirmacaoUsuario');

	var passwordFieldType = passwordField.attr('type');

	if (passwordFieldType == 'password') {

		passwordField.attr('type', 'text');

	} else {
		passwordField.attr('type', 'password');
	}

}

function mostrarAlert() {
	alert("1");
}

function salvarUsuarioEdit() {

	var dados = "";

	if ($('#nomeUsuario').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome do Usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#loginUsuario').val() != "") {
		dados += '{name:"Login", value:"' + $('#loginUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Login do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#senhaUsuario').val() != "") {

		if ($('#senhaUsuario').val() != "" && $('#senhaConfirmacaoUsuario').val() == "") {
			swal({
				title: "Erro ao cadastrar!",
				text: "Confirmação da senha está vazia!",
				icon: "error",
			});
			return;
		} else {
			if ($('#senhaUsuario').val() != "" && $('#senhaConfirmacaoUsuario').val() != "") {

				if ($('#senhaUsuario').val() != $('#senhaConfirmacaoUsuario').val()) {
					swal({
						title: "Erro ao cadastrar!",
						text: "A senha está diferente da confirmação da senha!",
						icon: "error",
					});
					return;
				} else {
					dados += '{name:"Senha", value:"' + $('#senhaUsuario').val() + '"},';
				}
			} else {
				dados += '{name:"Senha", value:"' + $('#senhaUsuario').val() + '"},';
			}
		}

	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Senha do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#emailUsuario').val() != "") {
		dados += '{name:"Email", value:"' + $('#emailUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Email do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#funcaoUsuario').val() != "") {
		dados += '{name:"Funcao", value:"' + $('#funcaoUsuario').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Função do usuário está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#idUsuario').val() != "") {
		dados += '{name:"Codigo", value:"' + $('#idUsuario').val() + '"},';
	}


	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Usuarios/Edit",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Usuário editado com Sucesso.",
				icon: "success",
			});

			//$("#pagina").html(data).find('.page-wrapper')
			var doc = new DOMParser().parseFromString(data, "text/html");
			var subtabelas = doc.getElementsByClassName("main-body");
			var div = document.getElementById("pagina");
			div.innerHTML = subtabelas[0].innerHTML

		},
		error: function (data) {
			swal({
				title: "Erro ao cadastrar!",
				text: "Erro desconhecido!",
				icon: "error",
			});
		}
	});
}

function mostrarSenha() {

	var passwordField = $('#senhaUsuario');

	var passwordFieldType = passwordField.attr('type');

	if (passwordFieldType == 'password') {

		passwordField.attr('type', 'text');

	} else {
		passwordField.attr('type', 'password');
	}

}

function mostrarSenhaConfirma() {

	var passwordField = $('#senhaConfirmacaoUsuario');

	var passwordFieldType = passwordField.attr('type');

	if (passwordFieldType == 'password') {

		passwordField.attr('type', 'text');

	} else {
		passwordField.attr('type', 'password');
	}

}