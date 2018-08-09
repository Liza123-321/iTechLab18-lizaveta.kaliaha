import React from 'react';
import Card from '@material-ui/core/Card';
import TextField from '@material-ui/core/TextField';
import styles from './style';
import { withStyles } from '@material-ui/core/styles/index';
import { connect } from 'react-redux';

let LoginSuccess = ({ classes, password, email }) => {
	return (
		<div>
			<Card className={classes.cardSuccess}>
				<h1>SUCCESS LOGIN_REDUX</h1>
			</Card>
			<TextField id="email" label="Email" margin="normal" value={email} />
			<br />
			<TextField id="email" label="Password" margin="normal" value={password} />
			<br />
		</div>
	);
};
const mapStateToProps = state => {
	console.log(state);
	return {
		email: state.loginForm.email,
		password: state.loginForm.password,
	};
};
export default connect(mapStateToProps)(withStyles(styles)(LoginSuccess));
