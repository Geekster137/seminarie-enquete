let app = new Vue({
	el: '#app',

	data: {
		gender: 'man',
		usesSocialmedia: true,
		platforms: [],
		otherPlatform: '',
		howOften: '1x per week',
		whatFor: [],
		otherReason: '',
		isNeccessary: true,
		sextingGood: true,
		hasBeenCyberBullied: true,
		error: {
			hasError: false,
			reason: ''
		}
	},

	methods: {
		otherPlatformChange() {
			let i = this.platforms.indexOf(this.otherPlatform);
			this.platforms.splice(i, 1);
		},

		otherReasonChange() {
			let i = this.whatFor.indexOf(this.otherReason);
			this.whatFor.splice(i, 1);
		},

		submitForm() {
			const form = {
				gender: this.gender,
				usesSocialMedia: this.usesSocialmedia,
				platforms: this.platforms,
				howOften: this.howOften,
				whatFor: this.whatFor,
				isNeccessary: this.isNeccessary,
				sextingGood: this.sextingGood,
				hasBeenCyberBullied: this.hasBeenCyberBullied
			};

			const validation = this.formIsValid(form);
			
			if (!validation.valid) {
				this.error.hasError = true;
				this.error.reason = validation.reason;
				return;
			}

			this.postForm(form);
		},

		formIsValid(form) {
			if (form.usesSocialMedia) {
				if (form.platforms.length <= 0)
					return { valid: false, reason: 'Je moet minstens 1 platform selecteren.' };

				if (form.whatFor.length <= 0)
					return { valid: false, reason: 'Je moet minstens 1 reden dat je social media gebruikt selecteren.' };

				return { valid: true };
			}

			return { valid: true };
		},

		postForm(form) {
			const data = JSON.stringify(form);

			const xhr = new XMLHttpRequest();
			xhr.open('POST', '/api/forms');
			xhr.setRequestHeader('Content-Type', 'application/json');
			xhr.send(data);
		}
	}
});
