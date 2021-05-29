MyApp.controller('PainelController', function ($scope, $state, $http, $localStorage, $location,) {
	
	$scope.iniciar = function () {
	}
	
	$scope.AlterarMenu = function() {
		$("body").toggleClass("sidebar-toggled");
		$(".sidebar").toggleClass("toggled");
		if ($(".sidebar").hasClass("toggled")) {
			$('.sidebar .collapse').collapse('hide');
		};
	}
});