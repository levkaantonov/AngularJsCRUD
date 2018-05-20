/// <reference path="lib/angularjs/angular.js"/>
/// <reference path="lib/angularjs/angular-ui-router.js"/>
var myDate;
(function () {
	'use strict'

	angular
		.module('app', ['ui.router', 'ngAnimate'])
		.run(['$rootScope', function ($rootScope) {
			$rootScope.$on('$stateChangeSuccess', function (event, to, toParams, from, fromParams) {
				$rootScope.$previousState = from;
				$rootScope.$previousParams = fromParams;
			});
		}]);;
})();