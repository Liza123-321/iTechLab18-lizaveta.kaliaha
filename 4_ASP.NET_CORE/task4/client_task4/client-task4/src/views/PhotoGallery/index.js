import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import Gallery from 'react-grid-gallery';
import PropTypes from 'prop-types';
import styles from './style';

let PhotoGallery = ({ classes, photos }) => {
	return (
		<div className={classes.top}>
			<Card className={classes.card}>
				<div className={classes.gridList}>
					<Gallery
						enableImageSelection={false}
						images={photos.map(photo => ({
							src: photo.src,
							thumbnail: photo.src,
							thumbnailWidth: 300,
							thumbnailHeight: 180,
						}))}
					/>
				</div>
			</Card>
		</div>
	);
};

PhotoGallery.propTypes = {
	photos: PropTypes.array.isRequired,
};

export default withStyles(styles)(PhotoGallery);
