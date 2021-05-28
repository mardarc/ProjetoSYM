MyApp.controller('MedicosController', function ($scope, $state, $http, $localStorage, $location) {

	$scope.iniciar = function() {
		$location.path('/painel/medicos');
	}

});