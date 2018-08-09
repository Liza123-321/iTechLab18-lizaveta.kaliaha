import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import DeleteIcon from '@material-ui/icons/Delete';
import AddIcon from '@material-ui/icons/Add';
import styles from './style';
import PropTypes from 'prop-types';

let ParentCounter = ({
	addFunction,
	resetFunction,
	removeFunction,
	countCounter,
	classes,
}) => {
	return (
		<div>
			<TextField
				className={classes.textField}
				label="All Counters"
				value={countCounter}
			/>
			<br />
			<Button
				variant="outlined"
				color="default"
				className={classes.button}
				onClick={addFunction}
			>
				add new counter
				<AddIcon />
			</Button>
			<Button
				variant="outlined"
				color="primary"
				className={classes.button}
				onClick={resetFunction}
			>
				reset counters
			</Button>
			<Button
				variant="outlined"
				color="secondary"
				className={classes.button}
				onClick={removeFunction}
			>
				remove counter
				<DeleteIcon />
			</Button>
		</div>
	);
};
ParentCounter.propTypes = {
	countCounter: PropTypes.number.isRequired,
	addFunction: PropTypes.func.isRequired,
	resetFunction: PropTypes.func.isRequired,
	removeFunction: PropTypes.func.isRequired,
};

export default withStyles(styles)(ParentCounter);
