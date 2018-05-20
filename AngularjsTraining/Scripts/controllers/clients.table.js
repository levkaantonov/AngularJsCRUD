/// <reference path="../lib/angularjs/angular.js"/>
/// <reference path="../lib/angularjs/angular-ui-router.js"/>
/// <reference path="../lib/lodash/lodash.js"/>
/// <reference path="../services/dataservice.js"/>

(function () {
	'use strict'

	/**
	 * Контроллер таблицы клиентов.
	 **/
	angular
		.module('app')
		.controller('tableClientsCtrl', tableClientsCtrl);

	tableClientsCtrl.$inject = ['$scope', 'dataservice', '$stateParams', '$state']

	function tableClientsCtrl($scope, dataservice, $stateParams, $state) {
		$scope.clients = [];

		$scope.clientTypes = [
			{ id: 0, value: 'Вкладчик' },
			{ id: 1, value: 'Заемщик' },
			{ id: 2, value: 'Возможный клиент' }
		];

		$scope.init = function () {
			dataservice.loadClients((data) => {
				$scope.clients = data;
			});
		};

		$scope.deleteClient = function (id) {
			dataservice.deleteClient(id, ()  => {
				_.remove($scope.clients, (item) => {
					return item.ClientId === id;
				});
				$scope.client = null;
				$scope.init()
			});
		};

		$scope.moveToAddClienForm = function () {
			$state.go('newСlient');
		};

		$scope.moveToUpdateClienForm = function (id) {
			$state.go('updateСlient', {id: id});
		};
	};
})();
