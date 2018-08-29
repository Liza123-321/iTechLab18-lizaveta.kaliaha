import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import EmailError from '../Errors/EmailError';
import PasswordError from '../Errors/PasswordError';
import styles from './style';
import PropTypes from 'prop-types';
import Checkbox from '@material-ui/core/Checkbox';
import { Link } from 'react-router-dom';

let Login = ({
	classes,
	email,
	password,
	handleUserInput,
	formErrors,
	formValid,
	loginClick,
	isAuth,
}) => {
	return (
		<div>
			<form>
				<Card className={classes.card}>
					<div className={classes.textLogin}>Вход</div>
					<br />
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
						label="Пароль"
						type="password"
						className={classes.textField}
						margin="normal"
						onChange={handleUserInput}
						value={password}
					/>
					{formErrors.password.length > 0 && <PasswordError />}
					<br />

					<div className={classes.text_gray}>
						<Checkbox checked={true} value="Remember me" />
						Запомнить меня
					</div>
					<br />
					<Button
						variant="raised"
						color="secondary"
						disabled={!formValid}
						onClick={loginClick}
						className={classes.loginButton}
					>
						Вход
					</Button>
					<br />
					<Button
						variant="raised"
						color="primary"
						className={classes.button}
						component={Link}
						to={'/register'}
					>
						Регистрация
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
