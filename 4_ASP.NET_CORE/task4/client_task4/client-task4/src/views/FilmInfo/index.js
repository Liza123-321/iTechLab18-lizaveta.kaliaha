import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import PropTypes from 'prop-types';
import ReactStars from 'react-stars';
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
	videoUrl,
	ratingChanged,
	isAuth,
}) => {
	return (
		<div>
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
									onChange={ratingChanged}
									size={40}
									edit={isAuth}
									color2={'#ffd700'}
								/>
							</div>
							<div className={classes.text_pink}>Рейтинг: {filmRating}</div>
						</div>
					</div>
					<br />
				</Card>
			</div>
			<div className={classes.top}>
				<Card className={classes.card}>
					<iframe
						width="850"
						height="540"
						src={videoUrl}
						frameBorder="0"
						allow="autoplay; encrypted-media"
						allowFullScreen
					/>
				</Card>
			</div>
		</div>
	);
};

FilmInfo.propTypes = {};

export default withStyles(styles)(FilmInfo);
