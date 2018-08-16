export function validateField(fieldName, value) {
	let fieldValidationErrors = this.state.formErrors;
	let emailValid = this.state.emailValid;
	let passwordValid = this.state.passwordValid;
	switch (fieldName) {
		case 'email':
			emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);
			fieldValidationErrors.email = emailValid ? '' : ' Invalid email';
			break;
		case 'password':
			passwordValid = value.length >= 6;
			fieldValidationErrors.password = passwordValid
				? ''
				: 'Password is to short';
			break;
		default:
			break;
	}
	this.setState(
		{
			formErrors: fieldValidationErrors,
			emailValid: emailValid,
			passwordValid: passwordValid,
		},
		this.validateForm
	);
}

export function validateForm() {
	this.setState({
		formValid: this.state.emailValid && this.state.passwordValid,
	});
}
