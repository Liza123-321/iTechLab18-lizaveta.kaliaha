import LoginRedux from '../views/Login-Redux/index';
import { connect } from 'react-redux';
import { validateForm, changeEmail, changePassword } from '../actions/index';

const mapStateToProps = state => {
	return {
		formValid: state.loginForm.isAuth,
		email: state.loginForm.email,
		password: state.loginForm.password,
		formErrors: state.loginForm.formErrors,
	};
};

const mapDispatchToProps = dispatch => {
	return {
		changeEmail: email => dispatch(changeEmail(email.target.value)),
		changePassword: password => dispatch(changePassword(password.target.value)),
		validateForm: () => dispatch(validateForm()),
	};
};

const LoginReduxContainer = connect(
	mapStateToProps,
	mapDispatchToProps
)(LoginRedux);

export default LoginReduxContainer;
