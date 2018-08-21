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
		this.registerClick = this.registerClick.bind(this);
		this.state = {
			email: '',
			password: '',
			confirm: '',
			formErrors: {
				email: 'Invalid email',
				password: 'Password is to short',
				confirm: 'Password != confirm Password',
			},
			emailValid: false,
			passwordValid: false,
			formValid: false,
			confirmValid: false,
		};
	}

	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value }, () => {
			this.validateField(name, value);
		});
	};

	registerClick() {
		let self = this;
		axios
			.post(`https://localhost:5001/api/user/register`, {
				email: self.state.email,
				password: self.state.password,
			})
			.then(function(res) {
				console.log(res);
				if (res.data) {
					alert('Success register');
				}
			});
	}

	render() {
		return (
			<Register
				email={this.state.email}
				password={this.state.password}
				confirm={this.state.confirm}
				handleUserInput={this.handleUserInput}
				formErrors={this.state.formErrors}
				formValid={this.state.formValid}
				registerClick={this.registerClick}
			/>
		);
	}
}

export default RegisterContainer;
