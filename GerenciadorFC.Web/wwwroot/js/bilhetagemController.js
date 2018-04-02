var app = angular.module("app", []);

app.controller('bilhetagemController', ['$scope', '$http', bilhetagemController]);

function bilhetagemController($scope, $http) {

	$http.get('https://gerenciadorfcbilhetagemhistoricodeprocesso.azurewebsites.net').success(function (data) {
		$scope.ListaBilhetagem = data;
	}).error(function () {
		$scope.msgErro = "Errrrrrro!";
		});

}