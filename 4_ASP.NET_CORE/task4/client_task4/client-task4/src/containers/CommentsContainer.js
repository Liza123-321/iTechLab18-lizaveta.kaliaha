import React from 'react';
import Comment from '../views/Comment/index';
import axios from 'axios';
import '../App.css';
import Card from '@material-ui/core/Card';
import PropTypes from 'prop-types';
class CommentsContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			comments: this.props.comments,
			id: this.props.id,
		};
	}

	eachTask = i => {
		return (
			<Comment message={i.commentMessage} userName={i.userName} data={i.data} />
		);
	};
	render() {
		return <div>{this.props.comments.map(this.eachTask)}</div>;
	}
}
CommentsContainer.propTypes = {};

export default CommentsContainer;
