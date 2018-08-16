import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import styles from './style';
import PropTypes from 'prop-types';

let EmailError = ({ classes }) => {
	return <div className={classes.error}>Invalid email</div>;
};
EmailError.propTypes = {
	classes: PropTypes.object.isRequired,
};
export default withStyles(styles)(EmailError);
