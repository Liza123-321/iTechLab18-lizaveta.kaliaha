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
import { Link } from 'react-router-dom';

let LogOut = ({ classes, logOut }) => {
	return (
		<div>
			<Card className={classes.card}>
				<div className={classes.textLogin}>LogOut</div>
				<br />
				<Button
					variant="raised"
					color="secondary"
					className={classes.loginButton}
					onClick={logOut}
				>
					<Link to={'/login'}> Yes</Link>
				</Button>{' '}
				<Button
					variant="raised"
					color="secondary"
					className={classes.loginButton}
				>
					<Link to={'/films'}>No</Link>
				</Button>
				<br />
			</Card>
		</div>
	);
};
LogOut.propTypes = {};

export default withStyles(styles)(LogOut);
