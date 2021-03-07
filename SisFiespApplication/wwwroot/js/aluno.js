$(document).ready(function () {
	if ($("#observacaoAluno").val() != "" && $("#observacaoAluno").val() != undefined) {
		$("#observacaoAluno").val(unescape($("#observacaoAluno").val()));		
	}
	
});

function deletarAluno(idAluno) {

	swal({
		title: "Excluir Aluno",
		text: "Confirma a exclusão do aluno?",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				var dados = "";

				if (idAluno != "") {
					dados += '{name:"Id", value:"' + idAluno + '"},';
				}

				dadosEnvio = eval("[" + dados + "]");

				$.ajax({
					url: "/Alunos/Delete",
					method: "POST",
					data: dadosEnvio,
					success: function (data) {
						swal({
							title: "Sucesso!",
							text: "Aluno excluido com Sucesso",
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

function salvarAluno() {

	var dados = "";

	if ($('#nomeAluno').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeAluno').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome do Aluno está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#dtNascimento').val() != "") {
		dados += '{name:"dtNascimento", value:"' + $('#dtNascimento').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Data de Nascimento está vazia!",
			icon: "error",
		});
		return;
	}
	if ($('#codigoEscola').val() != "") {
		dados += '{name:"EscolaCodigo", value:"' + $('#codigoEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Escola está vazia!",
			icon: "error",
		});
		return;
	}

	if ($('#TurnoAluno').val() != "") {
		dados += '{name:"Turno", value:"' + $('#TurnoAluno').val() + '"},';
	}
	if ($('#NomeMae').val() != "") {
		dados += '{name:"NomeMae", value:"' + $('#NomeMae').val() + '"},';
	}
	if ($('#NomePai').val() != "") {
		dados += '{name:"NomePai", value:"' + $('#NomePai').val() + '"},';
	}
	if ($('#modalidadeAluno').val() != "") {
		dados += '{name:"ModalidadeCodigo", value:"' + $('#modalidadeAluno').val() + '"},';
	}
	if ($('#diagnosticoAluno').val() != "") {
		dados += '{name:"DiagnosticoCodigo", value:"' + $('#diagnosticoAluno').val() + '"},';
	}
	if ($('#mapeadoAluno').is(":checked") == true) {
		dados += '{name:"Mapeado", value:"1"},';
	} else {
		dados += '{name:"Mapeado", value:"0"},';
	}
	if ($('#observacaoAluno').val() != "") {
		dados += '{name:"Observacao", value:"' + escape($('#observacaoAluno').val()) + '"},';
	}
	
	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Alunos/Create",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Aluno cadastrado com Sucesso",
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

function salvarAlunoEdit() {

	var dados = "";

	if ($('#nomeAluno').val() != "") {
		dados += '{name:"Nome", value:"' + $('#nomeAluno').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nome do Aluno está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#dtNascimento').val() != "") {
		dados += '{name:"dtNascimento", value:"' + $('#dtNascimento').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Data de Nascimento está vazia!",
			icon: "error",
		});
		return;
	}
	if ($('#codigoEscola').val() != "") {
		dados += '{name:"EscolaCodigo", value:"' + $('#codigoEscola').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Escola está vazia!",
			icon: "error",
		});
		return;
	}

	if ($('#TurnoAluno').val() != "") {
		dados += '{name:"Turno", value:"' + $('#TurnoAluno').val() + '"},';
	}
	if ($('#StatusAluno').val() != "") {
		dados += '{name:"Status", value:"' + $('#StatusAluno').val() + '"},';
	}
	if ($('#NomeMae').val() != "") {
		dados += '{name:"NomeMae", value:"' + $('#NomeMae').val() + '"},';
	}
	if ($('#NomePai').val() != "") {
		dados += '{name:"NomePai", value:"' + $('#NomePai').val() + '"},';
	}
	if ($('#modalidadeAluno').val() != "") {
		dados += '{name:"ModalidadeCodigo", value:"' + $('#modalidadeAluno').val() + '"},';
	}
	if ($('#diagnosticoAluno').val() != "") {
		dados += '{name:"DiagnosticoCodigo", value:"' + $('#diagnosticoAluno').val() + '"},';
	}
	if ($('#mapeadoAluno').is(":checked") == true) {
		dados += '{name:"Mapeado", value:"1"},';
	} else {
		dados += '{name:"Mapeado", value:"0"},';
	}
	if ($('#observacaoAluno').val() != "") {
		dados += '{name:"Observacao", value:"' + escape($('#observacaoAluno').val()) + '"},';
	}
	if ($('#idAluno').val() != "") {
		dados += '{name:"Codigo", value:"' + $('#idAluno').val() + '"},'; 
	}
	dadosEnvio = eval("[" + dados + "]");
	
	$.ajax({
		url: "/Alunos/Edit",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Aluno editado com Sucesso",
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
