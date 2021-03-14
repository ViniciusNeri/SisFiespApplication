
function deletarApoioEscolar(idApoioEscolar) {

	swal({
		title: "Excluir Apoio Escolar",
		text: "Confirma a exclusão do Apoio Escolar?",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				var dados = "";

				if (idApoioEscolar != "") {
					dados += '{name:"Id", value:"' + idApoioEscolar + '"},';
				}

				dadosEnvio = eval("[" + dados + "]");

				$.ajax({
					url: "/ApoiosEscolar/Delete",
					method: "POST",
					data: dadosEnvio,
					success: function (data) {
						swal({
							title: "Sucesso!",
							text: "Apoio Escolar excluido com Sucesso",
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

function salvarApoioEscolar(acao) {

	
	var dados = "";
	var method = "Create";
	var mensagem = "Apoio Escolar cadastrado com Sucesso.";

	if (acao != 'Incluir') {

		method = "Edit";
		mensagem = "Apoio Escolar editado com Sucesso.";

		if ($('#codigoApoioEscolar').val() != "") {
			dados += '{name:"Codigo", value:"' + $('#codigoApoioEscolar').val() + '"},';
		}
	}

	if ($('#nomeidApoioEscolar').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeApoioEscolar').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome do Apoio Escolar está vazio!",
			icon: "error",
		});
		return;
	}

	dadosEnvio = eval("[" + dados + "]");

	$.ajax({
		url: "/ApoiosEscolar/" + method,
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: mensagem,
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