MyApp.controller('ConsultoriosController', function ($scope, $state, $http, $localStorage, $location) {

    $scope.Consultorios = [];
    let text = "";

    $scope.iniciar() = function(){

        $http({
            url:LinkAPI+'/consultorios/getConsultorios',
            method: "GET",
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

});