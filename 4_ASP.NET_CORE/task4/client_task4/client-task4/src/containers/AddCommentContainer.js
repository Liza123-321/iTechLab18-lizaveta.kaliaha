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
const token = sessionStorage.getItem('jwt_token');
const connection = new signalR.HubConnectionBuilder()
	.withUrl('https://localhost:5001/test', { accessTokenFactory: () => token })
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
	}
	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value });
	};

	async componentDidMount() {
		connection
			.start()
			.then(() => connection.invoke('SetComment', this.state.id));
		connection.on('ReceiveComments', comments => {
			this.setState({ comments: comments });
		});
	}
	async addComment() {
		let now = new Date();
		let obj = {
			commentMessage: this.state.commentMessage,
			filmId: this.state.id,
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
		};
		connection.invoke('AddComment', obj);
		this.setState({ commentMessage: '' });
		connection.on('ReceiveComments', comments => {
			this.setState({ comments: comments });
		});
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
