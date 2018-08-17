import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import ReactStars from 'react-stars';
import Typography from '@material-ui/core/Typography';
import styles from './style';

let FilmInfo = ({
	classes,
	filmPoster,
	filmName,
	filmId,
	filmDescription,
	filmYear,
	filmCountry,
	filmProducer,
	filmRating,
}) => {
	return (
		<div className={classes.top}>
			<Card className={classes.card}>
				<div className={classes.title}>{filmName}</div>
				<div className={classes.description}>
					<img src={filmPoster} className={classes.media} />
					<div className={classes.textPadding}>
						<div className={classes.text_pink}>
							Год:
							{filmYear}{' '}
						</div>
						<hr />
						<div className={classes.text_pink}>Страна: {filmCountry}</div>
						<hr />
						<div className={classes.text_pink}>Режисер: {filmProducer}</div>
						<hr />
						<div className={classes.text}>{filmDescription}</div>
						<hr />
						<div className={classes.stars}>
							<ReactStars
								count={5}
								value={filmRating / 2}
								size={30}
								color2={'#ffd700'}
							/>
						</div>
					</div>
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
