import React from 'react';
import AddComment from '../views/AddComment/index';
import axios from 'axios';
import '../App.css';
import CommentsContainer from './CommentsContainer';
import PropTypes from 'prop-types';

class AddCommentContainer extends React.Component {
	constructor(props) {
		super(props);
		this.addComment = this.addComment.bind(this);
		this.handleUserInput = this.handleUserInput.bind(this);
		this.state = {
			id: this.props.id,
			commentMessage: '',
			isAuth: sessionStorage.getItem('jwt_token') !== null,
		};
	}
	handleUserInput = e => {
		const name = e.target.id;
		const value = e.target.value;
		this.setState({ [name]: value });
	};
	addComment() {
		let now = new Date();
		let self = this;
		let config = {
			headers: {
				Authorization: 'Bearer ' + sessionStorage.getItem('jwt_token'),
			},
		};
		if (self.state.commentMessage.length !== 0) {
			axios
				.post(
					`https://localhost:5001/api/comments/`,
					{
						commentMessage: self.state.commentMessage,
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
							now.getSeconds() +
							':' +
							now.getMilliseconds(),
					},
					config
				)
				.then(function(res) {
					self.setState({ commentMessage: '' });
				})
				.catch(res => {
					alert(res.toString());
				});
		}
	}
	render() {
		return (
			<div>
				<CommentsContainer id={this.state.id} />
				<AddComment
					addComment={this.addComment}
					commentMeaasge={this.state.commentMessage}
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
