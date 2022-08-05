var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "Save";
    // Add record
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/Add_record',
            data: $scope.register
        }).success(function (d) {
            $scope.btntext = "Save";
            $scope.register = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };
	
	 $scope.btntext = "SaveTurnos";
    // Add record turno
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Turnos/Add_recordTurnos',
            data: $scope.turnos
        }).success(function (d) {
            $scope.btntext = "SaveTurnos";
            $scope.turnos = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };
	
    // Display all record
    $http.get("/Home/Get_data").then(function (d) {
        $scope.record = d.data;
    }, function (error) {
        alert('Failed');
    });
	
	// Display all record turnos
    $http.get("/Turnos/Get_dataTurnos").then(function (d) {
        $scope.Turnos = d.data;
    }, function (error) {
        alert('Failed');
    }); 

    // Display record by id
    $scope.loadrecord = function (id) {
        $http.get("/Home/Get_databyid?id="+id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };
	
	// Display record turno by id
    $scope.loadrecordTurno = function (id) {
        $http.get("/Turnos/Get_dataTurnobyid?id="+id).then(function (d) {
            $scope.turnos = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };
    // Delete record 
    $scope.deleterecord = function (id) {
        $http.get("/Home/delete_record?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Home/Get_data").then(function (d) {
                $scope.record = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
	
	// Delete record turnos
    $scope.deleterecordTurnos = function (id) {
        $http.get("/Home/delete_recordTurnos?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Turnos/Get_data").then(function (d) {
                $scope.Turnos = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
	
	
    // Update record
    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/update_record',
            data: $scope.register
        }).success(function (d) {
            $scope.btntext = "Update";
            $scope.register = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };
	
	// Update record turnos
    $scope.updatedataTurnos = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Turnos/update_recordTurno',
            data: $scope.Turnos
        }).success(function (d) {
            $scope.btntext = "UpdateTurno";
            $scope.Turnos = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };
});