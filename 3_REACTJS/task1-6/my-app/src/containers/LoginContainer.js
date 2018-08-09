import React from 'react';
import Login from '../views/Login/index';
import { validateForm, validateField } from '../validation';

class LoginContainer extends React.Component {
	constructor(props) {
		super(props);
		this.handleUserInput = this.handleUserInput.bind(this);
		this.validateField = validateField.bind(this);
		this.validateForm = validateForm.bind(this);
		this.state = {
			email: '',
			password: '',
			formErrors: { email: 'Invalid email', password: 'Password is to short' },
			emailValid: false,
			passwordValid: false,
			formValid: false,
		};
	}

	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value }, () => {
			this.validateField(name, value);
		});
	};

	render() {
		return (
			<Login
				email={this.state.email}
				password={this.state.password}
				handleUserInput={this.handleUserInput}
				formErrors={this.state.formErrors}
				formValid={this.state.formValid}
			/>
		);
	}
}

export default LoginContainer;
