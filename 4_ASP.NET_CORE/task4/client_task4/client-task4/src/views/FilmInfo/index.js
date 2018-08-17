import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import Typography from '@material-ui/core/Typography';
import styles from './style';

let FilmInfo = ({ classes, filmPoster, filmName, filmId, filmDescription }) => {
	return (
		<div className={classes.top}>
			<Card className={classes.card}>
				<h2 className={classes.title}>{filmName}</h2>
				<div>
					<img src={filmPoster} className={classes.media} />
					<h5>{filmDescription}</h5>
				</div>
				<br />
				<Button variant="raised" color="secondary" className={classes.button}>
					<Link to={'/React_task1/films'}> Назад </Link>
				</Button>
			</Card>
		</div>
	);
};

FilmInfo.propTypes = {};

export default withStyles(styles)(FilmInfo);
