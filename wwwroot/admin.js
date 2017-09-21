let admin = new Vue({
	el: '#app',

	data: {
		forms: []
	},

	mounted() {
		const xhr = new XMLHttpRequest();
		xhr.open('GET', 'http://192.168.0.151:5656/api/forms');

		xhr.onload = () => {
			const json = JSON.parse(xhr.responseText);
			this.forms = json;
		};

		xhr.send();
	}
});
