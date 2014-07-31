function changeText(){ 
	var theButton = document.getElementById('theButton');
	var buttonText = theButton.innerHTML;
	if (buttonText == 'Like') {
		buttonText = 'Unlike';
	} else { 
		buttonText = 'Like';
	}

	theButton.innerHTML = buttonText;
}

var theButton = document.getElementById('theButton');
theButton.addEventListener('click', changeText, false);