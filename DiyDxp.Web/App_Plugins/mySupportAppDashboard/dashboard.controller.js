(function () {
	'use strict';

	function dashboardController($http, notificationsService, userService) {
		var vm = this;

		userService.getCurrentUser().then(function (user) {
			vm.name = user.name;
			vm.email = user.email;
		})

		// functions
		vm.create = function () {
			vm.state = "waiting";
			$http.post('/Umbraco/Backoffice/Api/SupportTicketBackoffice/Create',
				{
					name: vm.name,
					emailAddress: vm.email,
					message: vm.message
				})
				.then(function () {
					notificationsService.success("Support ticket created");
					vm.state = "success";
					vm.message = "";
				},
					function (error) {
						vm.state = "failed";
						notificationsService.error("Support ticket creation failed", JSON.stringify(error.data));
					});
		}
	}

	angular.module('umbraco')
		.controller('MySupportAppDashboardController', dashboardController);

})();