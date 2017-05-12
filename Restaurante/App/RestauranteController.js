
//Registrar o controller e criar função para obter os dados do Controlador MVC - RestauranteController.cs
app.controller('RestauranteController', ['$scope', '$rootScope', '$http', 'ngTableParams', function ($scope, $rootScope, $http, ngTableParams) {

    $scope.restaurantes = [];
    $scope.restaurante = {};

    $scope.pesquisar = function () {

        $http.post('/Restaurantes/Search/', { pesquisaRestaurante: $scope.restaurante }).then(
            function (response) {
                $scope.restaurantes = response.data;

            }, function (error) {
                $scope.restaurantes = [];
                alert('Erro ao consultar os dados de restaurantes');
            });
    }

    //IncluirRestaurante do controlador
    $scope.AddRestaurante = function () {
        $http.post('/Restaurantes/Create/', { restaurante: $scope.restaurante }).then(
        function (response) {
            $scope.restaurantes = response.data;
            delete $scope.restaurante;
            $scope.voltar();
        }, function (error) {
            alert('Erro ao inserir os dados do restaurante');
        });
    }

    //IncluirRestaurante do controlador
    $scope.EditarRestaurante = function (item) {
        window.location = '/Restaurantes/Edit/' + item.ID;
    }

    //IncluirRestaurante do controlador
    $scope.SalvarRestaurante = function () {
        $http.post('/Restaurantes/Edit/', { restaurante: $scope.restaurante }).then(
        function (response) {
            $scope.restaurantes = response.data;
            delete $scope.restaurante;
            $scope.voltar();
        }, function (error) {
            alert('Erro ao inserir os dados do restaurante');
        });
    }

    $scope.voltar = function () {
        window.location = '/Restaurantes/';
    }

    //ExcluirRestaurante do controlador
    $scope.DeletaRestaurante = function (item) {
        $http.post('/Restaurantes/DeleteConfirmed/', { ID: item.ID }).then(
        function (response) {
            $scope.restaurantes = response.data;
            delete $scope.restaurante;
            $scope.pesquisar();
        }, function (error) {
            alert('Erro ao excluir os dados do restaurante.');
        });
    }

    $scope.index = function () {
        $scope.pesquisar();
    };

    $scope.init = function (restaurante) {
        $scope.restaurante = restaurante
    }

}]);