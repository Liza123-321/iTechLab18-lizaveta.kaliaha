import React from 'react';
import LogOut from '../views/LogOut/index';

class LogOutContainer extends React.Component {
	constructor(props) {
		super(props);
		this.logOut = this.logOut.bind(this);
		this.state = {};
	}

	logOut() {
		sessionStorage.removeItem('jwt_token');
	}

	render() {
		return <LogOut logOut={this.logOut} />;
	}
}

export default LogOutContainer;
