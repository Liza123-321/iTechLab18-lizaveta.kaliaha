import React from 'react';
import AddComment from '../views/AddComment/index';
import axios from 'axios';
import '../App.css';
import { withAlert } from 'react-alert';
import CommentsContainer from './CommentsContainer';
import PropTypes from 'prop-types';
import Card from '@material-ui/core/Card';
import CommentRepository from '../repository/comment';

const commentRepository = new CommentRepository();
class AddCommentContainer extends React.Component {
	constructor(props) {
		super(props);
		this.addComment = this.addComment.bind(this);
		this.handleUserInput = this.handleUserInput.bind(this);
		this.state = {
			id: this.props.id,
			commentMessage: '',
			comments: [],
			isAuth: sessionStorage.getItem('jwt_token') !== null,
		};
	}
	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value });
	};

	async componentDidMount() {
		let res = await commentRepository.getComments(this.state.id);
		if (res.status === 200) {
			this.setState({ comments: res.data });
		}
	}
	addComment() {
		let now = new Date();
		let self = this;
		let config = {
			headers: {
				Authorization: 'Bearer ' + sessionStorage.getItem('jwt_token'),
			},
		};
		let commentMsg = self.state.commentMessage;
		this.setState({ commentMessage: '' });
		if (self.state.commentMessage.length !== 0) {
			axios
				.post(
					`https://localhost:5001/api/comments/`,
					{
						commentMessage: commentMsg,
						userId: 0,
						filmId: self.props.id,
						data:
							now.getDate() +
							'/' +
							now.getMonth() +
							'/' +
							now.getFullYear() +
							' ' +
							now.getHours() +
							':' +
							now.getMinutes() +
							':' +
							now.getSeconds(),
					},
					config
				)
				.then(function() {
					self.props.alert.show('Success add comment', { type: 'success' });
				})
				.catch(res => {
					self.props.alert.show('You should login', { type: 'error' });
					sessionStorage.removeItem('jwt_token');
				})
				.then(async function() {
					let res = await commentRepository.getComments(self.state.id);
					self.setState({ comments: res.data });
				});
		}
	}
	render() {
		return (
			<div>
				<Card className="card">
					<CommentsContainer
						id={this.state.id}
						comments={this.state.comments}
					/>
				</Card>
				<AddComment
					addComment={this.addComment}
					commentMessage={this.state.commentMessage}
					handleUserInput={this.handleUserInput}
					isAuth={this.state.isAuth}
				/>
			</div>
		);
	}
}
AddCommentContainer.propTypes = {
	id: PropTypes.string.isRequired,
};

export default withAlert(AddCommentContainer);
