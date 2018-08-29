import React from 'react';
import Register from '../views/Register/index';
import { withAlert } from 'react-alert';
import { validateFieldRegister, validateFormRegister } from '../validation';
import UserRepository from '../repository/user';

const userRepository = new UserRepository();

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

	async registerClick() {
		await userRepository.registerUser(
			this.state.email,
			this.state.password,
			this
		);
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

export default withAlert(RegisterContainer);
