import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import { Link } from 'react-router-dom';
import styles from './style';
import { withStyles } from '@material-ui/core/styles/index';
import PropTypes from 'prop-types';

let MyRouter = ({ handleChange, activeTabValue, classes, viewToolbar }) => {
	const VIRTUAL_PATH = '/React_task1';
	return (
		<div>
			{viewToolbar !== false && (
				<AppBar position="static">
					<Toolbar className={classes.myNav}>
						<Tabs value={activeTabValue} onChange={handleChange}>
							{/*<Tab label="Home" href="/React_task1/"/>*/}
							<Tab
								label="About"
								component={Link}
								to={VIRTUAL_PATH + '/about'}
							/>
							<Tab
								label="Counters"
								component={Link}
								to={VIRTUAL_PATH + '/counters'}
							/>
							<Tab
								label="Login"
								component={Link}
								to={VIRTUAL_PATH + '/login'}
							/>
							<Tab
								label="Login redux"
								component={Link}
								to={VIRTUAL_PATH + '/login-redux'}
							/>
							<Tab
								label="Login redux-form"
								component={Link}
								to={VIRTUAL_PATH + '/login-redux-form'}
							/>
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
