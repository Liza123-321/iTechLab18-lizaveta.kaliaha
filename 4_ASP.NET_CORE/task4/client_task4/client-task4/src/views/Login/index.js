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

let Login = ({
	classes,
	email,
	password,
	handleUserInput,
	formErrors,
	formValid,
}) => {
	return (
		<div>
			<form>
				<Card className={classes.card}>
					<h1>
						<AuthIcon color="primary" className={classes.authIcon} />
					</h1>
					<TextField
						id="email"
						label="Email"
						className={classes.textField}
						margin="normal"
						value={email}
						onChange={handleUserInput}
					/>
					{formErrors.email.length > 0 && <EmailError />}
					<br />

					<TextField
						id="password"
						label="Password"
						type="password"
						className={classes.textField}
						margin="normal"
						onChange={handleUserInput}
						value={password}
					/>
					{formErrors.password.length > 0 && <PasswordError />}
					<br />
					<br />
					<Button
						variant="raised"
						color="secondary"
						type="submit"
						disabled={!formValid}
						onClick={() => {
							console.log(email + ' : ' + password);
							alert(JSON.stringify(email + ' : ' + password));
						}}
						className={classes.button}
					>
						Login
					</Button>
					<br />
					<br />
					<Button variant="outlined" color="primary" className={classes.button}>
						Register
					</Button>
				</Card>
			</form>
		</div>
	);
};
Login.propTypes = {
	handleChange: PropTypes.func,
	email: PropTypes.string.isRequired,
	password: PropTypes.string.isRequired,
	formErrors: PropTypes.object.isRequired,
	formValid: PropTypes.bool.isRequired,
};

export default withStyles(styles)(Login);
