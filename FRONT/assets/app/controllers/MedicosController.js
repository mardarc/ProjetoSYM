MyApp.controller('MedicosController', function ($scope, $state, $http, $localStorage, $location) {

	$scope.Medicos = [];
	$scope.dados = [];
	let text = "";

	$scope.iniciar = function() {
		$http({
			url: LinkAPI+'/medico/getmedicos',
			method: "GET"
		}).then( function (response){
			if(response.status ==200){
				$scope.Medicos = response.data;
				$('#dt-medicos').show();
			}
			else {
				toastr.info(response.data, "Info "+response.status);
			}
		},
		function(response){
			if(response.status == 403){
				toastr.error("Usuário sem permissão", "Error: "+response.status);
			}else if(response.status == 401){
				toastr.info("Sessão expirada", "Info");
				$location.path('/painel/home');
			}else{
				toastr.error(response.data, "Error: "+response.status);
			}
		});
	}

	$scope.Salvar = function(){
		

		var dado = {
			CRM: $('#inputCRM').val(),
			Nome: $('#inputNome').val(),
			Telefone: $('#inputTelefone').val(),
			ValorConsulta: $('#inputValorConsulta').val(),
		}

		$http({
			url: LinkAPI+'/medico/createmedico',
			method: "POST",
			data: dado
		}).then(function(response){

			if(response.status == 200){
				text = "Médico cadastrado com sucesso.";
			}else{
				toastr.info(response.data, "Info: "+response.status);
				text = "Não foi possível cadastrar o médico\nInfo: "+response.status;
			}
			$('#modal-medicos-text').html(text);
			$('#modal-medicos').modal('show');
			$('#collapseOne').collapse('hide');
		},
		function(response) {
			if(response.status == 403){
				toastr.error("Usuário sem permissão", "Error: "+response.status);
				text = "Não foi possível cadastrar o médico\nUsuário sem permissão";
			}else{
				toastr.error(response.data, "Error: "+response.status);
				text = "Não foi possível cadastrar o médico\nError: "+response.status;
			}
		});

		
	}

	$scope.Editar = function(index){
		$('#inputCRM').val(index.crm);
		$('#inputNome').val(index.nome);
		$('#inputTelefone').val(index.telefone);
		$('#inputValorConsulta').val(index.valorConsulta);
		$('#collapseOne').collapse('show');
	}

	$scope.Deletar = function(index) {
		var crm = index.crm;
		console.log("Delete iniciado")
		$http({
			url:LinkAPI+'/medico/deletarmedico/'+crm,
			method: "DELETE"
		}).then(function (response){
			console.log('delete foi');
			if(response.status == 200) {
				text = "Médico excluído com sucesso";
			}else{
				toastr.info(response.data, "Info: "+response.status);
			}
			
			$('#modal-medicos-text').html(text);
			$('#modal-medicos').modal('show');
			$('#collapseOne').collapse('hide');
		}, 
		function(response) {
			if(response.status == 403){
				toastr.error("Usuário sem permissão", "Error: "+response.status);
			}else{
				toastr.error(response.data, "Error: "+response.status);
			}
		});

	}
});