
function deletarModalidade(idModalidade) {

	swal({
		title: "Excluir Modalidade",
		text: "Confirma a exclusão da Modalidade?",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				var dados = "";

				if (idModalidade != "") {
					dados += '{name:"Id", value:"' + idModalidade + '"},';
				}

				dadosEnvio = eval("[" + dados + "]");

				$.ajax({
					url: "/Modalidades/Delete",
					method: "POST",
					data: dadosEnvio,
					success: function (data) {
						swal({
							title: "Sucesso!",
							text: "Modalidade excluida com Sucesso",
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

function salvarModalidade(acao) {

	
	var dados = "";
	var method = "Create";
	var mensagem = "Modalidade cadastrada com Sucesso.";

	if (acao != 'Incluir') {

		method = "Edit";
		mensagem = "Modalidade editada com Sucesso.";

		if ($('#idModalidade').val() != "") {
			dados += '{name:"Codigo", value:"' + $('#idModalidade').val() + '"},';
		}
	}

	if ($('#nomeModalidade').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeModalidade').val() + '"},';
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
		url: "/Modalidades/" + method,
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