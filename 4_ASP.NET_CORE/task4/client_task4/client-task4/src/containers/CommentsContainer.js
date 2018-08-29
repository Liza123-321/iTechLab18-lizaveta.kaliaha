import React from 'react';
import Comment from '../views/Comment/index';
import '../App.css';
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
			<Comment
				message={i.commentMessage}
				userName={i.email}
				data={i.data}
				key={i.data + i.commentMessage + i.userName}
			/>
		);
	};
	render() {
		return <div>{this.props.comments.map(this.eachTask)}</div>;
	}
}
CommentsContainer.propTypes = {
	id: PropTypes.string.isRequired,
	comments: PropTypes.array.isRequired,
};

export default CommentsContainer;
