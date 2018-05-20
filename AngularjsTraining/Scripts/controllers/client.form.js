/// <reference path="../lib/angularjs/angular.js"/>
/// <reference path="../lib/angularjs/angular-ui-router.js"/>
/// <reference path="../services/dataservice.js"/>

(function () {
	'use strict'

	/*
	 * Контроллер для формы клиента.
	 **/
	angular
		.module('app')
		.controller('clientFormCtrl', clientFormCtrl);

	clientFormCtrl.$inject = ['$scope', '$state', '$stateParams', 'dataservice'];
	function clientFormCtrl($scope, $state, $stateParams, dataservice) {
		$scope.client = {};
		$scope.isLoad = false;

		var isUpdate = 'id' in $stateParams;

		$scope.clientTypes = [
			{ id: 0, value: 'Вкладчик' },
			{ id: 1, value: 'Заемщик' },
			{ id: 2, value: 'Возможный клиент' }
		];

		$scope.selectedClientType = {};

		$scope.moveToHome = function () {
			$state.go('home');
		};

		$scope.submit = function () {
			$scope.client.Type = $scope.selectedClientType.id;
			if (isUpdate) {
				dataservice.updateClient($scope.client, () => {
					$scope.client = null;
					$scope.moveToHome();
				});
				return;
			};

			dataservice.createClient($scope.client, () => {
				$scope.client = null;
				$scope.moveToHome();
			});
		};

		$scope.init = function () {
			if (!isUpdate) {
				$scope.selectedClientType = $scope.clientTypes[2];
				$scope.isLoad = true;
				return;
			};

			dataservice.getClient($stateParams.id, (client) => {
				$scope.client = client;
				$scope.selectedClientType = $scope.clientTypes[client.Type];
				$scope.isLoad = true;
			});
			
		};
	};

	/*
	 * Директива для формы клиента.
	 **/
	angular
		.module('app')
		.directive('clientFormDirective', clientFormDirective);

	function clientFormDirective() {
		return {
			controller: 'clientFormCtrl',
			templateUrl: 'Content/html/clients/client-form.html'
		};
	};
})();