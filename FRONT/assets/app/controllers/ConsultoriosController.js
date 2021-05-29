MyApp.controller('ConsultoriosController', function ($scope, $state, $http, $localStorage, $location) {

    $scope.Consultorios = [];
	let text = "";

	$scope.iniciar = function() {
		$http({
            url: LinkAPI+'/consultorios/getconsultorios',
            method: "GET"
        }).then(function(response){
            if(response.status ==200){
				$scope.Consultorios = response.data;
				$('#dt-consultorios').show();
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

    $scope.Salvar = function() {
        var dado = {
            Id: $('#inputId').val(),
			Nome: $('#inputNome').val(),
			Telefone: $('#inputTelefone').val(),
			Endereco: $('#inputEndereco').val(),
		}

		$http({
			url: LinkAPI+'/consultorios/saveConsultorio',
			method: "POST",
			data: dado
		}).then(function(response){

			if(response.status == 200){
				text = "Consultório cadastrado com sucesso.";
			}else{
				toastr.info(response.data, "Info: "+response.status);
				text = "Não foi possível cadastrar o consultório\nInfo: "+response.status;
			}
			$('#modal-consultorios-text').html(text);
			$('#modal-consultorios').modal('show');
			$('#collapseOne').collapse('hide');

            $('#inputId').val();
            $('#inputNome').val();
            $('#inputTelefone').val();
            $('#inputEndereco').val();
		},
		function(response) {
			if(response.status == 403){
				toastr.error("Usuário sem permissão", "Error: "+response.status);
				text = "Não foi possível cadastrar o consultório\nUsuário sem permissão";
			}else{
				toastr.error(response.data, "Error: "+response.status);
				text = "Não foi possível cadastrar o consultório\nError: "+response.status;
			}
		});

    }

    $scope.Editar = function(index){
		$('#inputId').val(index.id);
		$('#inputNome').val(index.nome);
		$('#inputTelefone').val(index.telefone);
		$('#inputEndereco').val(index.endereco);
		$('#collapseOne').collapse('show');
	}

    $scope.Deletar = function(index) {
		var id = index.id;
		$http({
			url:LinkAPI+'/consultorios/deletarconsultorio/'+id,
			method: "DELETE"
		}).then(function (response){
			if(response.status == 200) {
				text = "Consultório excluído com sucesso";
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