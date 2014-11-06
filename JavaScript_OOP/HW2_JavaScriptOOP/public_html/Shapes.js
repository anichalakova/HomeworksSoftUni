'use strict';

// Fix for old browsers that do not have Object.create:
Object.prototype.extends = function (parent) {
  if (!Object.create) {
    Object.prototype.create = function (proto) {
      function F() {};
      F.prototype = proto;
      return new F();
    };
  };
  
  this.prototype = Object.create(parent.prototype);
  this.prototype.constructor = this;
};


var Shape = (function(){
    function Shape(x, y, color){
    
    // Allow creating instances of functions without "new" keyword
    // (doesn't work in "strict mode" :
    //      if (!(this instanceof arguments.callee)) {
    //    return new arguments.callee(x, y, color);
    //  }

        this._x = x;
        this._y = y;
        this._color = color;

        Shape.prototype.toString = function(){
            return 'X = ' + this._x + ', Y = ' + this._y + ', Color = ' + this._color;        
        };
    }

    Shape.prototype.draw = function(){
        var _ctx = document.getElementById('shapesCanvas').getContext('2d'); 
        _ctx.beginPath();
        _ctx.fillStyle = this._color;
        _ctx.lineWidth = 2;
        _ctx.strokeStyle = 'black';
        return _ctx;
    };
        return Shape;
})();

var Circle = (function(){    
    function Circle (x, y, color, radius){
        Shape.apply(this, arguments);
    //    Don't forget mentioning the arguments!  or
    //    Shape.call(this, x, y, color);
        this._radius = radius;
    };

    Circle.extends(Shape);
    //or
    //Circle.prototype = Object.create(Shape.prototype);
    //Circle.prototype.constructor = Shape;

    //    All extension methods should be declared after the "Child.extends(Parent)" statement:
    Circle.prototype.toString = function(){
        return Shape.prototype.toString.call(this) + ", R = " + this._radius;            
    };

     Circle.prototype.draw = function () {      
        var _ctx =  Shape.prototype.draw.call(this);     
        _ctx.arc(this._x, this._y, this._radius, 0, 2 * Math.PI, false);    
        _ctx.fill();
        _ctx.stroke(); 
        _ctx.closePath();
    };

    return Circle;
})();

var Rectangle = (function(){    
    function Rectangle(x, y, color, width, height){
        Shape.apply(this, arguments);

        this._width = width;
        this._height = height;
    }

    Rectangle.extends(Shape);

    Rectangle.prototype.toString = function(){
        return Shape.prototype.toString.call(this) + ', Width = ' + this._width 
                + ', Height = ' + this._height;
    };

     Rectangle.prototype.draw = function () {      
        var _ctx =  Shape.prototype.draw.call(this);     
        _ctx.rect(this._x, this._y, this._width, this._height);      
        _ctx.fill();     
        _ctx.stroke();
        _ctx.closePath();
    };

    return Rectangle;
})();

var Point = (function(){
    function Point(x, y){
        Shape.call(this, x, y);
        var BLACK = '#000000';
        this._color = BLACK;
    }

    Point.extends(Shape);

    Point.prototype.toString = function(){
        return Shape.prototype.toString.call(this);
    };

     Point.prototype.draw = function () {      
        var _ctx =  Shape.prototype.draw.call(this);     
        _ctx.rect(this._x, this._y, 2, 2);            
        _ctx.stroke();
        _ctx.closePath();
    };
    return Point;
})();

var Triangle = (function(){    
    function Triangle(x, y, x2, y2, x3, y3, color){
        Shape.call(this, x, y, color);

        this._x2 = x2;
        this._y2 = y2;
        this._x3 = x3;
        this._y3 = y3;  
    }

    Triangle.extends(Shape);

    Triangle.prototype.toString = function(){
        return Shape.prototype.toString.call(this) 
                        + ', Second point: x2 = ' + this._x2 + ', y2 = ' + this._y2 
                        + ', Third point: x3 = ' + this._x3 + ', y3 = ' + this._y3;
    };

    Triangle.prototype.draw = function () {      
        var _ctx =  Shape.prototype.draw.call(this);      
        _ctx.moveTo(this._x,this._y);
        _ctx.lineTo(this._x2,this._y2);      
        _ctx.lineTo(this._x3,this._y3);  
        _ctx.lineTo(this._x,this._y);  
        _ctx.fill();      
        _ctx.stroke(); 
        _ctx.closePath();
    };
    
    return Triangle;
})();

var Segment = (function(){
    function Segment(x, y, x2, y2, color){
        Shape.call(this, x, y, color);

        this._x2 = x2;
        this._y2 = y2;
    }

    Segment.extends(Shape);

    Segment.prototype.toString = function(){
        return Shape.prototype.toString.call(this) 
                    + ', Second point: x2 = ' + this._x2 + ', y2 = ' + this._y2;
    };

    Segment.prototype.draw = function () {      
        var _ctx =  Shape.prototype.draw.call(this);     
        _ctx.moveTo(this._x,this._y);
        _ctx.lineTo(this._x2,this._y2); 
        _ctx.fill();
        _ctx.strokeStyle = this._color;
        _ctx.stroke();
        _ctx.closePath();
    };
    
    return Segment;
})();







