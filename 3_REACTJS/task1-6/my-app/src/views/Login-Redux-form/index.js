import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Input from '@material-ui/core/Input';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import EmailError from '../Errors/EmailError';
import PasswordError from '../Errors/PasswordError';
import { Field, reduxForm } from 'redux-form';
import styles from '../Login-Redux/style';
import PropTypes from 'prop-types';

this.renderField = ({ input, label, type }) => (
	<div>
		<div>
			<TextField
				{...input}
				id={label}
				label={label}
				type={type}
				placeholder={label}
			/>
			<br />
		</div>
	</div>
);

let LoginReduxForm = props => {
	const { handleSubmit } = props;
	return (
		<form onSubmit={handleSubmit}>
			<Card className={props.classes.card}>
				<h1>Login Redux-form</h1>
				{/*{props.formValid !== true && (*/}
				{/*<Card className={props.classes.inputGroup}>*/}
				{/*Errors*/}
				{/*<Errors formErrors={props.formErrors} />*/}
				{/*</Card>*/}
				{/*)}*/}
				<div>
					<Field
						name="email"
						component={this.renderField}
						label="email"
						onChange={props.handleUserInput}
						values={props.email}
						type="email"
					/>
				</div>
				<br />
				{props.formErrors.email.length > 0 && <EmailError />}
				<br />
				<div>
					<Field
						name="password"
						component={this.renderField}
						label="password"
						onChange={props.handleUserInput}
						values={props.password}
						type="password"
					/>
				</div>
				<br />
				{props.formErrors.password.length > 0 && <PasswordError />}
				<br /> <br />
				<Button
					variant="raised"
					color="secondary"
					disabled={!props.formValid}
					type="submit"
					className={props.classes.button}
				>
					Login
				</Button>
				<Card className={props.classes.inputGroup}>
					<Input
						type="text"
						className={props.classes.textField}
						value={props.email}
					/>
					<br />
					<Input
						type="text"
						className={props.classes.textField}
						value={props.password}
					/>
				</Card>
			</Card>
		</form>
	);
};

LoginReduxForm = reduxForm({
	form: 'login',
})(LoginReduxForm);
LoginReduxForm.propTypes = {
	handleChange: PropTypes.func,
	email: PropTypes.string,
	password: PropTypes.string,
	formErrors: PropTypes.object,
	formValid: PropTypes.bool,
	onSubmit: PropTypes.func,
};

export default withStyles(styles)(LoginReduxForm);
