/// <reference path="../lib/angularjs/angular.js"/>
/// <reference path="../lib/angularjs/angular-ui-router.js"/>
/// <reference path="../lib/lodash/lodash.js"/>
/// <reference path="../services/dataservice.js"/>

(function () {
	'use strict'

	/**
	 * Контроллер таблицы обращений клиента.
	 **/
	angular
		.module('app')
		.controller('tableIncidentsCtrl', tableIncidentsCtrl);

	tableIncidentsCtrl.$inject = ['$scope', 'dataservice', '$stateParams', '$state']

	function tableIncidentsCtrl($scope, dataservice, $stateParams, $state) {
		$scope.incidents = [];

		$scope.init = function () {
			var clientId = $stateParams.id;
			dataservice.loadIncidents(clientId, (data) => {
				$scope.incidents = data;
				var seconds;
				_.each($scope.incidents, (i) => {
					seconds = i.Date.match(/\d+/);
					i.Date = seconds.length > 0 ? new Date(parseInt(seconds[0])) : new Date();
				});
			});
		};

		$scope.deleteIncident = function (id) {
			dataservice.deleteIncident(id, () => {
				_.remove($scope.incidents, (item) => {
					return item.Incident === id;
				});
				$scope.init()
			});
		};

		$scope.moveToAddIncidentForm = function () {
			$state.go('newIncident');
		};

		$scope.moveToUpdateIncidentForm = function (id) {
			$state.go('updateIncident', { id: id });
		};
	};

	/*
	 * Директива таблицы обращений.
	 **/
	angular
		.module('app')
		.directive('incidentsTableDirective', incidentsTableDirective);

	function incidentsTableDirective() {
		return {
			controller: 'tableIncidentsCtrl',
			templateUrl: 'Content/html/incidents/incidents-table.html'
		};
	};
})();
