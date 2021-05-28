var $=jQuery;
var MyApp = angular.module("MyApp", ['ngStorage', 'ui.router', 'angularCroppie', 'angularUtils.directives.dirPagination']);

//var LinkAPI = "v1/api";
var LinkAPI = "https://localhost:5001/api";

MyApp.config(['$urlRouterProvider', '$stateProvider', function($urlRouterProvider, $stateProvider) {
	$stateProvider
	.state('painel', {
		url: "/painel",
		views: {
			"main": {
				controller: 'PainelController',
				templateUrl: "view/painel.html"
			}
		}
	})
	.state('home', {
		parent: 'painel',
		url: "/home",
		views: {
			"sistema": {
				controller: 'HomeController',
				templateUrl: "view/home.html"
			}
		}
	})
}]);

MyApp.run(run);
function run($location) {
	$location.path('/painel/home');
	
}