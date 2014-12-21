displayStudent.controller('DisplayStudentController', function($scope,$http) {

    var student = {"name": "Pesho","photo": "http://sr.photos3.fotosearch.com/bthumb/CSP/CSP413/k4134689.jpg", "grade": 5,"school": "High School of Mathematics", "teacher": "Gichka Pesheva"};
    $scope.student = student;
});
