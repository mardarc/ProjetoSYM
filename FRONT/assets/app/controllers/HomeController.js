MyApp.controller('HomeController', function ($scope, $state, $http, $localStorage, $location) {

	$scope.iniciar = function() {
		console.log('Marlon');
	}

	// $scope.homw = function () {
	// 	$http({
	// 		url: LinkAPI+'/dados/pegarcursos',
	// 		method: "GET"
	// 	})
	// 	.then(function(response) {
	// 		if(response.status == 200) {
	// 			$scope.OptionsCurso = response.data;
	// 		}else{
	// 			toastr.info(response.data, "Info: "+response.status);
	// 		}
	// 	}, 
	// 	function(response) {
	// 		if(response.status == 403){
	// 			toastr.error("Usuário sem permissão", "Error: "+response.status);
	// 		}else if(response.status == 401){
	// 			toastr.info("Sessão expirada", "Info");
	// 			$location.path('/login');
	// 		}else{
	// 			toastr.error(response.data, "Error: "+response.status);
	// 		}
	// 	});
	// }

});