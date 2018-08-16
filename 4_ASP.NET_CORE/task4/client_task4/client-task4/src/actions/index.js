const VALIDATE_FORM = 'VALIDATE_FORM';
const CHANGE_EMAIL = 'CHANGE_EMAIL';
const CHANGE_PASSWORD = 'CHANGE_PASSWORD';
const ADD_TO_STORE = 'ADD_TO_STORE';

export const validateForm = () => {
	return {
		type: VALIDATE_FORM,
	};
};
export const changeEmail = email => {
	return {
		type: CHANGE_EMAIL,
		email,
	};
};

export const changePassword = password => {
	return {
		type: CHANGE_PASSWORD,
		password,
	};
};
export const addToStore = (email, password, isAuth) => {
	return {
		type: ADD_TO_STORE,
		email,
		password,
		isAuth,
	};
};
