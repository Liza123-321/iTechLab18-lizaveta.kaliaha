import React from 'react';
import Comment from '../views/Comment/index';
import axios from 'axios';
import '../App.css';
import PropTypes from 'prop-types';

class CommentsContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			comments: [],
			id: this.props.id,
		};
	}
	componentDidMount() {
		let self = this;
		axios
			.get(`https://localhost:5001/api/comments/` + self.state.id)
			.then(function(res) {
				self.setState({ comments: res.data });
				console.log(res.data);
			});
	}
	eachTask = i => {
		return <Comment message={i.commentMessage} userId={i.userId} />;
	};
	render() {
		return <div>{this.state.comments.map(this.eachTask)}</div>;
	}
}
CommentsContainer.propTypes = {};

export default CommentsContainer;
