import React from 'react';
import Login from '../views/Login/index';
import axios from 'axios';
import { withAlert } from 'react-alert';
import { validateForm, validateField } from '../validation';

class LoginContainer extends React.Component {
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
		let config = {
			headers: {
				'Content-Type': 'application/json',
			},
		};
		let self = this;
		let user = JSON.stringify({
			email: self.state.email,
			password: self.state.password,
		});
		axios
			.post(`https://localhost:5001/api/user/login`, user, config)
			.then(function(res) {
				if (res.data) {
					self.props.alert.show('Success autorize', { type: 'success' });
					sessionStorage.setItem('jwt_token', res.data.access_token);
				} else self.props.alert.show('Cant find user with this email and password', { type: 'error' });
			});
	}

	render() {
		return (
			<Login
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

export default withAlert(LoginContainer);
