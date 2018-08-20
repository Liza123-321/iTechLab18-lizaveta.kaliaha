import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import Avatar from '@material-ui/core/Avatar';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import ReactStars from 'react-stars';
import Typography from '@material-ui/core/Typography';
import styles from './style';

let Comment = ({ classes, message, userId }) => {
	return (
		<div className={classes.top}>
			<Card className={classes.card}>
				<Avatar className={classes.avatar}>H</Avatar>
				<h4>{message}</h4>
				<h4>{userId}</h4>

				{/*<Button variant="raised" color="secondary" className={classes.button}>*/}
				{/*<Link to={'/films'}> Назад </Link>*/}
				{/*</Button>*/}
			</Card>
		</div>
	);
};

Comment.propTypes = {};

export default withStyles(styles)(Comment);
