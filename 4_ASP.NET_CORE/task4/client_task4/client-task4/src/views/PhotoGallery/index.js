import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import styles from './style';

let PhotoGallery = ({ classes, photos }) => {
	return (
		<div>
			<div className={classes.top}>
				<Card className={classes.card}>
					<GridList cellHeight={200} className={classes.gridList} cols={3}>
						{photos.map(tile => (
							<GridListTile key={tile.photoUrl}>
								<img src={tile.photoUrl} />
							</GridListTile>
						))}
					</GridList>
				</Card>
			</div>
		</div>
	);
};

PhotoGallery.propTypes = {};

export default withStyles(styles)(PhotoGallery);
