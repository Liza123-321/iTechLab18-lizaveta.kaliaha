import React from 'react';
import LoginReduxForm from '../views/Login-Redux-form/index';
import { connect } from 'react-redux';
import { addToStore } from '../actions';
import { validateForm, validateField } from '../validation';

class LoginReduxFormContainer extends React.Component {
	constructor(props) {
		super(props);
		this.validateField = validateField.bind(this);
		this.validateForm = validateForm.bind(this);
		this.state = {
			formErrors: { email: 'Invalid email', password: 'Password is to short' },
			emailValid: false,
			passwordValid: false,
			formValid: false,
		};
	}

	submit = values => {
		console.log(values);
		this.props.addToStore(values.email, values.password, this.state.formValid);
		this.props.history.push(`${this.props.history.location.pathname}/success`);
	};

	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value }, () => {
			this.validateField(name, value);
		});
	};

	render() {
		let { email, password } = this.props.formState.values
			? this.props.formState.values
			: '';
		return (
			<LoginReduxForm
				onSubmit={this.submit}
				email={email}
				password={password}
				handleUserInput={this.handleUserInput}
				formErrors={this.state.formErrors}
				formValid={this.state.formValid}
			/>
		);
	}
}

function mapDispatchToProps(dispatch) {
	return {
		addToStore: (email, password, isAuth) =>
			dispatch(addToStore(email, password, isAuth)),
	};
}

// прокидываем в props объект для инициализаци формы
function mapStateToProps(state) {
	return {
		formState: { ...state.form.login },
		state: state,
	};
}

export default connect(
	mapStateToProps,
	mapDispatchToProps
)(LoginReduxFormContainer);
