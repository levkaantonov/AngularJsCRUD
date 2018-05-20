/// <reference path="lib/angularjs/angular.js"/>
/// <reference path="lib/angularjs/angular-ui-router.js"/>

(function () {
	'use strict'

	angular
		.module('app')
		.config(($stateProvider, $urlRouterProvider, $locationProvider) => {
			$urlRouterProvider.otherwise('/home');
			$locationProvider.hashPrefix('');
			$locationProvider.html5Mode(true);

			$stateProvider
				.state('home', {
					url: '/home',
					templateUrl: 'Content/html/clients/clients-table.html',
					controller: 'tableClientsCtrl',
					controllerAs: 'tableClientsCtrl'
				})
				.state('newСlient', {
					url: '/new/client',
					templateUrl: 'Content/html/clients/client-new.html'
				})
				.state('updateСlient', {
					url: '/update/client/:id',
					templateUrl: 'Content/html/clients/client-update.html'
				})
				.state('newIncident', {
					url: '/new/incident',
					templateUrl: 'Content/html/incidents/incident-new.html'
				})
				.state('updateIncident', {
					url: '/update/incident/:id',
					templateUrl: 'Content/html/incidents/incident-update.html'
				});
	});
})();