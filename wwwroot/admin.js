let admin = new Vue({
	el: '#app',

	data: {
		forms: [],
		filteredForms: [],
		filters: {
			gender: 'all',
			usesSocialMedia: null
		}
	},

	mounted() {
		const xhr = new XMLHttpRequest();
		xhr.open('GET', '/api/forms');

		xhr.onload = () => {
			const json = JSON.parse(xhr.responseText);
			this.forms = json;
			this.filteredForms = this.forms;
		};

		xhr.send();
	},

	methods: {
		filterChange() {
			switch (this.filters.gender) {
				case 'all':
					this.filteredForms = this.forms;
					break;
				case 'male':
					this.filteredForms = this.forms.filter(f => f.gender == 'Man');
					break;
				case 'female':
					this.filteredForms = this.forms.filter(f => f.gender == 'Vrouw');
					break;
			}

			if (this.filters.usesSocialMedia != null) {
				switch (this.filters.usesSocialMedia) {
					case true:
						this.filteredForms = this.forms.filter(f => f.usesSocialMedia);
						break;
					case false:
						this.filteredForms = this.forms.filter(f => !f.usesSocialMedia);
						break;
				}
			}
		}
	}
});
