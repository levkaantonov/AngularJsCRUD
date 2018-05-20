/// <reference path="../lib/angularjs/angular.js"/>
/// <reference path="../lib/angularjs/angular-ui-router.js"/>
/// <reference path="../services/dataservice.js"/>

(function () {
	'use strict'

	/*
	 * Контроллер для формы обращения.
	 **/
	angular
		.module('app')
		.controller('incidentFormCtrl', incidentFormCtrl);

	incidentFormCtrl.$inject = ['$scope', '$state', '$stateParams', '$rootScope', 'dataservice'];
	function incidentFormCtrl($scope, $state, $stateParams, $rootScope, dataservice) {
		$scope.incident = { Date: new Date()};
		$scope.isLoad = false;

		var isUpdate = 'id' in $stateParams;

		$scope.moveToParent = function () {
			$state.go($rootScope.$previousState.name, { id: $rootScope.$previousParams.id });
		};

		$scope.submit = function () {
			if (isUpdate) {
				dataservice.updateIncident($scope.incident, () => {
					$scope.moveToParent();
				});
				return;
			};

			$scope.incident.ClientId = $rootScope.$previousParams.id;
			dataservice.createIncident($scope.incident, () => {
				$scope.moveToParent();
			});
		};

		$scope.init = function () {
			if (!isUpdate) {
				return;
			};

			dataservice.getIncident($stateParams.id, (incident) => {
				var seconds = incident.Date.match(/\d+/);
				incident.Date = seconds.length > 0 ? new Date(parseInt(seconds[0])) : new Date();
				$scope.incident = incident;
				console.log($scope.incident);
				$scope.isLoad = true;
			});

		};
	};

	/*
	 * Директива для формы обращения.
	 **/
	angular
		.module('app')
		.directive('incidentFormDirective', incidentFormDirective);

	function incidentFormDirective() {
		return {
			controller: 'incidentFormCtrl',
			templateUrl: 'Content/html/incidents/incident-form.html'
		};
	};
})();