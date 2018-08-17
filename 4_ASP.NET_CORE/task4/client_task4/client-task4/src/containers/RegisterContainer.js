import React from 'react';
import Register from '../views/Register/index';
import axios from 'axios';
import { validateForm, validateField } from '../validation';

class RegisterContainer extends React.Component {
	constructor(props) {
		super(props);
		this.handleUserInput = this.handleUserInput.bind(this);
		this.validateField = validateField.bind(this);
		this.validateForm = validateForm.bind(this);
		this.loginClick = this.loginClick.bind(this);
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

	loginClick() {
		console.log('login');
		axios.post(`https://localhost:5001/api/user/login`).then(function(res) {});
	}

	render() {
		return (
			<Register
				email={this.state.email}
				password={this.state.password}
				handleUserInput={this.handleUserInput}
				formErrors={this.state.formErrors}
				formValid={this.state.formValid}
				loginClick={this.loginClick}
			/>
		);
	}
}

export default RegisterContainer;
