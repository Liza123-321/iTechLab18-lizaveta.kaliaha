import React from 'react';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import styles from './style';
import PropTypes from 'prop-types';
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
					component={Link}
					to={'/login'}
				>
					Yes
				</Button>{' '}
				<Button
					variant="raised"
					color="secondary"
					className={classes.loginButton}
					component={Link}
					to={'/films'}
				>
					No
				</Button>
				<br />
			</Card>
		</div>
	);
};
LogOut.propTypes = {
	logOut: PropTypes.func,
};

export default withStyles(styles)(LogOut);
