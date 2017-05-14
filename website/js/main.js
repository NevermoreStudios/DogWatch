setInterval(function() {
	var xhr = new XMLHttpRequest();
	xhr.addEventListener('load', function() {
		var el = document.getElementById('content');
		if(this.response !== el.outerHTML) {
			el.outerHTML = this.response;
		}
	});
	xhr.open('GET', '/content.php', true);
	xhr.send();
}, 5000);