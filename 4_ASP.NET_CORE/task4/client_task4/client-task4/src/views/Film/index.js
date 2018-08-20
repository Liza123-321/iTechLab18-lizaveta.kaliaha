import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import { Link } from 'react-router-dom';
import ReactStars from 'react-stars';
import PropTypes from 'prop-types';
import Typography from '@material-ui/core/Typography';
import styles from './style';

let Film = ({ classes, filmPoster, filmName, filmId, filmRating }) => {
	return (
		<Card className={classes.card}>
			<img src={filmPoster} className={classes.media} />
			<h2 className={classes.title}>{filmName}</h2>
			<br />
			<div className={classes.stars}>
				<ReactStars
					count={5}
					value={filmRating / 2}
					size={30}
					color2={'#ffd700'}
				/>
			</div>
			<br />
			<Button variant="raised" color="secondary" className={classes.button}>
				<Link to={'/film/' + filmId}> Подробно </Link>
			</Button>
		</Card>
	);
};

Film.propTypes = {};

export default withStyles(styles)(Film);
