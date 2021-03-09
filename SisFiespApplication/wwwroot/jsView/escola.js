
function deletarEscola(idEscola) {

	swal({
		title: "Excluir Escola",
		text: "Confirma a exclusão da escola?",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				var dados = "";

				if (idEscola != "") {
					dados += '{name:"Id", value:"' + idEscola + '"},';
				}

				dadosEnvio = eval("[" + dados + "]");

				$.ajax({
					url: "/Escolas/Delete",
					method: "POST",
					data: dadosEnvio,
					success: function (data) {
						swal({
							title: "Sucesso!",
							text: "Escola excluido com Sucesso",
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

function salvarEscola() {

	var dados = "";

	if ($('#NUEEscola').val() != "") {
		dados += '{name:"NUE", value:"' + $('#NUEEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nº UE da Escola está vazio!",
			icon: "error",
		});
		return;
	}

	if ($('#nomeEscola').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome da Escola está vazio!",
			icon: "error",
		});
		return;
	}

	if ($('#diretorEscola').val() != "") {
		dados += '{name:"UsuarioCodigo", value:"' + $('#diretorEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Diretor(a )da escola está vazio!",
			icon: "error",
		});
		return;
	}

	if ($('#emailEscola').val() != "") {
		dados += '{name:"Email", value:"' + $('#emailEscola').val() + '"},';
	}
	if ($('#telefoneEscola').val() != "") {
		dados += '{name:"Telefone", value:"' + $('#telefoneEscola').val() + '"},';
	}
	if ($('#telefone2Escola').val() != "") {
		dados += '{name:"Telefone2", value:"' + $('#telefone2Escola').val() + '"},';
	}
	if ($('#bairroEscola').val() != "") {
		dados += '{name:"Bairro", value:"' + $('#bairroEscola').val() + '"},';
	}
	if ($('#cidadeEscola').val() != "") {
		dados += '{name:"Cidade", value:"' + $('#cidadeEscola').val() + '"},';
	}
	if ($('#enderecoEscola').val() != "") {
		dados += '{name:"Endereco", value:"' + $('#enderecoEscola').val() + '"},';
	}
	if ($('#caractSocioEcon').val() != "") {
		dados += '{name:"CaractSocioEcon", value:"' + $('#caractSocioEcon').val() + '"},';
	}
	if ($('#RecursoRegiao').val() != "") {
		dados += '{name:"RecursoRegiao", value:"' + $('#RecursoRegiao').val() + '"},';
	}
	if ($('#cP1').val() != "") {
		dados += '{name:"CP1", value:"' + $('#cP1').val() + '"},';
	}
	if ($('#cP2').val() != "") {
		dados += '{name:"CP2", value:"' + $('#cP2').val() + '"},';
	}

	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Escolas/Create",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Escola cadastrada com Sucesso.",
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

function mostrarAlert() {
	alert("1");
}

function salvarEscolaEdit() {

	var dados = "";

	if ($('#NUEEscola').val() != "") {
		dados += '{name:"NUE", value:"' + $('#NUEEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nº UE da Escola está vazio!",
			icon: "error",
		});
		return;
	}

	if ($('#nomeEscola').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome da Escola está vazio!",
			icon: "error",
		});
		return;
	}

	if ($('#diretorEscola').val() != "") {
		dados += '{name:"UsuarioCodigo", value:"' + $('#diretorEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Diretor(a )da escola está vazio!",
			icon: "error",
		});
		return;
	}

	if ($('#emailEscola').val() != "") {
		dados += '{name:"Email", value:"' + $('#emailEscola').val() + '"},';
	}
	if ($('#telefoneEscola').val() != "") {
		dados += '{name:"Telefone", value:"' + $('#telefoneEscola').val() + '"},';
	}
	if ($('#telefone2Escola').val() != "") {
		dados += '{name:"Telefone2", value:"' + $('#telefone2Escola').val() + '"},';
	}
	if ($('#bairroEscola').val() != "") {
		dados += '{name:"Bairro", value:"' + $('#bairroEscola').val() + '"},';
	}
	if ($('#cidadeEscola').val() != "") {
		dados += '{name:"Cidade", value:"' + $('#cidadeEscola').val() + '"},';
	}
	if ($('#enderecoEscola').val() != "") {
		dados += '{name:"Endereco", value:"' + $('#enderecoEscola').val() + '"},';
	}
	if ($('#caractSocioEcon').val() != "") {
		dados += '{name:"CaractSocioEcon", value:"' + $('#caractSocioEcon').val() + '"},';
	}
	if ($('#RecursoRegiao').val() != "") {
		dados += '{name:"RecursoRegiao", value:"' + $('#RecursoRegiao').val() + '"},';
	}
	if ($('#cP1').val() != "") {
		dados += '{name:"CP1", value:"' + $('#cP1').val() + '"},';
	}
	if ($('#cP2').val() != "") {
		dados += '{name:"CP2", value:"' + $('#cP2').val() + '"},';
	}
	if ($('#idEscola').val() != "") {
		dados += '{name:"Codigo", value:"' + $('#idEscola').val() + '"},';
	}
	dadosEnvio = eval("[" + dados + "]");

	$.ajax({
		url: "/Escolas/Edit",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Escola editada com Sucesso.",
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
