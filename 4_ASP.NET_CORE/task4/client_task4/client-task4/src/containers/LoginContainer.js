import React from 'react';
import Login from '../views/Login/index';
import { withAlert } from 'react-alert';
import { validateForm, validateField } from '../validation';
import UserRepository from '../repository/user';

const userRepository = new UserRepository();
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
			isAuth: sessionStorage.getItem('jwt_token') != null,
		};
	}

	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value }, () => {
			this.validateField(name, value);
		});
	};

	async loginClick() {
		await userRepository.loginUser(this.state.email, this.state.password, this);
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
