import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import { Link } from 'react-router-dom';
import styles from './style';
import { withStyles } from '@material-ui/core/styles/index';
import PropTypes from 'prop-types';

let MyRouter = ({
	handleChange,
	activeTabValue,
	classes,
	viewToolbar,
	isAuth,
}) => {
	return (
		<div>
			{viewToolbar !== false && (
				<AppBar position="static" className={classes.nav}>
					<Toolbar className={classes.myNav}>
						<Tabs value={activeTabValue} onChange={handleChange}>
							<Tab label="Films" component={Link} to={'/films'} />
							{isAuth == false && (
								<Tab label="Login" component={Link} to={'/login'} />
							)}
							{isAuth != false && (
								<Tab label="LogOut" component={Link} to={'/logout'} />
							)}
						</Tabs>
					</Toolbar>
				</AppBar>
			)}
		</div>
	);
};
MyRouter.propTypes = {
	handleChange: PropTypes.func.isRequired,
	activeTabValue: PropTypes.any.isRequired,
	login: PropTypes.string.isRequired,
	password: PropTypes.string.isRequired,
	viewToolbar: PropTypes.bool.isRequired,
};

export default withStyles(styles)(MyRouter);
