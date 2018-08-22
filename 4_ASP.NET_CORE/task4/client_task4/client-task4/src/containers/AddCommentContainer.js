import React from 'react';
import AddComment from '../views/AddComment/index';
import axios from 'axios';
import '../App.css';
import CommentsContainer from './CommentsContainer';
import PropTypes from 'prop-types';
import Card from '@material-ui/core/Card';

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

	componentDidMount() {
		let self = this;
		axios
			.get(`https://localhost:5001/api/comments/` + self.state.id)
			.then(function(res) {
				self.setState({ comments: res.data });
			});
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
				.catch(res => {
					alert(res.toString());
					sessionStorage.removeItem('jwt_token');
				})
				.then(function() {
					axios
						.get(`https://localhost:5001/api/comments/` + self.state.id)
						.then(function(res) {
							console.log(res.data);
							self.setState({ comments: res.data });
						});
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

export default AddCommentContainer;
