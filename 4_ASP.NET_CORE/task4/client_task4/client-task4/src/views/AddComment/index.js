import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles/index';
import Card from '@material-ui/core/Card';
import '../../App.css';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import Send from '@material-ui/icons/Send';
import styles from './style';

let AddComment = ({
	classes,
	commentMessage,
	addComment,
	handleUserInput,
	isAuth,
}) => {
	return (
		<div>
			{isAuth !== false && (
				<div className={classes.top}>
					<Card className={classes.card}>
						<TextField
							label="comment"
							id="commentMessage"
							type="text"
							className={classes.textField}
							margin="normal"
							value={commentMessage}
							onChange={handleUserInput}
						/>
						<Button
							variant="raised"
							color="secondary"
							className={classes.button}
							onClick={addComment}
						>
							Отправить
							<Send className={classes.send} />
						</Button>
					</Card>
				</div>
			)}
			<div className={classes.top}>
				<div className={classes.card}>
					{isAuth === false && (
						<Button
							variant="raised"
							color="primary"
							component={Link}
							to={'/login'}
							className={classes.button}
							onClick={addComment}
						>
							Вход
						</Button>
					)}
					<Button
						variant="raised"
						color="secondary"
						className={classes.button}
						component={Link}
						to={'/films'}
					>
						Назад
					</Button>
				</div>
			</div>
		</div>
	);
};

AddComment.propTypes = {
	commentMessage: PropTypes.string.isRequired,
	addComment: PropTypes.func.isRequired,
	handleUserInput: PropTypes.func.isRequired,
	isAuth: PropTypes.bool.isRequired,
};

export default withStyles(styles)(AddComment);
