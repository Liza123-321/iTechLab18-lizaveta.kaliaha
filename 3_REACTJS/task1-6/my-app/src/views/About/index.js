import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import MenuItem from '@material-ui/core/MenuItem';
import Card from '@material-ui/core/Card';
import Select from '@material-ui/core/Select';
import AddIcon from '@material-ui/icons/Add';
import HomeIcon from '@material-ui/icons/Home';
import CommentIcon from '@material-ui/icons/Comment';
import styles from './style';
import PropTypes from 'prop-types';

let About = ({ classes }) => {
	return (
		<div>
			<Card className={classes.card}>
				<h1>About</h1>
				<div>некий отформатированный контент о нашей компании на ваш выбор</div>
				<TextField
					id="name"
					label="Name"
					className={classes.textField}
					margin="normal"
				/>
				<br />

				<TextField
					id="email"
					label="Email"
					className={classes.textField}
					margin="normal"
				/>
				<Select value={'age'}>
					<MenuItem value="">
						<em>None</em>
					</MenuItem>
					<MenuItem value={10}>10</MenuItem>
					<MenuItem value={20}>20</MenuItem>
					<MenuItem value={30}>30</MenuItem>
				</Select>
				<br />

				<br />
				<br />
				<Button variant="raised" color="secondary" className={classes.button}>
					join
					<AddIcon />
				</Button>
				<br />
				<Button variant="outlined" color="primary" className={classes.button}>
					<CommentIcon />
				</Button>
				<Button variant="contained" color="default" className={classes.button}>
					Help
				</Button>
				<Button variant="outlined" color="primary" className={classes.button}>
					<HomeIcon />
				</Button>
			</Card>
		</div>
	);
};
About.propTypes = {
	classes: PropTypes.object.isRequired,
};
export default withStyles(styles)(About);
