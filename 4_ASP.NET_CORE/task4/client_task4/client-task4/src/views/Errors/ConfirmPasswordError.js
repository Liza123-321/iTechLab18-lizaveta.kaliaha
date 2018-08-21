import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import styles from './style';
import PropTypes from 'prop-types';

export let ConfirmPasswordError = ({ classes }) => {
	return <div className={classes.error}>Password != confirm Password</div>;
};
ConfirmPasswordError.propTypes = {
	classes: PropTypes.object.isRequired,
};
export default withStyles(styles)(ConfirmPasswordError);
