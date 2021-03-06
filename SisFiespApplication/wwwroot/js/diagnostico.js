
function deletarDiagnostico(idDiagnostico) {

	swal({
		title: "Excluir Diagostico",
		text: "Confirma a exclusão do Diagnostico?",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				var dados = "";

				if (idDiagnostico != "") {
					dados += '{name:"Id", value:"' + idDiagnostico + '"},';
				}

				dadosEnvio = eval("[" + dados + "]");

				$.ajax({
					url: "/Diagnosticos/Delete",
					method: "POST",
					data: dadosEnvio,
					success: function (data) {
						swal({
							title: "Sucesso!",
							text: "Diagnostico excluido com Sucesso",
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

function salvarDiagnostico(acao) {

	
	var dados = "";
	var method = "Create";
	var mensagem = "Diagnostico cadastrado com Sucesso.";

	if (acao != 'Incluir') {

		method = "Edit";
		mensagem = "Diagnostico editado com Sucesso.";

		if ($('#idDiagnostico').val() != "") {
			dados += '{name:"Codigo", value:"' + $('#idDiagnostico').val() + '"},';
		}
	}

	if ($('#nomeDiagnostico').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeDiagnostico').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome da Escola está vazio!",
			icon: "error",
		});
		return;
	}

	dadosEnvio = eval("[" + dados + "]");

	$.ajax({
		url: "/Diagnosticos/" + method,
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