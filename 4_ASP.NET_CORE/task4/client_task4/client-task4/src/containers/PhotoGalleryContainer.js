import React from 'react';
import PhotoGallery from '../views/PhotoGallery/index';
import '../App.css';
import PropTypes from 'prop-types';
import PhotoRepository from '../repository/photo';

const photoRepository = new PhotoRepository();
class PhotoGalleryContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			photoGallery: [],
			id: this.props.id,
		};
	}
	async componentDidMount() {
		let answer = await photoRepository.getPhotos(this.state.id);
		if (answer.status === 200) {
			this.setState({ photoGallery: answer.data });
		}
	}
	render() {
		return <PhotoGallery photos={this.state.photoGallery} />;
	}
}
PhotoGalleryContainer.propTypes = {
	id: PropTypes.string.isRequired,
};

export default PhotoGalleryContainer;
