(function(){
    tiger.controller("TigerController", function($scope, $http){
        var tigerObject = { 'Name':'Pesho', 'Born':'Asia', 'BirthDate':2006, 'Live':'Sofia Zoo'};
        $scope.tiger = tigerObject;
        
        $scope.imgURL = "http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg";
        
        $scope.container = 'container';
        $scope.tigerProperties = 'tigerList';
        $scope.small = 'small';
    });     
})();

