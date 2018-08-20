import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import ReactStars from 'react-stars';
import Typography from '@material-ui/core/Typography';
import styles from './style';

let PhotoGallery = ({ classes, photos }) => {
	return (
		<div className={classes.top}>
			<Card className={classes.card}>
				<GridList cellHeight={200} className={classes.gridList} cols={3}>
					{photos.map(tile => (
						<GridListTile key={tile.photoUrl}>
							<img src={tile.photoUrl} />
						</GridListTile>
					))}
				</GridList>
				<Button variant="raised" color="secondary" className={classes.button}>
					<Link to={'/films'}> Назад </Link>
				</Button>
			</Card>
		</div>
	);
};

PhotoGallery.propTypes = {};

export default withStyles(styles)(PhotoGallery);
