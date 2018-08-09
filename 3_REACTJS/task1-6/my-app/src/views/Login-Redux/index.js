import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import EmailError from '../Errors/EmailError';
import PasswordError from '../Errors/PasswordError';
import styles from './style';
import { Link } from 'react-router-dom';

let Login = ({
	classes,
	email,
	password,
	formErrors,
	formValid,
	changeEmail,
	changePassword,
	validateForm,
}) => {
	return (
		<div>
			<form onChange={validateForm}>
				<Card className={classes.card}>
					<h1>Login Redux</h1>
					{/*{formValid !== true && (*/}
					{/*<Card className={classes.inputGroup}>*/}
					{/*Errors*/}
					{/*<Errors formErrors={formErrors} />*/}
					{/*</Card>*/}
					{/*)}*/}
					<TextField
						id="email"
						label="Email"
						className={classes.textField}
						margin="normal"
						value={email}
						onChange={changeEmail}
					/>
					{formErrors.email.length > 0 && <EmailError />}
					<br />
					<TextField
						id="password"
						label="Password"
						type="password"
						className={classes.textField}
						margin="normal"
						onChange={changePassword}
						value={password}
					/>
					{formErrors.password.length > 0 && <PasswordError />}
					<br />
					<br />

					<Button
						variant="raised"
						color="secondary"
						disabled={!formValid}
						className={classes.button}
					>
						<Link to="/React_task1/login-redux/success"> Login </Link>
					</Button>
					<Card className={classes.inputGroup}>
						<TextField
							type="text"
							label="Input Email"
							className={classes.textField}
							value={email}
						/>
						<br />
						<TextField
							type="text"
							label="Input Password"
							className={classes.textField}
							value={password}
						/>
					</Card>
				</Card>
			</form>
		</div>
	);
};

export default withStyles(styles)(Login);
