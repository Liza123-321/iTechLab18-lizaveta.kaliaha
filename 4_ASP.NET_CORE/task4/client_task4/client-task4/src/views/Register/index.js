import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import AuthIcon from '@material-ui/icons/Person';
import EmailError from '../Errors/EmailError';
import PasswordError from '../Errors/PasswordError';
import styles from './style';
import PropTypes from 'prop-types';
import Checkbox from '@material-ui/core/Checkbox';

let Register = ({
	classes,
	email,
	password,
	handleUserInput,
	formErrors,
	formValid,
	loginClick,
}) => {
	return (
		<div>
			<form>
				<Card className={classes.card}>
					<div className={classes.textLogin}>Register</div>
					<br />
					<TextField
						id="email"
						label="Email"
						className={classes.textField}
						margin="normal"
						value={email}
						onChange={handleUserInput}
					/>
					<br />

					<TextField
						id="password"
						label="Password"
						type="password"
						className={classes.textField}
						margin="normal"
						value={password}
						onChange={handleUserInput}
					/>

					<TextField
						id="confirmPassword"
						label="Confirm Password"
						type="password"
						className={classes.textField}
						margin="normal"
						onChange={handleUserInput}
					/>
					<br />

					<br />
					<Button
						variant="raised"
						color="primary"
						onClick={loginClick}
						className={classes.button}
					>
						Register
					</Button>
				</Card>
			</form>
		</div>
	);
};
Register.propTypes = {
	handleChange: PropTypes.func,
	email: PropTypes.string.isRequired,
	password: PropTypes.string.isRequired,
	formErrors: PropTypes.object.isRequired,
	formValid: PropTypes.bool.isRequired,
};

export default withStyles(styles)(Register);
