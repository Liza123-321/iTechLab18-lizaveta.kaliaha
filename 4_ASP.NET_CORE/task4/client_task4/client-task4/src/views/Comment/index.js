import React from 'react';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import PropTypes from 'prop-types';
import '../../App.css';
import Avatar from '@material-ui/core/Avatar';

import styles from './style';

let Comment = ({ classes, message, userName, data }) => {
	return (
		<div className={classes.top}>
			<Card className={classes.card}>
				<Avatar className={classes.avatar}>{userName.charAt(0)}</Avatar>
				<div className={classes.column}>
					<div className={classes.userName}>{userName}</div>
					<div className={classes.commentMessage}>{message}</div>
				</div>
				<div className={classes.commentData}>{data}</div>
			</Card>
		</div>
	);
};

Comment.propTypes = {};

export default withStyles(styles)(Comment);
