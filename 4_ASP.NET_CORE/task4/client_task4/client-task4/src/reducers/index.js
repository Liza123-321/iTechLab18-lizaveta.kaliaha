const initialState = {
	email: '',
	password: '',
	isAuth: false,
	formErrors: { email: 'Invalid email', password: 'Password is to short' },
	emailValid: false,
	passwordValid: false,
};
const loginForm = (state = initialState, action) => {
	switch (action.type) {
		case 'VALIDATE_FORM':
			let temp = false;
			if (state.emailValid === true && state.passwordValid === true)
				temp = true;
			return {
				...state,
				isAuth: temp,
			};
		case 'CHANGE_EMAIL':
			let emailTemp = state.emailValid;
			let errorsEmail = state.formErrors;
			if (action.email.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i)) {
				emailTemp = true;
				errorsEmail.email = '';
			} else {
				emailTemp = false;
				errorsEmail.email = 'Invalid email';
			}
			return {
				...state,
				email: action.email,
				emailValid: emailTemp,
				formErrors: errorsEmail,
			};
		case 'CHANGE_PASSWORD':
			let passwordTemp = state.passwordValid;
			let errorsPass = state.formErrors;
			if (action.password.length >= 6) {
				passwordTemp = true;
				errorsPass.password = '';
			} else {
				passwordTemp = false;
				errorsPass.password = 'Password is to short';
			}
			return {
				...state,
				password: action.password,
				passwordValid: passwordTemp,
				formErrors: errorsPass,
			};
		case 'ADD_TO_STORE':
			return {
				...state,
				email: action.email,
				password: action.password,
				isAuth: action.isAuth,
				emailValid: true,
				passwordValid: true,
				formErrors: { email: '', password: '' },
			};
		default:
			return state;
	}
};

export default loginForm;
