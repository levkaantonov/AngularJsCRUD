/// <reference path="../lib/angularjs/angular.js"/>
/// <reference path="../lib/angularjs/angular-ui-router.js"/>

(function () {
	'use strict'

	/**
	 * Сервис работы с базейкой.
	 */
	angular
		.module('app')
		.factory('dataservice', dataservice);

	dataservice.$inject = ['$http'];

	function dataservice($http) {

		return {
			loadClients: loadClients,
			getClient: getClient,
			deleteClient: deleteClient,
			createClient: addClient,
			updateClient: updateClient,
			loadIncidents: loadIncidents,
			getIncident: getIncident,
			deleteIncident: deleteIncident,
			createIncident: addIncident,
			updateIncident: updateIncident
		};

		function loadClients(callback) {
			$http({ method: 'GET', url: '/clients/load' })
				.then((response) => {
					callback(response.data);
				}, (response) => { console.error(response.data); });
		};

		function getClient(id, callback) {
			$http({ method: 'POST', url: '/clients/get/'.concat(id) })
				.then((response) => {
					callback(response.data);
				}, (response) => { console.error(response.data); });
		};

		function deleteClient (id, callback) {
			$http({ method: 'POST', url: '/clients/delete/'.concat(id) })
				.then(callback, (response) => { console.error(response.data); });
		};

		function addClient(client, callback) {
			$http({ method: 'POST', url: '/clients/create/', data: client })
				.then(callback, (response) => { console.error(response.data); });
		};

		function updateClient(client, callback) {
			$http({ method: 'POST', url: '/clients/update/', data: client })
				.then(callback, (response) => { console.error(response.data); });
		};

		function loadIncidents(clientId, callback) {
			var url = '/incidents/load/'.concat(clientId);
			$http({ method: 'GET', url: url })
				.then((response) => {
					callback(response.data);
				}, (response) => { console.error(response.data); });
		};

		function getIncident(id, callback) {
			$http({ method: 'GET', url: 'incidents/get/'.concat(id) })
				.then((response) => {
					callback(response.data);
				}, (response) => { console.error(response.data); });
		};

		function deleteIncident(id, callback) {
			$http({ method: 'POST', url: '/incidents/delete/'.concat(id) })
				.then(callback, (response) => { console.error(response.data); });
		};

		function addIncident(client, callback) {
			$http({ method: 'POST', url: '/incidents/create/', data: client })
				.then(callback, (response) => { console.error(response.data); });
		};

		function updateIncident(client, callback) {
			$http({ method: 'POST', url: '/incidents/update/', data: client })
				.then(callback, (response) => { console.error(response.data); });
		};

	};
		
})();