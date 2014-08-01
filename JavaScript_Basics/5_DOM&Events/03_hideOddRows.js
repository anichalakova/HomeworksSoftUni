﻿var hideButton = document.getElementById('btnHideOddRows');

hideButton.onclick = function hideOddRows()
{
	var rows = document.getElementsByTagName('tr');
	var firstVisible;
	
	for (var j = 0; j < rows.length; j++) {
		if (rows[j].style.display !== 'none') {
			firstVisible = j;
			break;
		}
	}
	
	var step = (firstVisible + 1)*2;	
	for (var i = firstVisible; i < rows.length; i+= step) {		
		rows[i].style.display = 'none';		
	}	
}

