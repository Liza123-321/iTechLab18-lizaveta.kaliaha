import React from 'react';
import LogOut from '../views/LogOut/index';
import { withAlert } from 'react-alert';

class LogOutContainer extends React.Component {
	constructor(props) {
		super(props);
		this.logOut = this.logOut.bind(this);
		this.state = {};
	}

	logOut() {
		sessionStorage.removeItem('jwt_token');
		this.props.alert.show('Logout', { type: 'info' });
	}

	render() {
		return <LogOut logOut={this.logOut} />;
	}
}

export default withAlert(LogOutContainer);
