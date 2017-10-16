let app = new Vue({
	el: '#app',

	data: {
		gender: 'man',
		usesSocialmedia: true,
		platforms: [],
		otherPlatform: '',
		otherPlatformSelected: false,
		howOften: '1x per week',
		whatFor: [],
		otherReason: '',
		otherReasonSelected: false,
		isNeccessary: true,
		sextingGood: true,
		hasBeenCyberBullied: true,
		error: {
			hasError: false,
			reason: ''
		},
		filledIn: false
	},

	mounted() {
		if (!!window.localStorage.getItem('FormFilledIn'))
			this.filledIn = true;
	},

	methods: {
		submitForm() {
			if (this.otherPlatformSelected && this.otherPlatform != '')
				this.platforms.push(this.otherPlatform);

			if (this.otherReasonSelected && this.otherReason != '')
				this.whatFor.push(this.otherReason);

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
			window.localStorage.setItem('FormFilledIn', 'true');
			this.filledIn = true;
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
