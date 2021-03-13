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

function salvarAvaliacao() {

	var dados = "";

	if ($('#alunoCodigo').val() != "") {
		dados += '{name:"AlunoCodigo", value:"' + $('#alunoCodigo').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Aluno não foi selecionado!",
			icon: "error",
		});
		return;
	}
	if ($('#usuarioCodigo').val() != "") {
		dados += '{name:"UsuarioCodigo", value:"' + $('#usuarioCodigo').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Especialista não foi selecionado!",
			icon: "error",
		});
		return;
	}

	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Avaliacoes/Create",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Avaliação cadastrada com Sucesso",
				icon: "success",
			});
			$("#detalheAvaliacao").html(data);
			$("#detalheAvaliacao").attr("style", "display:block");
			$("#btVoltar").attr("style", "display:block;");
			$("#btSalvar").attr("style", "display:none;");
			$("#alunoCodigo").attr("disabled", "disabled");
			$("#usuarioCodigo").attr("disabled", "disabled");



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

function salvarAvaliacaoDetalhe() {

	$("#fecharModal").click();

	var dados = "";

	if ($('#dadosProcedimento').val() != "") {
		dados += '{name:"Procedimento", value:"' + escape($('#dadosProcedimento').val()) + '"},';
	}
	if ($('#dadosEnvolvidos').val() != "") {
		dados += '{name:"Envolvidos", value:"' + ($('#dadosEnvolvidos').val()) + '"},';
	}
	if ($('#dadosDescAcao').val() != "") {
		dados += '{name:"DescAcao", value:"' + escape($('#dadosDescAcao').val()) + '"},';
	}
	if ($('#dadosConduta').val() != "") {
		dados += '{name:"Conduta", value:"' + escape($('#dadosConduta').val()) + '"},';
	}
	if ($('#codigoAvaliacao').val() != "") {
		dados += '{name:"AvaliacaoCodigo", value:"' + $('#codigoAvaliacao').val() + '"},';
	}
	if ($('#avaliacaoDetalheCodigo').val() != "") {
		dados += '{name:"Codigo", value:"' + $('#avaliacaoDetalheCodigo').val() + '"},';
	} else {
		dados += '{name:"Codigo", value:"0"},';
	}
	if ($('#dadosProcedimento').val() == "" && $('#dadosEnvolvidos').val() == "" && $('#dadosDescAcao').val() == "" && $('#dadosConduta').val() == "") {
		swal({
			title: "Erro ao cadastrar!",
			text: "Nenhuma informação foi inserida!",
			icon: "error",
		});
	}
	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Avaliacoes/CreateDetalhe",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {

			swal({
				title: "Sucesso!",
				text: "Avaliação cadastrada com Sucesso",
				icon: "success",
			});

			//$("#detalheAvaliacao").html(data);
			window.setTimeout(function () {
				document.location.reload(true);
			}, 2000);
			

			

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

function buscarDados() {

	if ($("#alunoCodigo").val() == "") {
		$("#dados").attr("style", "display:none")
	} else {

		var dados = "";

		if ($('#alunoCodigo').val() != "") {
			dados += '{name:"alunoCodigo", value:"' + $('#alunoCodigo').val() + '"},';
		}

		dadosEnvio = eval("[" + dados + "]");


		$.ajax({
			url: "/Avaliacoes/DetalheAluno",
			method: "GET",
			data: dadosEnvio,
			dataType: "json",
			success: function (data) {

				//Aluno

				$("#nomeAluno").html(" <h6 class=\"m - b - 30\">" + data.nomeAluno + "</h6>");
				$("#dtNascimentoAluno").html(" <h6 class=\"m - b - 30\">" + data.dataNascimentoAluno + "</h6>");
				if (data.modalidadeAluno != null)
					$("#modalidadeAluno").html(" <h6 class=\"m - b - 30\">" + data.modalidadeAluno + "</h6>");
				if (data.diagnoscoAluno != null)
					$("#diagnosticoAluno").html(" <h6 class=\"m - b - 30\">" + data.diagnoscoAluno + "</h6>");
				if (data.nomeMae != null)
					$("#nomeMaeAluno").html(" <h6 class=\"m - b - 30\">" + data.nomeMae + "</h6>");
				if (data.nomePai != null)
					$("#nomePaiAluno").html(" <h6 class=\"m - b - 30\">" + data.nomePai + "</h6>");
				if (data.turnoAluno != null) {
					if (data.turnoAluno == 1) {
						$("#turnoAluno").html(" <h6 class=\"m - b - 30\">Manhã</h6>");
					} else if (data.turnoAluno == 2) {
						$("#turnoAluno").html(" <h6 class=\"m - b - 30\">Tarde</h6>");
					} else
						$("#turnoAluno").html(" <h6 class=\"m - b - 30\">Noite</h6>");
				}
				$("#observacaoAluno").val(unescape(data.observacaoAluno));

				//Escola
				$("#nueEscola").html(" <h6 class=\"m - b - 30\">" + data.nueEscola + "</h6>");
				$("#nomeEscola").html(" <h6 class=\"m - b - 30\">" + data.nomeEscola + "</h6>");
				if (data.telefoneEscola != null)
					$("#telefoneEscola").html(" <h6 class=\"m - b - 30\">" + data.telefoneEscola + "</h6>");
				if (data.telefone2Escola != null)
					$("#telefone2Escola").html(" <h6 class=\"m - b - 30\">" + data.telefone2Escola + "</h6>");
				if (data.cidadeEscola != null)
					$("#cidadeEscola").html(" <h6 class=\"m - b - 30\">" + data.cidadeEscola + "</h6>");
				if (data.bairroEscola != null)
					$("#bairroEscola").html(" <h6 class=\"m - b - 30\">" + data.bairroEscola + "</h6>");
				if (data.diretorEscola != null)
					$("#diretorEscola").html(" <h6 class=\"m - b - 30\">" + data.diretorEscola + "</h6>");
				if (data.cp1Escola != null)
					$("#cp1Escola").html(" <h6 class=\"m - b - 30\">" + data.cp1Escola + "</h6>");
				if (data.cp2Escola != null)
					$("#cp2Escola").html(" <h6 class=\"m - b - 30\">" + data.cp2Escola + "</h6>");

				$("#dados").attr("style", "display:block");
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
}

function buscarDadosDetalhe(AvaliacaoDetalheCodigo) {

	var dados = "";

	if (AvaliacaoDetalheCodigo != "") {
		dados += '{name:"id", value:"' + AvaliacaoDetalheCodigo + '"},';
	}

	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Avaliacoes/PartialDetalheAvaliacao",
		method: "GET",
		data: dadosEnvio,
		success: function (data) {
			$("#modaldetalheAvaliacao").html(data);
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

function limparCampos() {

	$('#dadosProcedimento').val("");
	$('#dadosEnvolvidos').val("")
	$('#dadosDescAcao').val("")
	$('#dadosConduta').val("")
	$('#avaliacaoDetalheCodigo').val("")
}

function bytesToSize(bytes) {
	var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
	if (bytes == 0) return '0 Byte';
	var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
	return Math.round(bytes / Math.pow(1024, i), 2) + ' ' + sizes[i];
}

$(document).ready(function () {
	$('input[name="file"]').change(function () {
		var file = $('input[name="file"]')[0].files[0];
		$('.size-file').html(bytesToSize(file.size));
	});
});

async function AJAXSubmit(form) {

	var formData = new FormData($(form)[0]);
	var computedProgress = function (evt) {
		if (evt.lengthComputable) {
			var percentComplete = evt.loaded / evt.total;
			var percentComplete = Math.round(event.loaded * 100 / event.total) + "%";
			$('.percent-progress').html(percentComplete);
			$('.progress-bar').css("width", percentComplete);
		}
	};
	$.ajax({
		url: "/Avaliacoes/File",
		type: 'POST',
		xhr: function () {
			var xhr = new window.XMLHttpRequest();

			xhr.addEventListener("progress", computedProgress, false);
			xhr.upload.addEventListener("progress", computedProgress, false);
			return xhr;
		},
		data: formData,
		async: true,
		success: function (data) {
			$("#fecharModalFile").click();

			swal({
				title: "Sucesso!",
				text: "Arquivo anexado com sucesso.",
				icon: "success",
			});
		},
		cache: false,
		contentType: false,
		processData: false
	});
	return false;
}

function partialAnexos(valor) {

	var dados = "";

	if (valor != "") {
		dados += '{name:"id", value:"' + valor + '"},';
	}
	dadosEnvio = eval("[" + dados + "]");

	$.ajax({
		url: "/Avaliacoes/PartialAnexos",
		method: "GET",
		data: dadosEnvio,
		success: function (data) {
			$("#modaldetalheAvaliacaoAnnexo").html(data);
		},
		error: function (data) {

		}
	});
}

function downloadArquivo(caminho, detalheCodigo, nomeArquivo) {


	var dados = "";

	if (nomeArquivo == "") {
		swal({
			title: "Erro ao cadastrar!",
			text: "Erro desconhecido!",
			icon: "error",
		});
	}

	if (nomeArquivo != "") {
		dados += '{name:"filename", value:"' + nomeArquivo + '"},';
	}

	if (detalheCodigo != "") {
		dados += '{name:"codigo", value:"' + detalheCodigo + '"},';
	}
	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Avaliacoes/Download",
		method: "GET",
		data: dadosEnvio,
		success: function (data) {


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