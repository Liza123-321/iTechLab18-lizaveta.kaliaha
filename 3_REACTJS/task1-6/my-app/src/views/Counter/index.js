import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import PropTypes from 'prop-types';
import styles from './style';

let Counter = ({
	incrementFunction,
	counterValue,
	resetFunction,
	decrementFunction,
	classes,
}) => {
	return (
		<div>
			<Card className={classes.card}>
				<TextField className={classes.textField} value={counterValue} />
				<br />
				<br />
				<Button
					variant="raised"
					color="default"
					className={classes.button}
					onClick={incrementFunction}
				>
					increment
				</Button>
				<Button
					variant="raised"
					color="secondary"
					className={classes.button}
					onClick={resetFunction}
				>
					reset
				</Button>
				<Button
					variant="raised"
					color="default"
					className={classes.button}
					onClick={decrementFunction}
				>
					decrement
				</Button>
			</Card>
		</div>
	);
};
Counter.propTypes = {
	incrementFunction: PropTypes.func.isRequired,
	resetFunction: PropTypes.func.isRequired,
	decrementFunction: PropTypes.func.isRequired,
	counterValue: PropTypes.number.isRequired,
};

export default withStyles(styles)(Counter);
