import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import PropTypes from 'prop-types';
import '../../App.css';

import styles from './style';

let Genre = ({ classes, name, setGenre }) => {
	return (
		<Card className={classes.card} id={name} onClick={setGenre}>
			{name}
		</Card>
	);
};

Comment.propTypes = {
	name: PropTypes.string.isRequired,
};

export default withStyles(styles)(Genre);
