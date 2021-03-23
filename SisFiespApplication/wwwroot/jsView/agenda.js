function salvarAgendamento() {

	var dados = "";

	if ($('#alunoCodigo').val() != "") {
		dados += '{name:"alunoCodigo", value:"' + $('#alunoCodigo').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "O Aluno está vazio!",
			icon: "error",
		});
		return;
	}
	if ($('#dtAgendamento').val() != "") {
		dados += '{name:"DtAgendamento", value:"' + $('#dtAgendamento').val() + '"},';
	} else {
		swal({
			title: "Erro ao cadastrar!",
			text: "Data de Nascimento está vazia!",
			icon: "error",
		});
		return;
	}

	dadosEnvio = eval("[" + dados + "]");


	$.ajax({
		url: "/Agenda/Create",
		method: "POST",
		data: dadosEnvio,
		success: function (data) {
			swal({
				title: "Sucesso!",
				text: "Agendamento cadastrado com Sucesso",
				icon: "success",
			});

			window.setTimeout(function () {
				document.location.reload(true);
			}, 2000);

			//$("#pagina").html(data).find('.page-wrapper')
			//var doc = new DOMParser().parseFromString(data, "text/html");
			//var subtabelas = doc.getElementsByClassName("main-body");
			//var div = document.getElementById("pagina");
			//div.innerHTML = subtabelas[0].innerHTML

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

"use strict";
$(document).ready(function () {
	$('#external-events .fc-event').each(function () {

		// store data so the calendar knows to render an event upon drop
		$(this).data('event', {
			title: $.trim($(this).text()), // use the element's text as the event title
			stick: true // maintain when user navigates (see docs on the renderEvent method)
		});

		// make the event draggable using jQuery UI
		$(this).draggable({
			zIndex: 999,
			revert: true, // will cause the event to go back to its
			revertDuration: 0 //  original position after the drag
		});

	});


	$(document).ready(function () {
		var something = "";
		$.ajax({
			type: "POST",
			url: "Agenda/Dados",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (doc) {
				var events = [];
				var docd = doc;
				something = docd;
				//var initialLocaleCode = 'pt-br';

				var obj = doc;

				for (var k in obj) {// k represents the id keys 1,2,3
					var d = obj[k]; // We assign a the reference to each id object to the d variable
					for (var p in d) { //Next we access the nested objects by using the p variable
						if (p.hasOwnProperty) { //Check to make sure p has its own properties
							//alert(p + ":" + d[p]); //We alert the key (d) and the keys value (d[p])
							events.push(p + ": " + d[p]);
						}

					}
				}

				$('#calendar').fullCalendar({
					
					header: {
						left: 'prev,next today',
						center: 'title',
						right: 'month,agendaWeek,agendaDay,listMonth'
					},
					locale:'pt-br',
					defaultDate: Date.now(),
					//weekNumbers: true,
					navLinks: true, // can click day/week names to navigate views
					businessHours: false, // display business hours
					editable: true,
					droppable: true, // this allows things to be dropped onto the calendar
					drop: function () {

						// is the "remove after drop" checkbox checked?
						if ($('#checkbox2').is(':checked')) {
							// if so, remove the element from the "Draggable Events" list
							$(this).remove();
						}
					},
					eventClick: function () {
						alert('Deletar Agendamento!');
					},
					events: obj

				})

				//var initialLocaleCode = 'pt-br';
				//var localeSelectorEl = document.getElementById('locale-selector');
				//var calendarEl = document.getElementById('calendar');

				//var calendar = new FullCalendar.Calendar(calendarEl, {
				//	headerToolbar: {
				//		left: 'prev,next today',
				//		center: 'title',
				//		right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
				//	},
				//	locale: initialLocaleCode,
				//	buttonIcons: false, // show the prev/next text
				//	weekNumbers: true,
				//	navLinks: true, // can click day/week names to navigate views
				//	editable: true,
				//	dayMaxEvents: true, // allow "more" link when too many events
				//	events: obj
				//});

				//calendar.render();



				//console.log(events);

			},
			error: function (xhr, status, error) {
				alert(xhr.responseText);
			}
		});


	});



	//$('#calendar').fullCalendar({
	//	header: {
	//		left: 'prev,next today',
	//		center: 'title',
	//		right: 'month,agendaWeek,agendaDay,listMonth'
	//	},
	//	defaultDate: '2021-03-15',
	//	navLinks: true, // can click day/week names to navigate views
	//	businessHours: true, // display business hours
	//	editable: true,
	//	droppable: true, // this allows things to be dropped onto the calendar
	//	drop: function () {

	//		// is the "remove after drop" checkbox checked?
	//		if ($('#checkbox2').is(':checked')) {
	//			// if so, remove the element from the "Draggable Events" list
	//			$(this).remove();
	//		}
	//	},
	//	events: //[



	//	//	{
	//	//	title: 'Business Lunch',
	//	//	start: '2021-03-14T13:00:00',
	//	//	constraint: 'businessHours',
	//	//	borderColor: '#FC6180',
	//	//	backgroundColor: '#FC6180',
	//	//	textColor: '#fff'
	//	//}, {
	//	//	title: 'Meeting',
	//	//	start: '2021-02-14T11:00:00',
	//	//	constraint: 'availableForMeeting',
	//	//	editable: true,
	//	//	borderColor: '#4680ff',
	//	//	backgroundColor: '#4680ff',
	//	//	textColor: '#fff'
	//	//}, {
	//	//	title: 'Conference',
	//	//	start: '2021-03-15',
	//	//	end: '2021-03-15',
	//	//	borderColor: '#93BE52',
	//	//	backgroundColor: '#93BE52',
	//	//	textColor: '#fff'
	//	//}, {
	//	//	title: 'Party',
	//	//	start: '2021-03-29T20:00:00',
	//	//	borderColor: '#FFB64D',
	//	//	backgroundColor: '#FFB64D',
	//	//	textColor: '#fff'
	//	//},

	//	//// areas where "Meeting" must be dropped
	//	//{
	//	//	id: 'availableForMeeting',
	//	//	start: '2021-03-16T10:00:00',
	//	//	end: '2021-03-16T16:00:00',
	//	//	rendering: 'background',
	//	//	borderColor: '#ab7967',
	//	//	backgroundColor: '#ab7967',
	//	//	textColor: '#fff'
	//	//}, {
	//	//	id: 'availableForMeeting',
	//	//	start: '2021-03-17T10:00:00',
	//	//	end: '2021-03-17T16:00:00',
	//	//	rendering: 'background',
	//	//	borderColor: '#39ADB5',
	//	//	backgroundColor: '#39ADB5',
	//	//	textColor: '#fff'
	//	//},

	//	//// red areas where no events can be dropped
	//	//{
	//	//	start: '2021-03-24',
	//	//	end: '2021-03-28',
	//	//	overlap: false,
	//	//	rendering: 'background',
	//	//	borderColor: '#FFB64D',
	//	//	backgroundColor: '#FFB64D',
	//	//	color: '#d8d6d6'
	//	//}, {
	//	//	start: '2021-03-06',
	//	//	end: '2021-03-08',
	//	//	overlap: false,
	//	//	rendering: 'background',
	//	//	borderColor: '#ab7967',
	//	//	backgroundColor: '#ab7967',
	//	//	color: '#d8d6d6'
	//	//}
	//	//]
	//});
});


