
//Registrar o controller e criar função para obter os dados do Controlador MVC - PratoController.cs
app.controller('PratoController', ['$scope', '$rootScope', '$http', 'ngTableParams', function ($scope, $rootScope, $http, ngTableParams) {

    $scope.pratos = [];
    $scope.prato = {};

    $scope.pesquisar = function () {
        $http.post('/Pratos/Search/', { pesquisaPrato: $scope.prato }).then(
            function (response) {
                $scope.pratos = response.data;

            }, function (error) {
                $scope.pratos = [];
                alert('Erro ao consultar os dados de pratos');
            });
    }

    //IncluirPrato do controlador
    $scope.EditarPrato = function (item) {
        window.location = '/Pratos/Edit/' + item.ID;

    }

    //IncluirPrato do controlador
    $scope.SalvarPrato = function () {
        $http.post('/Pratos/Edit/', { prato: $scope.prato }).then(
        function (response) {
            $scope.pratos = response.data;
            delete $scope.prato;
            $scope.voltar();
        }, function (error) {
            alert('Erro ao inserir os dados do prato');
        });
    }

    //IncluirPrato do controlador
    $scope.AddPrato = function () {
        $http.post('/Pratos/Create/', { prato: $scope.prato }).then(
        function (response) {
            $scope.pratos = response.data;
            delete $scope.prato;
            $scope.voltar();
        }, function (error) {
            alert('Erro ao inserir os dados do prato');
        });
    }

    $scope.voltar = function () {
        window.location = '/Pratos/';
    }

    //ExcluirPrato do controlador
    $scope.DeletaPrato = function (item) {
        $http.post('/Pratos/DeleteConfirmed/', { id: item.ID }).then(
        function (response) {
            $scope.pratos = response.data;
            delete $scope.prato;
            $scope.pesquisar();
        }, function (error) {
            alert('Erro ao excluir os dados do prato');
        });
    }

    $scope.index = function () {
        $scope.pesquisar();
    };

    $scope.init = function (prato) {
        $scope.prato = prato;
    }

    }]);