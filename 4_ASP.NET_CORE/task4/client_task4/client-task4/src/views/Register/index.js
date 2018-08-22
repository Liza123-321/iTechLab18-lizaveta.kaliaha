import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import EmailError from '../Errors/EmailError';
import PasswordError from '../Errors/PasswordError';
import ConfirmPasswordError from '../Errors/ConfirmPasswordError';
import styles from './style';
import PropTypes from 'prop-types';

let Register = ({
	classes,
	email,
	password,
	handleUserInput,
	formErrors,
	formValid,
	registerClick,
}) => {
	return (
		<div>
			<form>
				<Card className={classes.card}>
					<div className={classes.textLogin}>Регистрация</div>
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
					{formErrors.email.length > 0 && <EmailError />}
					<br />

					<TextField
						id="password"
						label="Пароль"
						type="password"
						className={classes.textField}
						margin="normal"
						value={password}
						onChange={handleUserInput}
					/>
					{formErrors.password.length > 0 && <PasswordError />}
					<br />
					<TextField
						id="confirm"
						label="Подтверждение пароля"
						type="password"
						className={classes.textField}
						margin="normal"
						onChange={handleUserInput}
					/>
					<br />
					{formErrors.confirm.length > 0 && <ConfirmPasswordError />}
					<br />
					<Button
						variant="raised"
						color="primary"
						onClick={registerClick}
						disabled={!formValid}
						className={classes.button}
					>
						Регистрация
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
