(function () {
    angular.module('factories', []).factory('productPricingService', productPricingService);

    productPricingService.$inject = ['$http', 'productionPricingConfig'];

    function productPricingService($http, productionPricingConfig) {

        var url = productionPricingConfig.productionPricingUrl;

        var service = {
            getSuppliers: getSuppliers,
            getSupplierProducts: getSupplierProducts,
            getProductDetails: getProductDetails
        };
        return service;

        function getSuppliers() {

            return $http.get(url, {
                headers: { 'Accept': 'application/json', 'content-Type': 'application/json; charset=utf-8'}
            }).then(function (response) {

                return response.data;
            });
        }

        function getSupplierProducts(supplierName) {

            return $http({
                method: 'GET', url: url,
                params: { supplierName: supplierName }
            }).then(function (response) {

                return response.data;
            });
        }

        function getProductDetails(supplierName, productName) {

            return $http({
                method: 'GET', url: url,
                params: { supplierName: supplierName, productName: productName }
            }).then(function (response) {
                return response.data;
            }, function (response) { return response; });
        }
    }
})();
