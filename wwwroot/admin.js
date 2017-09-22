let admin = new Vue({
	el: '#app',

	data: {
		forms: []
	},

	mounted() {
		const xhr = new XMLHttpRequest();
		xhr.open('GET', '/api/forms');

		xhr.onload = () => {
			const json = JSON.parse(xhr.responseText);
			this.forms = json;
		};

		xhr.send();
	}
});
