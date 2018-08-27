import axios from 'axios/index';

axios.defaults.headers.common['Authorization'] =
	'Bearer ' + sessionStorage.getItem('jwt_token');
axios.defaults.headers.common['Content-Type'] = 'application/json';

export default class UserRepository {
	loginUser = (email, password, self) => {
		let config = {
			headers: {
				'Content-Type': 'application/json',
			},
		};
		let user = JSON.stringify({
			email: email,
			password: password,
		});
		axios
			.post(`https://localhost:5001/api/user/login`, user, config)
			.then(function(res) {
				if (res.data) {
					self.props.alert.show('Success autorize', { type: 'success' });
					sessionStorage.setItem('jwt_token', res.data.access_token);
				} else self.props.alert.show('Cant find user with this email and password', { type: 'error' });
			});
	};
	registerUser = (myEmail, myPassword, self) => {
		let result = axios
			.post(`https://localhost:5001/api/user/register`, {
				email: self.state.email,
				password: self.state.password,
			})
			.then(function(res) {
				if (res.data) {
					self.props.alert.show('Success register', { type: 'success' });
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
							self.props.alert.show('Success autorize', { type: 'success' });
							sessionStorage.setItem('jwt_token', res.data.access_token);
						}
					});
			})
			.catch(() => {
				self.props.alert.show('This email used by other user', {
					type: 'error',
				});
			});
		if (result != null) return true;
	};
}
