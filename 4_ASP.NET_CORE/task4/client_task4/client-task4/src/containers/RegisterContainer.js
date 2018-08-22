import React from 'react';
import Register from '../views/Register/index';
import axios from 'axios';
import { validateFieldRegister, validateFormRegister } from '../validation';

class RegisterContainer extends React.Component {
	constructor(props) {
		super(props);
		this.handleUserInput = this.handleUserInput.bind(this);
		this.validateFieldRegister = validateFieldRegister.bind(this);
		this.validateFormRegister = validateFormRegister.bind(this);
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
			this.validateFieldRegister(name, value);
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
				if (res.data) {
					alert('Success register');
				}
			})
			.then(function() {
				axios
					.post(`https://localhost:5001/api/user/login`, {
						email: self.state.email,
						password: self.state.password,
					})
					.then(function(res) {
						if (res.data) {
							alert('Success autorize');
							sessionStorage.setItem('jwt_token', res.data.access_token);
						} else alert('Cant find user with this email and password');
					});
			})
			.catch(function(res) {
				alert('You cant use this email!');
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
