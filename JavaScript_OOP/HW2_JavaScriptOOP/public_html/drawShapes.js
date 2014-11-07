'use strict';

function drawNextShape(){ 
    var x = document.getElementById('x').value;
    var y = document.getElementById('y').value;
    var color = document.getElementById('color').value;
    
    var selectedShape = document.getElementById('shape').value;    
    
    switch (selectedShape){
        case 'circle' : {
            drawCircle(x, y, color);
            break;
        }
        case 'rectangle': {
            drawRectangle(x, y, color);
            break;
        }
        case 'triangle': {
            drawTriangle(x, y, color);
            break;
        }
        case 'segment':{
            drawSegment(x, y, color);
            break;
        }
        case 'point': {
                drawPoint(x, y, color);
                break;
        }
        default : break;                               
    }       
};

function insertNewPropertiesFields(selectedShape){
   // If tehre is a div with  additional fields for a previous form, remove it:
    var existingProperties = document.getElementById('extension');
    if (existingProperties) {
        existingProperties.parentNode.removeChild(existingProperties);
    }
    
    // Create a new div with new fields:
    var selectedShape = document.getElementById('shape').value;
    var newdiv = document.createElement('div');
    newdiv.id = 'extension';
    
    switch (selectedShape){
        case 'circle' : {
            newdiv.innerHTML = "Radius: " 
                    + "<input type='text' name='radius' id='radius'>"; 
            break;
        }
        case 'rectangle': {
            newdiv.innerHTML = "Width: " + "<input type='text' name='width' id='width'>"
                             + "Height: " + "<input type='text' name='height' id='height'>";
            break;
        }
        case 'triangle': {
            newdiv.innerHTML = "X2: " + "<input type='text' name='x2' id='x2'>"
                            + "Y2: " + "<input type='text' name='y2' id='y2'>"
                            + "X3: " + "<input type='text' name='x3' id='x3'>"
                            + "Y3: " + "<input type='text' name='y3' id='y3'>";
            break;
        }
        case 'segment':{
            newdiv.innerHTML = "X2: " + "<input type='text' name='x2' id='x2'>"
                            + "Y2: " + "<input type='text' name='y2' id='y2'>";
            break;
        }
        case 'point': break;
        default : break;                               
    }  
    document.getElementById('moreFields').appendChild(newdiv);
}           
   
function drawPoint(x, y, color){
    var point = new Point(x, y ,color);
    point.draw();
    addText(point);
}

function drawCircle(x, y, color){
    var radius = document.getElementById('radius').value;
    var circle = new Circle(x, y ,radius, color);
    circle.draw();
    addText(circle);
}

function drawRectangle (x, y, color){
    var width = document.getElementById('width').value;
    var height = document.getElementById('height').value;
    var rectangle = new Rectangle(x, y , width, height, color);
    rectangle.draw();
    addText(rectangle);
}

function drawTriangle (x, y, color){
    var x2 = document.getElementById('x2').value;
    var y2 = document.getElementById('y2').value;
    var x3 = document.getElementById('x3').value;
    var y3 = document.getElementById('y3').value;
    var triangle = new Triangle(x, y , x2, y2, x3, y3, color);
    triangle.draw();
    addText(triangle);
}

function drawSegment (x, y, color){
    var x2 = document.getElementById('x2').value;
    var y2 = document.getElementById('y2').value;
    var segment = new Segment(x, y , x2, y2, color);
    segment.draw();
    addText(segment);
}

function addText(shape){    
	var textarea = document.getElementById('info');
        textarea.value += shape.toString() + '\r\n';
}