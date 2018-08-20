import React from 'react';
import PhotoGallery from '../views/PhotoGallery/index';
import axios from 'axios';
import '../App.css';
import PropTypes from 'prop-types';

class PhotoGalleryContainer extends React.Component {
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
		return <PhotoGallery photos={this.state.photoGallery} />;
	}
}
PhotoGalleryContainer.propTypes = {};

export default PhotoGalleryContainer;
