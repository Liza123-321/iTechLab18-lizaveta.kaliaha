import React from 'react';
import AddComment from '../views/AddComment/index';
import '../App.css';
import { withAlert } from 'react-alert';
import CommentsContainer from './CommentsContainer';
import PropTypes from 'prop-types';
import Card from '@material-ui/core/Card';
import CommentRepository from '../repository/comment';

const commentRepository = new CommentRepository();
const signalR = require('@aspnet/signalr');
const connection = new signalR.HubConnectionBuilder()
	.withUrl('https://localhost:5001/comment')
	.build();
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
		connection.start().catch(error => {
			console.log(error);
		});
	}
	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value });
	};

	async componentDidMount() {
		let self = this;
		let res = await commentRepository.getComments(this.state.id);
		if (res.status === 200) {
			this.setState({ comments: res.data });
		}
		connection.on('GetComment', comments => {
			console.log(comments);
			console.log(self.state.id);
			if (comments[0].filmId == self.state.id) {
				this.setState({ comments: comments });
			}
		});
	}
	async addComment() {
		await commentRepository.addComment(
			this.state.id,
			this.state.commentMessage,
			this
		);
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
