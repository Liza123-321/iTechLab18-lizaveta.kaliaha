import React from 'react';
import AddComment from '../views/AddComment/index';
import axios from 'axios';
import '../App.css';
import CommentsContainer from './CommentsContainer';
import PropTypes from 'prop-types';

class AddCommentContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			photoGallery: [],
			id: this.props.id,
		};
	}
	componentDidMount() {
		let self = this;
		axios
			.get(`https://localhost:5001/api/photogalery/` + self.state.id)
			.then(function(res) {
				self.setState({ photoGallery: res.data });
			});
	}
	render() {
		return (
			<div>
				<CommentsContainer id={this.state.id} />
				<AddComment />
			</div>
		);
	}
}
AddCommentContainer.propTypes = {};

export default AddCommentContainer;
