(function () {
    'use strict';

    angular.module('app').controller('productPricingController', productPricingController);

    productPricingController.$inject = ['productPricingService', '$log'];

    function productPricingController(productPricingService, $log) {

        var vm = this;
        vm.suppliers = getSuppliers;
        vm.selectedSupplier = '';
        vm.products = getProducts;
        vm.productDetails = getProductDetails;
       
        function getSuppliers() {

            productPricingService.getSuppliers().then(function(response) {
                vm.supplierNames = response;
                vm.selectedSupplier = response[0];
            }, function (error){$log.log('Error occured ' + error)});
        }

       function getProducts() {

           productPricingService.getSupplierProducts(vm.selectedSupplier).then(function(response) {
               vm.supplierProducts = response;
               vm.selectedProduct = "";
           }, function (error){$log.log('Error occured ' + error)});
       }

       function getProductDetails() {
           productPricingService.getProductDetails(vm.selectedSupplier, vm.selectedProduct)
                                .then(function (response) {
                                    vm.detailsOfProducts = response;
                                    $log.log('Product details successfully retrieved ' + vm.detailsOfProducts);
               } ,function (error){$log.log('Error occured when getting product details for ' + vm.selectedProduct)} );
       }
    }
})();