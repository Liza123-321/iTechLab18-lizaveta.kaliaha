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
			passwordValid = value.length >= 5;
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
export function validateFieldRegister(fieldName, value) {
	let fieldValidationErrors = this.state.formErrors;
	let emailValid = this.state.emailValid;
	let confirmValid = this.state.confirmValid;
	let passwordValid = this.state.passwordValid;
	let currentPassword = this.state.password;
	switch (fieldName) {
		case 'email':
			emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);
			fieldValidationErrors.email = emailValid ? '' : ' Invalid email';
			break;
		case 'password':
			passwordValid = value.length >= 5;
			fieldValidationErrors.password = passwordValid
				? ''
				: 'Password is to short';
			break;
		case 'confirm':
			confirmValid = currentPassword === value;
			fieldValidationErrors.confirm = confirmValid ? '' : 'Confirm != password';
			break;
		default:
			break;
	}
	this.setState(
		{
			formErrors: fieldValidationErrors,
			confirmValid: confirmValid,
			emailValid: emailValid,
			passwordValid: passwordValid,
		},
		this.validateFormRegister
	);
}

export function validateForm() {
	this.setState({
		formValid: this.state.emailValid && this.state.passwordValid,
	});
}
export function validateFormRegister() {
	this.setState({
		formValid:
			this.state.emailValid &&
			this.state.passwordValid &&
			this.state.confirmValid,
	});
}
